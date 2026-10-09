// ApiDocGen: writes the API reference in ModDevelopment/docs/reference/ from the libraries installed in the game.
//
// Sources:
//   - Public types and members: read from the DLLs in the game folder with MetadataLoadContext (nothing is executed).
//   - Descriptions: the XML documentation files. LemonUI and NativeUI ship them in scripts/. SHVDN's come from its
//     NuGet packages, downloaded to tools/ApiDocGen/cache/.
//   - Natives: alloc8or's NativeDB (natives.json), downloaded to the cache.
//   - Lua natives: the names compiled into LUA.asi.
//
// Run from anywhere inside the game folder:  dotnet run -c Release --project ModDevelopment/tools/ApiDocGen

using System.IO.Compression;
using System.Net.Http;
using System.Reflection;
using System.Text;
using System.Text.Json;
using System.Text.RegularExpressions;
using System.Xml.Linq;

string gameDir = FindGameDir();
string devDir = Path.Combine(gameDir, "ModDevelopment");
string refDir = Path.Combine(devDir, "docs", "reference");
string cacheDir = Path.Combine(devDir, "tools", "ApiDocGen", "cache");
Directory.CreateDirectory(cacheDir);

Console.WriteLine($"Game folder: {gameDir}");

using var http = new HttpClient();
http.DefaultRequestHeaders.UserAgent.ParseAdd("ApiDocGen/1.0");

string shvdn3Xml = await GetNuGetXml("scripthookvdotnet3", "3.6.0", "ScriptHookVDotNet3.xml");
string shvdn2Xml = await GetNuGetXml("scripthookvdotnet2", "2.11.6", "ScriptHookVDotNet2.xml");
string nativesJson = await Download("https://raw.githubusercontent.com/alloc8or/gta5-nativedb-data/master/natives.json", "natives.json");
string nativesSource = await NativeDbVersion();

// The SHVDN API DLLs reference the runtime assembly "ScriptHookVDotNet", which ships as ScriptHookVDotNet.asi.
// MetadataLoadContext's resolver matches by file name, so it gets a .dll copy in the cache.
string runtimeAsi = Path.Combine(gameDir, "ScriptHookVDotNet.asi");
string runtimeCopy = Path.Combine(cacheDir, "ScriptHookVDotNet.dll");
File.Copy(runtimeAsi, runtimeCopy, true);

const string NoDocs = "none: the library ships without XML documentation, so only signatures are listed";
var libraries = new[]
{
	new Library("SHVDN3", "ScriptHookVDotNet v3", Path.Combine(gameDir, "ScriptHookVDotNet3.dll"), shvdn3Xml,
		"`ScriptHookVDotNet3.xml` from the NuGet package `scripthookvdotnet3` 3.6.0 (nuget.org). The installed DLL is 3.7.0.189, so members added after 3.6.0 have no description",
		"The API for new C# scripts."),
	new Library("SHVDN2", "ScriptHookVDotNet v2 (legacy)", Path.Combine(gameDir, "ScriptHookVDotNet2.dll"), shvdn2Xml,
		"`ScriptHookVDotNet2.xml` from the NuGet package `scripthookvdotnet2` 2.11.6 (nuget.org), the same version as the installed DLL",
		"Only for old mods. Write new scripts against v3. Mods built against the pre-2.10 API name `ScriptHookVDotNet` 0.0.0.0 (Cop_Arrest, Disarm, MapEditor, Stance) also run on this API: SHVDN redirects them here, as `ScriptHookVDotNet.log` shows."),
	new Library("SHVDN-Runtime", "ScriptHookVDotNet runtime (ScriptHookVDotNet.asi)", runtimeCopy, "",
		NoDocs,
		"The host that loads .NET scripts. Its public types are SHVDN's internal plumbing: scripts should use the v3 API instead, and these can change in any SHVDN update. Documented here for completeness and for the console commands below.",
		runtimeAsi),
	new Library("LemonUI", "LemonUI for SHVDN v3", Path.Combine(gameDir, "scripts", "LemonUI.SHVDN3.dll"), Path.Combine(gameDir, "scripts", "LemonUI.SHVDN3.xml"),
		"`scripts/LemonUI.SHVDN3.xml`, shipped with the installed DLL",
		"Menus and screen elements for SHVDN v3 scripts."),
	new Library("NativeUI", "NativeUI (legacy, SHVDN v2)", Path.Combine(gameDir, "scripts", "NativeUI.dll"), Path.Combine(gameDir, "scripts", "NativeUI.xml"),
		"`scripts/NativeUI.xml`, shipped with the installed DLL",
		"Older menu library built on SHVDN v2. Use LemonUI for new scripts."),
	new Library("iFruitAddon2", "iFruitAddon2 (phone contacts, SHVDN v3)", Path.Combine(gameDir, "scripts", "iFruitAddon2.dll"), "",
		NoDocs,
		"Adds custom contacts to the in-game phone. Usage: ModDevelopment/docs/guides/03-Menus-and-UI.md."),
};

foreach (Library lib in libraries)
	WriteLibrary(lib);

var nativeIndex = WriteNatives(nativesJson);
WriteLuaNatives(Path.Combine(gameDir, "LUA.asi"), nativeIndex);
WriteInventory();

Console.WriteLine($"Done. Reference written to {refDir}");

// ---------------------------------------------------------------- downloads

async Task<string> Download(string url, string fileName)
{
	string path = Path.Combine(cacheDir, fileName);
	if (!File.Exists(path))
	{
		Console.WriteLine($"Downloading {url}");
		await File.WriteAllBytesAsync(path, await http.GetByteArrayAsync(url));
	}
	return path;
}

async Task<string> GetNuGetXml(string package, string version, string xmlName)
{
	string xmlPath = Path.Combine(cacheDir, xmlName);
	if (File.Exists(xmlPath))
		return xmlPath;

	string nupkg = await Download($"https://api.nuget.org/v3-flatcontainer/{package}/{version}/{package}.{version}.nupkg", $"{package}.{version}.nupkg");
	using var zip = ZipFile.OpenRead(nupkg);
	var entry = zip.Entries.FirstOrDefault(e => e.Name.Equals(xmlName, StringComparison.OrdinalIgnoreCase))
		?? throw new InvalidOperationException($"{xmlName} not found in {package} {version}");
	entry.ExtractToFile(xmlPath);
	return xmlPath;
}

// Which NativeDB commit natives.json came from, recorded when it is first downloaded.
async Task<string> NativeDbVersion()
{
	string path = Path.Combine(cacheDir, "natives.source.txt");
	if (!File.Exists(path))
	{
		string text;
		try
		{
			string json = await http.GetStringAsync("https://api.github.com/repos/alloc8or/gta5-nativedb-data/commits?path=natives.json&per_page=1");
			var commit = JsonDocument.Parse(json).RootElement[0];
			string sha = commit.GetProperty("sha").GetString()![..12];
			string date = commit.GetProperty("commit").GetProperty("committer").GetProperty("date").GetString()![..10];
			text = $"commit `{sha}` ({date})";
		}
		catch (Exception ex)
		{
			text = $"commit unknown ({ex.GetType().Name} while asking GitHub)";
		}
		File.WriteAllText(path, $"{text}, downloaded {DateTime.Now:yyyy-MM-dd}");
	}
	return File.ReadAllText(path).Trim();
}

// One line naming a source file exactly: path, versions, size, date and SHA-256.
string Provenance(string path)
{
	var info = new FileInfo(path);
	var v = System.Diagnostics.FileVersionInfo.GetVersionInfo(path);
	string version = string.IsNullOrWhiteSpace(v.FileVersion) ? "no version info" : $"file version {v.FileVersion.Trim()}";
	string asmVersion = "";
	try { asmVersion = $", assembly version {AssemblyName.GetAssemblyName(path).Version}"; } catch { }
	using var stream = File.OpenRead(path);
	string sha = Convert.ToHexString(System.Security.Cryptography.SHA256.HashData(stream)).ToLowerInvariant();
	return $"`{Rel(path)}` ({version}{asmVersion}, {info.Length:N0} bytes, modified {info.LastWriteTime:yyyy-MM-dd}, SHA-256 `{sha}`)";
}

string Rel(string path) => Path.GetRelativePath(gameDir, path).Replace('\\', '/');

static string FindGameDir()
{
	for (var dir = new DirectoryInfo(Directory.GetCurrentDirectory()); dir != null; dir = dir.Parent)
		if (File.Exists(Path.Combine(dir.FullName, "GTA5.exe")))
			return dir.FullName;
	throw new InvalidOperationException("Run this from inside the game folder (where GTA5.exe is).");
}

// ---------------------------------------------------------------- .NET libraries

void WriteLibrary(Library lib)
{
	Console.WriteLine($"Reading {lib.Title}");

	string frameworkDir = @"C:\Program Files (x86)\Reference Assemblies\Microsoft\Framework\.NETFramework\v4.8";
	var paths = Directory.GetFiles(frameworkDir, "*.dll")
		.Concat(Directory.GetFiles(Path.Combine(frameworkDir, "Facades"), "*.dll"))
		.Concat(new[] { Path.Combine(gameDir, "ScriptHookVDotNet2.dll"), Path.Combine(gameDir, "ScriptHookVDotNet3.dll"), runtimeCopy })
		.Append(lib.DllPath)
		.Distinct(StringComparer.OrdinalIgnoreCase);

	using var mlc = new MetadataLoadContext(new PathAssemblyResolver(paths), "mscorlib");
	Assembly asm = mlc.LoadFromAssemblyPath(lib.DllPath);
	var docs = new XmlDocs(lib.XmlPath);

	Type[] types;
	try { types = asm.GetTypes(); }
	catch (ReflectionTypeLoadException ex) { types = ex.Types.Where(t => t != null).ToArray()!; }

	// msclr is generated by the C++/CLI compiler, not part of any API.
	var publicTypes = types.Where(t => (t.IsPublic || t.IsNestedPublic) && t.Namespace != "msclr").OrderBy(t => t.FullName).ToList();
	string libDir = Path.Combine(refDir, lib.Folder);
	if (Directory.Exists(libDir))
		Directory.Delete(libDir, true);
	Directory.CreateDirectory(libDir);

	string sourceFile = lib.SourcePath ?? lib.DllPath;
	string sourceBlock =
		$"> **Source:** {Provenance(sourceFile)}  \n" +
		"> **Method:** public and protected types and members read from the assembly's .NET metadata with `System.Reflection.MetadataLoadContext` (the code is not run or decompiled), by `ModDevelopment/tools/ApiDocGen`.  \n" +
		$"> **Descriptions:** {lib.DocsSource}.";

	var index = new StringBuilder();
	index.AppendLine($"# {lib.Title} API reference");
	index.AppendLine();
	index.AppendLine(sourceBlock);
	index.AppendLine();
	index.AppendLine("Generated: don't edit by hand, re-run the generator instead.");
	index.AppendLine();
	index.AppendLine(lib.Note);
	index.AppendLine();
	index.AppendLine($"{publicTypes.Count} public types.");
	index.AppendLine();

	if (lib.Folder == "SHVDN-Runtime")
		WriteConsoleCommands(index, types);

	foreach (var group in publicTypes.GroupBy(t => t.Namespace ?? "global"))
	{
		string file = group.Key + ".md";
		index.AppendLine($"## [{group.Key}]({file})");
		index.AppendLine();
		index.AppendLine("| Type | Kind | Description |");
		index.AppendLine("| --- | --- | --- |");

		var page = new StringBuilder();
		page.AppendLine($"# {group.Key} ({lib.Title})");
		page.AppendLine();
		page.AppendLine($"[Back to the {lib.Title} index](README.md)");
		page.AppendLine();
		page.AppendLine(sourceBlock);
		page.AppendLine();

		foreach (Type type in group)
		{
			string anchor = Anchor(DisplayName(type));
			index.AppendLine($"| [`{DisplayName(type)}`]({file}#{anchor}) | {Kind(type)} | {Cell(docs.Summary(TypeId(type)))} |");
			WriteType(page, type, docs);
		}

		index.AppendLine();
		File.WriteAllText(Path.Combine(libDir, file), page.ToString());
	}

	File.WriteAllText(Path.Combine(libDir, "README.md"), index.ToString());
}

// The F4 console commands: methods marked with SHVDN's [ConsoleCommand("help text")] attribute.
static void WriteConsoleCommands(StringBuilder sb, Type[] types)
{
	sb.AppendLine("## Console commands (F4)");
	sb.AppendLine();
	sb.AppendLine("Every method marked with the `ConsoleCommand` attribute. Type them in the console exactly as shown, with the brackets. String arguments go in double quotes.");
	sb.AppendLine();
	sb.AppendLine("| Command | What it does |");
	sb.AppendLine("| --- | --- |");
	const BindingFlags all = BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Static | BindingFlags.Instance | BindingFlags.DeclaredOnly;
	foreach (var type in types)
	{
		foreach (var m in type.GetMethods(all))
		{
			CustomAttributeData? attr = null;
			try { attr = m.CustomAttributes.FirstOrDefault(a => a.AttributeType.Name == "ConsoleCommand"); } catch { }
			if (attr == null)
				continue;
			string help = attr.ConstructorArguments.Count > 0 ? attr.ConstructorArguments[0].Value as string ?? "" : "";
			string args = string.Join(", ", m.GetParameters().Select(p => $"{TypeName(p.ParameterType)} {p.Name}"));
			sb.AppendLine($"| `{m.Name}({args})` | {Cell(help)} |");
		}
	}
	sb.AppendLine();
}

void WriteType(StringBuilder sb, Type type, XmlDocs docs)
{
	sb.AppendLine($"## {DisplayName(type)}");
	sb.AppendLine();

	string header = $"{Kind(type)} `{type.FullName?.Replace('+', '.')}`";
	if (type.BaseType != null && !type.IsEnum && !type.IsValueType && type.BaseType.FullName != "System.Object")
		header += $" : `{TypeName(type.BaseType)}`";
	var interfaces = type.IsEnum ? Array.Empty<Type>() : type.GetInterfaces().Where(i => i.IsPublic).ToArray();
	if (interfaces.Length > 0)
		header += (header.Contains(" : ") ? ", " : " : ") + string.Join(", ", interfaces.Select(i => $"`{TypeName(i)}`"));
	sb.AppendLine(header);
	sb.AppendLine();

	string? obsolete = Obsolete(type.CustomAttributes);
	if (obsolete != null)
		sb.AppendLine($"> **Obsolete.** {obsolete}").AppendLine();

	string summary = docs.Summary(TypeId(type));
	if (summary.Length > 0)
		sb.AppendLine(summary).AppendLine();
	string remarks = docs.Element(TypeId(type), "remarks");
	if (remarks.Length > 0)
		sb.AppendLine(remarks).AppendLine();

	if (type.IsEnum)
	{
		WriteEnum(sb, type, docs);
		return;
	}

	const BindingFlags flags = BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.Static | BindingFlags.DeclaredOnly;
	var members = new List<(string Section, string Signature, string Id, IList<CustomAttributeData> Attrs)>();

	foreach (var c in type.GetConstructors(flags).Where(c => Visible(c)))
		members.Add(("Constructors", $"{Access(c)}{ShortName(type)}({Params(c)})", MethodId(c), c.CustomAttributes.ToList()));

	foreach (var p in type.GetProperties(flags))
	{
		var get = p.GetMethod; var set = p.SetMethod;
		if (!(get != null && Visible(get)) && !(set != null && Visible(set)))
			continue;
		var anyAccessor = (get != null && Visible(get)) ? get : set!;
		string accessors = (get != null && Visible(get) ? "get; " : "") + (set != null && Visible(set) ? "set; " : "");
		var idx = p.GetIndexParameters();
		string name = idx.Length > 0 ? $"this[{string.Join(", ", idx.Select(i => $"{TypeName(i.ParameterType)} {i.Name}"))}]" : p.Name;
		string id = "P:" + TypeIdName(type) + "." + p.Name + (idx.Length > 0 ? "(" + string.Join(",", idx.Select(i => ParamId(i.ParameterType))) + ")" : "");
		members.Add(("Properties", $"{Access(anyAccessor)}{TypeName(p.PropertyType)} {name} {{ {accessors}}}", id, p.CustomAttributes.ToList()));
	}

	foreach (var f in type.GetFields(flags).Where(f => f.IsPublic || f.IsFamily || f.IsFamilyOrAssembly))
	{
		string mods = (f.IsPublic ? "public " : "protected ") + (f.IsLiteral ? "const " : f.IsStatic ? "static " : "") + (f.IsInitOnly ? "readonly " : "");
		string value = f.IsLiteral ? " = " + FormatConst(f.GetRawConstantValue()) : "";
		members.Add(("Fields", $"{mods}{TypeName(f.FieldType)} {f.Name}{value}", "F:" + TypeIdName(type) + "." + f.Name, f.CustomAttributes.ToList()));
	}

	foreach (var e in type.GetEvents(flags))
	{
		var add = e.AddMethod;
		if (add == null || !Visible(add))
			continue;
		members.Add(("Events", $"{Access(add)}event {TypeName(e.EventHandlerType!)} {e.Name}", "E:" + TypeIdName(type) + "." + e.Name, e.CustomAttributes.ToList()));
	}

	foreach (var m in type.GetMethods(flags).Where(m => Visible(m) && !m.IsSpecialName || (m.IsSpecialName && m.Name.StartsWith("op_") && Visible(m))))
	{
		string generic = m.IsGenericMethodDefinition ? "<" + string.Join(", ", m.GetGenericArguments().Select(a => a.Name)) + ">" : "";
		string mods = Access(m) + (m.IsAbstract && !type.IsInterface ? "abstract " : m.IsVirtual && !m.IsFinal && !type.IsInterface ? "virtual " : "");
		members.Add(("Methods", $"{mods}{TypeName(m.ReturnType)} {m.Name}{generic}({Params(m)})", MethodId(m), m.CustomAttributes.ToList()));
	}

	foreach (var section in new[] { "Constructors", "Properties", "Methods", "Events", "Fields" })
	{
		var list = members.Where(x => x.Section == section).OrderBy(x => x.Signature.Contains(" static ") || x.Signature.StartsWith("public static") ? 1 : 0).ThenBy(x => x.Id).ToList();
		if (list.Count == 0)
			continue;
		sb.AppendLine($"### {section}");
		sb.AppendLine();
		foreach (var item in list)
		{
			sb.AppendLine($"- `{item.Signature}`");
			string? obs = Obsolete(item.Attrs);
			if (obs != null)
				sb.AppendLine($"  - **Obsolete.** {obs}");
			string s = docs.Summary(item.Id);
			if (s.Length > 0)
				sb.AppendLine($"  - {s}");
			foreach (var (pname, ptext) in docs.Params(item.Id))
				sb.AppendLine($"  - `{pname}`: {ptext}");
			string ret = docs.Element(item.Id, "returns");
			if (ret.Length > 0)
				sb.AppendLine($"  - Returns: {ret}");
		}
		sb.AppendLine();
	}
}

void WriteEnum(StringBuilder sb, Type type, XmlDocs docs)
{
	var fields = type.GetFields(BindingFlags.Public | BindingFlags.Static).ToList();
	if (type.FullName == "GTA.Native.Hash")
	{
		sb.AppendLine($"{fields.Count} values, one per native function. Pass one to `Function.Call`. The full list with parameters and descriptions is in the [natives reference](../natives/README.md).");
		sb.AppendLine();
		return;
	}

	bool describe = fields.Count <= 80 && fields.Any(f => docs.Summary("F:" + TypeIdName(type) + "." + f.Name).Length > 0);
	if (fields.Count <= 80)
	{
		sb.AppendLine(describe ? "| Name | Value | Description |" : "| Name | Value |");
		sb.AppendLine(describe ? "| --- | --- | --- |" : "| --- | --- |");
		foreach (var f in fields)
		{
			string row = $"| `{f.Name}` | {FormatConst(f.GetRawConstantValue())} |";
			if (describe)
				row += $" {Cell(docs.Summary("F:" + TypeIdName(type) + "." + f.Name))} |";
			sb.AppendLine(row);
		}
	}
	else
	{
		sb.AppendLine($"{fields.Count} values:");
		sb.AppendLine();
		sb.AppendLine("```text");
		foreach (var f in fields)
			sb.AppendLine($"{f.Name} = {FormatConst(f.GetRawConstantValue())}");
		sb.AppendLine("```");
	}
	sb.AppendLine();
}

static bool Visible(MethodBase m) => m.IsPublic || m.IsFamily || m.IsFamilyOrAssembly;

static string Access(MethodBase m) => (m.IsPublic ? "public " : "protected ") + (m.IsStatic ? "static " : "");

static string Kind(Type t) =>
	t.IsEnum ? "enum" : t.IsInterface ? "interface" : t.IsValueType ? "struct" :
	t.BaseType?.FullName == "System.MulticastDelegate" ? "delegate" :
	t.IsAbstract && t.IsSealed ? "static class" : t.IsAbstract ? "abstract class" : "class";

static string? Obsolete(IEnumerable<CustomAttributeData> attrs)
{
	var a = attrs.FirstOrDefault(x => x.AttributeType.FullName == "System.ObsoleteAttribute");
	if (a == null)
		return null;
	return a.ConstructorArguments.Count > 0 ? a.ConstructorArguments[0].Value as string ?? "" : "";
}

static string FormatConst(object? v) => v switch
{
	null => "null",
	string s => "\"" + s + "\"",
	bool b => b ? "true" : "false",
	_ => Convert.ToString(v, System.Globalization.CultureInfo.InvariantCulture) ?? ""
};

static string Params(MethodBase m) => string.Join(", ", m.GetParameters().Select(p =>
{
	string prefix = "";
	Type t = p.ParameterType;
	if (t.IsByRef) { prefix = p.IsOut ? "out " : "ref "; t = t.GetElementType()!; }
	if (p.CustomAttributes.Any(a => a.AttributeType.FullName == "System.ParamArrayAttribute")) prefix = "params ";
	string def = p.HasDefaultValue ? " = " + FormatConst(p.RawDefaultValue) : "";
	return $"{prefix}{TypeName(t)} {p.Name}{def}";
}));

static string ShortName(Type t)
{
	string n = t.Name;
	int tick = n.IndexOf('`');
	return tick >= 0 ? n[..tick] : n;
}

static string DisplayName(Type t)
{
	string name = ShortName(t);
	if (t.IsGenericTypeDefinition)
		name += "<" + string.Join(", ", t.GetGenericArguments().Where(a => a.DeclaringType == t || t.DeclaringType == null).Select(a => a.Name)) + ">";
	return t.IsNested ? DisplayName(t.DeclaringType!) + "." + name : name;
}

static string TypeName(Type t)
{
	if (t.IsByRef) return TypeName(t.GetElementType()!);
	if (t.IsArray) return TypeName(t.GetElementType()!) + "[" + new string(',', t.GetArrayRank() - 1) + "]";
	if (t.IsPointer) return TypeName(t.GetElementType()!) + "*";
	if (t.IsGenericParameter) return t.Name;
	if (t.IsGenericType && t.GetGenericTypeDefinition().FullName == "System.Nullable`1")
		return TypeName(t.GetGenericArguments()[0]) + "?";
	string? alias = t.FullName switch
	{
		"System.Void" => "void", "System.Boolean" => "bool", "System.Byte" => "byte", "System.SByte" => "sbyte",
		"System.Int16" => "short", "System.UInt16" => "ushort", "System.Int32" => "int", "System.UInt32" => "uint",
		"System.Int64" => "long", "System.UInt64" => "ulong", "System.Single" => "float", "System.Double" => "double",
		"System.String" => "string", "System.Object" => "object", "System.Char" => "char", "System.Decimal" => "decimal",
		_ => null
	};
	if (alias != null) return alias;
	string name = ShortName(t);
	if (t.IsNested) name = TypeName(t.DeclaringType!) + "." + name;
	if (t.IsGenericType)
		name += "<" + string.Join(", ", t.GetGenericArguments().Select(TypeName)) + ">";
	return name;
}

// ---- XML documentation IDs (ECMA-334 annex D format)

static string TypeIdName(Type t) => (t.FullName ?? t.Name).Replace('+', '.');

static string TypeId(Type t) => "T:" + TypeIdName(t);

static string MethodId(MethodBase m)
{
	string name = m.IsConstructor ? (m.IsStatic ? "#cctor" : "#ctor") : m.Name;
	if (m is MethodInfo mi && mi.IsGenericMethodDefinition)
		name += "``" + mi.GetGenericArguments().Length;
	var ps = m.GetParameters();
	string id = "M:" + TypeIdName(m.DeclaringType!) + "." + name;
	if (ps.Length > 0)
		id += "(" + string.Join(",", ps.Select(p => ParamId(p.ParameterType))) + ")";
	if (m.Name is "op_Implicit" or "op_Explicit" && m is MethodInfo conv)
		id += "~" + ParamId(conv.ReturnType);
	return id;
}

static string ParamId(Type t)
{
	if (t.IsByRef) return ParamId(t.GetElementType()!) + "@";
	if (t.IsArray) return ParamId(t.GetElementType()!) + "[]";
	if (t.IsPointer) return ParamId(t.GetElementType()!) + "*";
	if (t.IsGenericParameter) return (t.DeclaringMethod != null ? "``" : "`") + t.GenericParameterPosition;
	if (t.IsGenericType)
	{
		string def = (t.GetGenericTypeDefinition().FullName ?? t.Name).Replace('+', '.');
		def = def[..def.IndexOf('`')];
		return def + "{" + string.Join(",", t.GetGenericArguments().Select(ParamId)) + "}";
	}
	return (t.FullName ?? t.Name).Replace('+', '.');
}

static string Anchor(string heading) =>
	Regex.Replace(heading.ToLowerInvariant(), @"[^a-z0-9 _-]", "").Replace(' ', '-');

static string Cell(string s) => s.Replace("|", "\\|").Replace("\n", " ");

// ---------------------------------------------------------------- natives

Dictionary<string, NativeInfo> WriteNatives(string jsonPath)
{
	Console.WriteLine("Reading NativeDB");
	using var doc = JsonDocument.Parse(File.ReadAllText(jsonPath));
	string natDir = Path.Combine(refDir, "natives");
	if (Directory.Exists(natDir))
		Directory.Delete(natDir, true);
	Directory.CreateDirectory(natDir);

	var byName = new Dictionary<string, NativeInfo>(StringComparer.Ordinal);
	var index = new StringBuilder();
	index.AppendLine("# Native functions");
	index.AppendLine();
	string nativeSourceBlock =
		$"> **Source:** `natives.json` from [alloc8or/gta5-nativedb-data](https://github.com/alloc8or/gta5-nativedb-data), {nativesSource}. It is the data behind https://nativedb.dotindustries.dev.  \n" +
		"> **Method:** downloaded by `ModDevelopment/tools/ApiDocGen` and converted to Markdown. Names, parameters and descriptions are community research, not from Rockstar or from the game files. The hashes are what the game uses to identify each native.";
	index.AppendLine("Every native function in the game, grouped by namespace. Re-run the generator to refresh it.");
	index.AppendLine();
	index.AppendLine(nativeSourceBlock);
	index.AppendLine();
	index.AppendLine("How to call them from C#, Lua and C++: [`../../guides/05-Natives.md`](../../guides/05-Natives.md). The descriptions are community research, so treat them as a guide and test in game. `build` is the first game build the native exists in; this install is build 3725.");
	index.AppendLine();
	index.AppendLine("| Namespace | Natives |");
	index.AppendLine("| --- | --- |");

	// C++ wrappers for .asi mods: one inline function per native, grouped in a namespace per native namespace.
	var cpp = new StringBuilder();
	cpp.AppendLine("// Every native function as a C++ wrapper. Generated by ModDevelopment/tools/ApiDocGen from NativeDB:");
	cpp.AppendLine("// don't edit, re-run the generator. Descriptions: ModDevelopment/docs/reference/natives/<NAMESPACE>.md");
	cpp.AppendLine($"// Source: natives.json from github.com/alloc8or/gta5-nativedb-data, {nativesSource.Replace("`", "")}.");
	cpp.AppendLine();
	cpp.AppendLine("#pragma once");
	cpp.AppendLine();
	cpp.AppendLine("#include \"nativeCaller.h\"");

	int total = 0;
	foreach (var ns in doc.RootElement.EnumerateObject().OrderBy(n => n.Name))
	{
		cpp.AppendLine();
		cpp.AppendLine($"namespace {ns.Name}");
		cpp.AppendLine("{");
		foreach (var native in ns.Value.EnumerateObject().OrderBy(n => n.Value.GetProperty("name").GetString()))
		{
			var v = native.Value;
			string name = v.GetProperty("name").GetString()!;
			string ret = v.TryGetProperty("return_type", out var r) ? r.GetString()! : "void";
			var used = new HashSet<string>();
			var ps = (v.TryGetProperty("params", out var pa) ? pa.EnumerateArray() : default).Select((p, i) =>
			{
				string pn = p.GetProperty("name").GetString()!;
				if (!used.Add(pn)) pn += "_" + i;
				return (Type: p.GetProperty("type").GetString()!, Name: pn);
			}).ToList();
			string args = string.Join(", ", ps.Select(p => $"{p.Type} {p.Name}"));
			string call = string.Join("", ps.Select(p => ", " + p.Name));
			string body = ret == "void" ? $"invoke<void>({native.Name}{call});" : $"return invoke<{ret}>({native.Name}{call});";
			cpp.AppendLine($"\tinline {ret} {name}({args}) {{ {body} }}");
		}
		cpp.AppendLine("}");
	}
	string cppPath = Path.Combine(devDir, "cpp", "ShvSdk", "include", "natives.hpp");
	Directory.CreateDirectory(Path.GetDirectoryName(cppPath)!);
	File.WriteAllText(cppPath, cpp.ToString());

	foreach (var ns in doc.RootElement.EnumerateObject().OrderBy(n => n.Name))
	{
		var page = new StringBuilder();
		page.AppendLine($"# {ns.Name} natives");
		page.AppendLine();
		page.AppendLine("[Back to the natives index](README.md)");
		page.AppendLine();
		page.AppendLine(nativeSourceBlock);
		page.AppendLine();
		int count = 0;

		foreach (var native in ns.Value.EnumerateObject().OrderBy(n => n.Value.GetProperty("name").GetString()))
		{
			var v = native.Value;
			string name = v.GetProperty("name").GetString()!;
			string ret = v.TryGetProperty("return_type", out var r) ? r.GetString()! : "void";
			var ps = v.TryGetProperty("params", out var pa) ? pa.EnumerateArray().Select(p => $"{p.GetProperty("type").GetString()} {p.GetProperty("name").GetString()}").ToList() : new List<string>();
			string comment = v.TryGetProperty("comment", out var c) ? c.GetString() ?? "" : "";
			string build = v.TryGetProperty("build", out var b) ? b.GetString() ?? "" : "";
			var oldNames = v.TryGetProperty("old_names", out var o) ? o.EnumerateArray().Select(x => x.GetString()!).ToList() : new List<string>();

			var info = new NativeInfo(ns.Name, name, native.Name);
			byName.TryAdd(name, info);
			foreach (string old in oldNames)
				byName.TryAdd(old, info);

			page.AppendLine($"## {name}");
			page.AppendLine();
			page.AppendLine("```c");
			page.AppendLine($"{ret} {name}({string.Join(", ", ps)})  // {native.Name}");
			page.AppendLine("```");
			page.AppendLine();
			var meta = new List<string>();
			if (build.Length > 0) meta.Add($"build {build}");
			if (oldNames.Count > 0) meta.Add("old names: " + string.Join(", ", oldNames.Select(x => $"`{x}`")));
			if (meta.Count > 0)
				page.AppendLine(string.Join(" · ", meta)).AppendLine();
			if (comment.Length > 0)
			{
				foreach (string line in comment.Replace("\r", "").Split('\n'))
					page.AppendLine("> " + line);
				page.AppendLine();
			}
			count++;
		}

		File.WriteAllText(Path.Combine(natDir, ns.Name + ".md"), page.ToString());
		index.AppendLine($"| [{ns.Name}]({ns.Name}.md) | {count} |");
		total += count;
	}

	index.AppendLine();
	index.AppendLine($"{total} natives in total.");
	File.WriteAllText(Path.Combine(natDir, "README.md"), index.ToString());
	return byName;
}

// ---------------------------------------------------------------- Lua natives in LUA.asi

void WriteLuaNatives(string asiPath, Dictionary<string, NativeInfo> natives)
{
	Console.WriteLine("Reading LUA.asi");
	string[] namespaces = { "PLAYER", "ENTITY", "PED", "VEHICLE", "OBJECT", "AI", "GAMEPLAY", "AUDIO", "CUTSCENE", "INTERIOR", "CAM", "WEAPON", "ITEMSET", "STREAMING", "SCRIPT", "UI", "GRAPHICS", "STATS", "BRAIN", "MOBILE", "APP", "TIME", "PATHFIND", "CONTROLS", "DATAFILE", "FIRE", "DECORATOR", "NETWORK", "NETWORKCASH", "DLC1", "DLC2", "SYSTEM", "ZONE", "ROPE", "WATER", "WORLDPROBE", "UNK", "UNK_SC", "UNK1", "UNK2", "UNK3" };
	var nsSet = new HashSet<string>(namespaces);
	var isNative = new Regex(@"^_?[A-Z0-9][A-Z0-9_]+$|^_0x[0-9A-F]{16}$");

	// The tolua bindings store each namespace name followed by its function names as zero-terminated strings.
	// The table is split into two blocks: PLAYER to most of NETWORK, and elsewhere the end of NETWORK followed by
	// NETWORKCASH, DLC1, DLC2, SYSTEM, DECORATOR and the UNK namespaces. The second block is interleaved with
	// "#ferror in function ..." messages, which are skipped.
	byte[] bytes = File.ReadAllBytes(asiPath);
	var strings = new List<string>();
	var cur = new StringBuilder();
	foreach (byte by in bytes)
	{
		if (by >= 0x20 && by < 0x7f) { cur.Append((char)by); continue; }
		if (cur.Length >= 2 && !cur.ToString().StartsWith("#ferror")) strings.Add(cur.ToString());
		cur.Clear();
	}

	var regions = new List<List<(string Ns, List<string> Names)>>();
	var tails = new List<List<string>>();
	for (int i = 0; i < strings.Count; i++)
	{
		if (!nsSet.Contains(strings[i]) || i + 1 >= strings.Count || !isNative.IsMatch(strings[i + 1]) || nsSet.Contains(strings[i + 1]))
			continue;

		// Native names right before a block continue the namespace that ended the previous block.
		var tail = new List<string>();
		for (int j = i - 1, back = 0; j >= 0 && back < 3; j--)
		{
			if (isNative.IsMatch(strings[j]) && !nsSet.Contains(strings[j])) { tail.Insert(0, strings[j]); back = 0; }
			else back++;
		}

		var region = new List<(string Ns, List<string> Names)>();
		int misses = 0;
		for (; i < strings.Count && misses < 5; i++)
		{
			string s = strings[i];
			if (nsSet.Contains(s) && (region.Count == 0 || region[^1].Ns != s)) { region.Add((s, new List<string>())); misses = 0; }
			else if (isNative.IsMatch(s)) { region[^1].Names.Add(s); misses = 0; }
			else misses++;
		}

		// Ignore stray matches: a real block has several namespaces or many names.
		if (region.Count >= 2 || region.Sum(g => g.Names.Count) >= 20)
		{
			regions.Add(region);
			tails.Add(tail);
		}
	}

	// The table is the largest block. It starts partway through (at NETWORKCASH), so list it from PLAYER, and give
	// the native names just before the block to the namespace that ends it (NETWORK).
	int main = regions.Count == 0 ? -1 : regions.IndexOf(regions.MaxBy(r => r.Sum(g => g.Names.Count))!);
	int player = main < 0 ? -1 : regions[main].FindIndex(g => g.Ns == "PLAYER");
	if (player < 0)
	{
		Console.WriteLine("  Native table not found in LUA.asi, skipped.");
		return;
	}

	var groups = regions[main].Skip(player).Concat(regions[main].Take(player)).ToList();
	groups[regions[main].Count - player - 1].Names.AddRange(tails[main]);

	string path = Path.Combine(refDir, "Lua-Natives.md");
	var sb = new StringBuilder();
	sb.AppendLine("# Natives available in the Lua plugin (LUA.asi)");
	sb.AppendLine();
	sb.AppendLine($"> **Source:** {Provenance(asiPath)}  ");
	sb.AppendLine("> **Method:** the printable strings in the binary were extracted by `ModDevelopment/tools/ApiDocGen`. The plugin's tolua bindings store each namespace name followed by its function names, so the namespace grouping and the names are exact. Parameters and argument handling are **not** in the strings: for those, see the linked NativeDB entry and test in game.  ");
	sb.AppendLine("> **Current names:** matched to NativeDB by name, old name or hash (see [natives/README.md](natives/README.md) for that source).");
	sb.AppendLine();
	sb.AppendLine("Lua Plugin by Headscript (2015). Call them as `NAMESPACE.NAME(args)`, for example `PLAYER.PLAYER_PED_ID()`.");
	sb.AppendLine();
	sb.AppendLine("LUA.asi was built in 2015, so it uses the **old namespace and function names**. The \"Current name\" column gives today's NativeDB name, which you need when you look a native up. Names starting with `_0x` had no name in 2015. A native added to the game after 2015 can't be called from this plugin.");
	sb.AppendLine();
	sb.AppendLine("Lua namespace to current namespace: `GAMEPLAY` is `MISC`, `UI` is `HUD`, `CONTROLS` is `PAD`, `AI` is `TASK`, `TIME` is `CLOCK`, `WORLDPROBE` is `SHAPETEST`, `CAM` is `CAMERA`, `PATHFIND` is `PATH`, `APP` is `APPS`, `ITEMSET` is `ITEMSETS`, `NETWORKCASH` is `MONEY`, `SYSTEM` is `BUILTIN`. `UNK`, `UNK1` to `UNK3`, `UNK_SC`, `DLC1` and `DLC2` were split up.");
	sb.AppendLine();

	int total = groups.Sum(g => g.Names.Count);
	sb.AppendLine($"{total} natives in {groups.Count} namespaces: " + string.Join(", ", groups.Select(g => $"[{g.Ns}](#{g.Ns.ToLowerInvariant()}) ({g.Names.Count})")));
	sb.AppendLine();

	foreach (var (ns, names) in groups)
	{
		sb.AppendLine($"## {ns}");
		sb.AppendLine();
		sb.AppendLine("| Lua call | Current name | Reference |");
		sb.AppendLine("| --- | --- | --- |");
		foreach (string n in names)
		{
			string current = "", link = "";
			string lookup = n;
			if (!natives.TryGetValue(lookup, out var info) && n.StartsWith("_0x"))
				info = natives.Values.FirstOrDefault(x => x.Hash.Equals("0x" + n[3..], StringComparison.OrdinalIgnoreCase));
			// Unofficial 2015 names started with "_"; some have since been confirmed under the same name.
			if (info == null && n.StartsWith('_') && !n.StartsWith("_0x"))
				natives.TryGetValue(n[1..], out info);
			if (info != null)
			{
				current = $"`{info.Namespace}.{info.Name}`";
				link = $"[{info.Namespace}](natives/{info.Namespace}.md#{info.Name.ToLowerInvariant()})";
			}
			sb.AppendLine($"| `{ns}.{n}` | {current} | {link} |");
		}
		sb.AppendLine();
	}

	File.WriteAllText(path, sb.ToString());
	Console.WriteLine($"  {total} Lua natives in {groups.Count} namespaces.");
}

// ---------------------------------------------------------------- inventory of installed binaries and settings

void WriteInventory()
{
	Console.WriteLine("Scanning installed files");

	// What each known file is. Facts in the other columns come from the files themselves.
	var roles = new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase)
	{
		["ScriptHookV.dll"] = "Native-call hook every mod depends on (Alexander Blade). **C++ API**: [`cpp/ShvSdk/include/main.h`](../../cpp/ShvSdk/include/main.h)",
		["dinput8.dll"] = "ASI loader for GTA V Legacy (Alexander Blade, 2015). Loads every `*.asi` in the game folder and writes `asiloader.log`",
		["xinput1_4.dll"] = "ASI loader for GTA V **Enhanced** (its strings name `GTA5_Enhanced.exe`). Not active here: `asiloader.log` only shows the Legacy loader. A leftover that does nothing in this install",
		["ScriptHookVDotNet.asi"] = "SHVDN runtime: hosts .NET and loads `scripts/*.dll` and `*.cs`. Its file version says 3.6.0.0 but its assembly version is 3.7.0.189, matching the API DLLs. **Reference**: [SHVDN-Runtime](SHVDN-Runtime/README.md) (console commands)",
		["ScriptHookVDotNet2.dll"] = "SHVDN v2 API (legacy). **Reference**: [SHVDN2](SHVDN2/README.md)",
		["ScriptHookVDotNet3.dll"] = "SHVDN v3 API. **Reference**: [SHVDN3](SHVDN3/README.md)",
		["LUA.asi"] = "Lua 5.2 plugin by Headscript. **Reference**: [Lua-Natives.md](Lua-Natives.md), guide 06",
		["Menyoo.asi"] = "Menyoo trainer. Finished mod, no API",
		["TrainerV.asi"] = "TrainerV trainer. Its 5 exports are internal values, not an API",
		["OpenIV.asi"] = "Redirects archive reads to `Mods/`. No API",
		["openCameraV.asi"] = "Camera mod. No API",
		["NoEditorRestrictions.asi"] = "Rockstar Editor tweaks. No API",
		["HeapAdjuster.asi"] = "Raises the game's memory heap. No API",
		["PackfileLimitAdjuster.asi"] = "Raises the archive limit. No API",
		["WeaponLimitsAdjuster.asi"] = "Raises weapon limits. No API",
		["fwBoxStreamerVariable_DecalsLimit-Patch.asi"] = "Raises decal and streamer limits. No API",
		["scripts/LemonUI.SHVDN3.dll"] = "Menu library for SHVDN v3. **Reference**: [LemonUI](LemonUI/README.md)",
		["scripts/NativeUI.dll"] = "Menu library for SHVDN v2 (legacy). **Reference**: [NativeUI](NativeUI/README.md)",
		["scripts/iFruitAddon2.dll"] = "Phone contacts library. **Reference**: [iFruitAddon2](iFruitAddon2/README.md)",
		["scripts/ClearScript.dll"] = "Microsoft ClearScript (JavaScript engine for .NET). Needed by MapEditor. Not useful for game modding",
		["scripts/ModGuide.dll"] = "Our in-game mod guide. Source: `ModDevelopment/ModGuide/`",
		["scripts/Better Chases+.dll"] = "Police chase mod. No API",
		["scripts/Cop_Arrest.dll"] = "Arrest mod. No API",
		["scripts/Disarm.dll"] = "Disarm mod. No API",
		["scripts/ImmersifyII.dll"] = "World and NPC behaviour mod. No API",
		["scripts/MapEditor.dll"] = "Map editor. No API",
		["scripts/Stance.dll"] = "Stance mod. No API",
	};
	string[] gameFiles = { "bink2w64.dll", "d3dcompiler_46.dll", "d3dcsx_46.dll", "GFSDK_ShadowLib.win64.dll", "GFSDK_TXAA.win64.dll", "GFSDK_TXAA_AlphaResolve.win64.dll", "GPUPerfAPIDX11-x64.dll", "NvPmApi.Core.win64.dll", "fvad.dll", "libtox.dll", "opus.dll", "opusenc.dll", "libcurl.dll", "XCurl.dll", "zlib1.dll" };
	string[] launcherFiles = { "socialclub.dll", "orig_socialclub.dll", "launc.dll", "steam_api64.dll" };
	var fileNotes = new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase)
	{
		["fvad.dll"] = "WebRTC voice activity detection (exports `WebRtcSpl_*`)",
		["libtox.dll"] = "audio library (exports `tox_add_audio*`); exact purpose not confirmed",
		["opus.dll"] = "Opus audio codec (exports `opus_*`)",
		["opusenc.dll"] = "Opus file encoder (exports `ope_*`)",
		["GFSDK_ShadowLib.win64.dll"] = "NVIDIA ShadowWorks (shadow quality options)",
		["GFSDK_TXAA.win64.dll"] = "NVIDIA TXAA anti-aliasing",
		["GFSDK_TXAA_AlphaResolve.win64.dll"] = "NVIDIA TXAA anti-aliasing",
		["launc.dll"] = "part of this install's launcher setup (one export, `launc`); not identified further. Don't touch",
		["socialclub.dll"] = "Social Club layer used by this install (the original is orig_socialclub.dll)",
		["steam_api64.dll"] = "Steam API layer used by this install (original: steam_api64.dll.orig; settings in steam_settings/)",
	};

	// API each .NET script resolved to, from the last game session's SHVDN log.
	var resolved = new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase);
	string logPath = Path.Combine(gameDir, "ScriptHookVDotNet.log");
	if (File.Exists(logPath))
	{
		foreach (Match m in Regex.Matches(File.ReadAllText(logPath), @"Found \d+ script\(s\) in (.+?) resolved to API version ([\d.]+)"))
			resolved[m.Groups[1].Value] = m.Groups[2].Value;
		foreach (Match m in Regex.Matches(File.ReadAllText(logPath), @"Found no compatible scripts in (.+?) but loaded as a library"))
			resolved[m.Groups[1].Value] = "library only";
	}

	var files = Directory.GetFiles(gameDir, "*.asi").Concat(Directory.GetFiles(gameDir, "*.dll"))
		.Concat(Directory.GetFiles(Path.Combine(gameDir, "scripts"), "*.dll"))
		.OrderBy(f => Path.GetDirectoryName(f)!.Length).ThenBy(f => Path.GetFileName(f), StringComparer.OrdinalIgnoreCase);

	var sb = new StringBuilder();
	sb.AppendLine("# Installed binaries and settings files");
	sb.AppendLine();
	sb.AppendLine("> **Source:** every `.asi` and `.dll` in the game folder and in `scripts/`, and every settings file, scanned by `ModDevelopment/tools/ApiDocGen`.  ");
	sb.AppendLine("> **Method:** version fields and SHA-256 from each file; export counts from the PE export table; .NET references from the assembly metadata; \"SHVDN API\" from the last `ScriptHookVDotNet.log` (the game session before the scan). The \"What it is\" column is written by hand in the generator.");
	sb.AppendLine();
	sb.AppendLine("## Mods, hooks and libraries");
	sb.AppendLine();
	sb.AppendLine("| File | Kind | Version | Exports | .NET references | SHVDN API | What it is |");
	sb.AppendLine("| --- | --- | --- | --- | --- | --- | --- |");
	var other = new List<string>();
	foreach (string path in files)
	{
		string rel = Rel(path);
		string name = Path.GetFileName(path);
		if (gameFiles.Contains(name, StringComparer.OrdinalIgnoreCase) || launcherFiles.Contains(name, StringComparer.OrdinalIgnoreCase))
		{
			other.Add(path);
			continue;
		}
		var (isNet, exports, refs) = InspectPe(path);
		var v = System.Diagnostics.FileVersionInfo.GetVersionInfo(path);
		string role = roles.TryGetValue(rel, out var r) ? r : roles.TryGetValue(name, out r) ? r : "Not identified";
		string api = resolved.TryGetValue(name, out var a) ? a : "";
		sb.AppendLine($"| `{rel}` | {(isNet ? ".NET" : "native")} | {Cell(v.FileVersion?.Trim() ?? "")} | {exports} | {Cell(refs)} | {api} | {role} |");
	}
	sb.AppendLine();
	sb.AppendLine("Mods built against `ScriptHookVDotNet` 0.0.0.0 (the API name before SHVDN 2.10) run on the v2 API: the log shows them resolved to 2.11.6.");
	sb.AppendLine();
	sb.AppendLine("## Game and launcher files (not mods)");
	sb.AppendLine();
	sb.AppendLine("Part of GTA V, its launcher or its platform layer. Nothing here is for mods to call. Don't change the launcher files (see `CLAUDE.md`).");
	sb.AppendLine();
	sb.AppendLine("| File | Version | Description |");
	sb.AppendLine("| --- | --- | --- |");
	foreach (string path in other)
	{
		var v = System.Diagnostics.FileVersionInfo.GetVersionInfo(path);
		string kind = launcherFiles.Contains(Path.GetFileName(path), StringComparer.OrdinalIgnoreCase) ? "launcher / platform" : "game";
		sb.AppendLine($"| `{Rel(path)}` | {Cell(v.FileVersion?.Trim() ?? "")} | {kind}: {Cell(fileNotes.TryGetValue(Path.GetFileName(path), out var note) ? note : (v.FileDescription ?? "").Trim())} |");
	}
	sb.AppendLine();

	sb.AppendLine("## Settings files");
	sb.AppendLine();
	sb.AppendLine("How to edit each one: `docs/mods_info/SETTINGS.md` in the game folder.");
	sb.AppendLine();
	sb.AppendLine("| File | Size |");
	sb.AppendLine("| --- | --- |");
	var settings = Directory.GetFiles(gameDir, "*.ini").Concat(Directory.GetFiles(gameDir, "*.toml"))
		.Concat(Directory.GetFiles(Path.Combine(gameDir, "scripts"), "*.ini", SearchOption.AllDirectories))
		.Concat(new[] { Path.Combine(gameDir, "menyooStuff", "menyooConfig.ini"), Path.Combine(gameDir, "scripts", "BetterChasesConfig.xml"), Path.Combine(gameDir, "scripts", "MapEditor.xml"), Path.Combine(gameDir, "scripts", "ModGuide.xml") })
		.Where(File.Exists).Distinct().OrderBy(f => f, StringComparer.OrdinalIgnoreCase);
	foreach (string path in settings)
		sb.AppendLine($"| `{Rel(path)}` | {new FileInfo(path).Length:N0} bytes |");
	sb.AppendLine();

	File.WriteAllText(Path.Combine(refDir, "Installed-Files.md"), sb.ToString());
}

// Whether a PE file is a .NET assembly, how many named exports it has, and its non-framework assembly references.
static (bool IsNet, int Exports, string Refs) InspectPe(string path)
{
	using var stream = File.OpenRead(path);
	using var pe = new System.Reflection.PortableExecutable.PEReader(stream);
	int exports = 0;
	var dir = pe.PEHeaders.PEHeader!.ExportTableDirectory;
	if (dir.Size > 0)
	{
		var reader = pe.GetSectionData(dir.RelativeVirtualAddress).GetReader();
		reader.Offset = 24; // NumberOfNames in IMAGE_EXPORT_DIRECTORY
		exports = reader.ReadInt32();
	}
	if (!pe.HasMetadata)
		return (false, exports, "");
	System.Reflection.Metadata.MetadataReader md;
	try { md = System.Reflection.Metadata.PEReaderExtensions.GetMetadataReader(pe); }
	catch (BadImageFormatException) { return (true, exports, "unreadable: nonstandard (likely obfuscated) metadata"); }
	var refs = md.AssemblyReferences.Select(h => md.GetAssemblyReference(h))
		.Select(a => (Name: md.GetString(a.Name), a.Version))
		.Where(a => !Regex.IsMatch(a.Name, @"^(mscorlib|System(\..*)?|Microsoft\.CSharp|netstandard|WindowsBase)$"))
		.Select(a => $"{a.Name} {a.Version}");
	return (true, exports, string.Join(", ", refs));
}

// DllPath is what gets loaded; SourcePath, when set, is the installed file it was copied from (for provenance).
record Library(string Folder, string Title, string DllPath, string XmlPath, string DocsSource, string Note, string? SourcePath = null);

record NativeInfo(string Namespace, string Name, string Hash);

sealed class XmlDocs
{
	private readonly Dictionary<string, XElement> members = new();

	public XmlDocs(string path)
	{
		if (!File.Exists(path))
			return;
		foreach (var m in XDocument.Load(path).Descendants("member"))
		{
			string? name = (string?)m.Attribute("name");
			if (name != null)
				members.TryAdd(name, m);
		}
	}

	private XElement? Find(string id)
	{
		if (members.TryGetValue(id, out var m))
			return m;
		// Fall back to a unique match on the name alone, for overloads whose ID format differs slightly.
		string prefix = id.Contains('(') ? id[..id.IndexOf('(')] : id;
		var candidates = members.Keys.Where(k => k == prefix || k.StartsWith(prefix + "(")).Take(2).ToList();
		return candidates.Count == 1 && !id.Contains('(') == !candidates[0].Contains('(') ? members[candidates[0]] : null;
	}

	public string Summary(string id) => Element(id, "summary");

	public string Element(string id, string element)
	{
		var e = Find(id)?.Element(element);
		return e == null ? "" : Text(e);
	}

	public IEnumerable<(string, string)> Params(string id)
	{
		var m = Find(id);
		if (m == null)
			yield break;
		foreach (var p in m.Elements("param"))
		{
			string text = Text(p);
			if (text.Length > 0)
				yield return ((string?)p.Attribute("name") ?? "", text);
		}
	}

	private static string Text(XElement e)
	{
		var sb = new StringBuilder();
		foreach (var node in e.Nodes())
		{
			if (node is XText t)
				sb.Append(t.Value);
			else if (node is XElement x)
			{
				switch (x.Name.LocalName)
				{
					case "see":
					case "seealso":
						string cref = (string?)x.Attribute("cref") ?? (string?)x.Attribute("langword") ?? (string?)x.Attribute("href") ?? x.Value;
						cref = Regex.Replace(cref, @"^[A-Z]:", "");
						cref = Regex.Replace(cref, @"\(.*$", "");
						sb.Append('`').Append(cref.Split('.').Last()).Append('`');
						break;
					case "paramref":
					case "typeparamref":
						sb.Append('`').Append((string?)x.Attribute("name")).Append('`');
						break;
					case "c":
						sb.Append('`').Append(x.Value).Append('`');
						break;
					case "para":
					case "br":
						sb.Append(' ').Append(Text(x)).Append(' ');
						break;
					default:
						sb.Append(Text(x));
						break;
				}
			}
		}
		return Regex.Replace(sb.ToString(), @"\s+", " ").Trim();
	}
}
