using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Xml.Serialization;

namespace CruelMastersOnlineOffline;

public static class XMLSerializer
{
	public static T DeserializeXML<T>(string fileName) where T : class
	{
		XmlSerializer xmlSerializer = new XmlSerializer(typeof(T));
		StreamReader streamReader = new StreamReader(fileName);
		T result = xmlSerializer.Deserialize(streamReader) as T;
		streamReader.Close();
		return result;
	}

	public static IEnumerable<T> DeserializeXML<T>(string fileName, Predicate<T> predicate) where T : class
	{
		return from t in DeserializeXML<List<T>>(fileName)
			where predicate(t)
			select t;
	}

	public static void SaveToXML<T>(T obj, string fileName) where T : class
	{
		XmlSerializer xmlSerializer = new XmlSerializer(typeof(T));
		StreamWriter streamWriter = new StreamWriter(fileName);
		xmlSerializer.Serialize(streamWriter, obj);
		streamWriter.Close();
	}
}
