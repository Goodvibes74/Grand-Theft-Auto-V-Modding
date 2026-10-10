using System.Collections.Generic;
using System.IO;

namespace CruelMastersOnlineOffline;

public class MPSaveData
{
	public List<ContactSaveData> ContactSaveDatas = new List<ContactSaveData>();

	public List<FirstDeathSaveData> FirstDeathSaveDatas = new List<FirstDeathSaveData>();

	public List<PIStyleSaveData> PIStyleSaveDatas = new List<PIStyleSaveData>();

	public static void SAVE_DATA(MPSaveData newsavadata, string fileName)
	{
		XMLSerializer.SaveToXML(newsavadata, "scripts\\CruelMastersOnlineOfflineAssets\\Save Data\\" + fileName + ".xml");
	}

	public static MPSaveData GET_MAIN_SAVE_DATA(string fileName)
	{
		if (File.Exists("scripts\\CruelMastersOnlineOfflineAssets\\Save Data\\" + fileName + ".xml"))
		{
			return XMLSerializer.DeserializeXML<MPSaveData>("scripts\\CruelMastersOnlineOfflineAssets\\Save Data\\" + fileName + ".xml");
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
