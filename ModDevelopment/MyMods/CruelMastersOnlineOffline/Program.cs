using System;

namespace CruelMastersOnlineOffline;

internal class Program
{
	private static void Main(string[] args)
	{
		SoundPlayerEx soundPlayerEx = new SoundPlayerEx("c:\\temp\\sorry_dave.wav");
		soundPlayerEx.SoundFinished += player_SoundFinished;
		Console.WriteLine("Press any key to play the sound");
		Console.ReadKey(intercept: true);
		soundPlayerEx.PlayAsync();
		Console.WriteLine("Press a key to stop the sound.");
		Console.ReadKey(intercept: true);
		soundPlayerEx.Stop();
		Console.WriteLine("Press any key to continue");
	}

	private static void player_SoundFinished(object sender, EventArgs e)
	{
		Console.WriteLine("The sound finished playing");
	}
}
