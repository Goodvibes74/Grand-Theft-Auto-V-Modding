using System.Collections.Generic;
using System.IO;

namespace CruelMastersOnlineOffline;

public class MPSaveData
{
	public List<ContactSaveData> ContactSaveDatas = new List<ContactSaveData>();

	public List<FirstDeathSaveData> FirstDeathSaveDatas = new List<FirstDeathSaveData>();

	public List<PIStyleSaveData> PIStyleSaveDatas = new List<PIStyleSaveData>();

	// Patched: MPSimeonCMS read and deserialized "Save Data.xml" on every tick once rank 3 was reached. Saves are
	// now cached in memory; SAVE_DATA updates the cache, so readers always see the latest written data.
	private static readonly Dictionary<string, MPSaveData> Cache = new Dictionary<string, MPSaveData>();

	public static void SAVE_DATA(MPSaveData newsavadata, string fileName)
	{
		XMLSerializer.SaveToXML(newsavadata, "scripts\\CruelMastersOnlineOfflineAssets\\Save Data\\" + fileName + ".xml");
		Cache[fileName] = newsavadata;
	}

	public static MPSaveData GET_MAIN_SAVE_DATA(string fileName)
	{
		if (Cache.TryGetValue(fileName, out MPSaveData cached))
		{
			return cached;
		}
		if (File.Exists("scripts\\CruelMastersOnlineOfflineAssets\\Save Data\\" + fileName + ".xml"))
		{
			MPSaveData loaded = XMLSerializer.DeserializeXML<MPSaveData>("scripts\\CruelMastersOnlineOfflineAssets\\Save Data\\" + fileName + ".xml");
			if (loaded != null)
			{
				Cache[fileName] = loaded;
			}
			return loaded;
		}
		return null;
	}

	public static MPSaveData CREATE_FRESH_SAVE_DATA()
	{
		MPSaveData mPSaveData = new MPSaveData();
		ContactSaveData contactSaveData = new ContactSaveData();
		contactSaveData.SimeonCutscene = false;
		contactSaveData.TrevorCutscene = false;
		contactSaveData.LesterCutscene = false;
		mPSaveData.ContactSaveDatas.Add(contactSaveData);
		FirstDeathSaveData firstDeathSaveData = new FirstDeathSaveData();
		firstDeathSaveData.FirstDeathCutscene = false;
		mPSaveData.FirstDeathSaveDatas.Add(firstDeathSaveData);
		return mPSaveData;
	}
}
