namespace CruelMastersOnlineOffline;

public class ContactSaveData
{
	public bool SimeonCutscene;

	public bool TrevorCutscene;

	public bool LesterCutscene;

	// Added: set when Gerald's first mission (LTM) is passed. Simeon's intro call now unlocks on this flag
	// as well as at rank 3. Older saves have no element and read as false.
	public bool GeraldFirstMissionDone;
}
