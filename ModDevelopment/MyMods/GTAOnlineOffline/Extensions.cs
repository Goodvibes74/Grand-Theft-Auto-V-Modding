using NAudio.Wave;

public static class Extensions
{
	private static WaveOutEvent output = new WaveOutEvent();

	private static WaveOutEvent output2 = new WaveOutEvent();

	private static WaveOut waveOut;

	private static WaveOut waveOut2;

	private static WaveOut waveOut3;

	private static WaveOut waveOut4;

	private static WaveOut waveOut5;

	private static WaveOut waveOut6;

	private static WaveOut waveOut7;

	private static WaveOut waveOut8;

	public static void PlayLooping(this WaveFileReader reader)
	{
		if (waveOut == null)
		{
			LoopStream waveProvider = new LoopStream(reader);
			waveOut = new WaveOut();
			waveOut.Init(waveProvider);
			waveOut.Play();
		}
		else
		{
			waveOut.Stop();
			waveOut.Dispose();
			waveOut = null;
		}
	}

	public static void PlayLooping2(this WaveFileReader reader2)
	{
		if (waveOut2 == null)
		{
			LoopStream waveProvider = new LoopStream(reader2);
			waveOut2 = new WaveOut();
			waveOut2.Init(waveProvider);
			waveOut2.Play();
		}
		else
		{
			waveOut2.Stop();
			waveOut2.Dispose();
			waveOut2 = null;
		}
	}

	public static void PlayLooping3(this WaveFileReader reader3)
	{
		if (waveOut3 == null)
		{
			LoopStream waveProvider = new LoopStream(reader3);
			waveOut3 = new WaveOut();
			waveOut3.Init(waveProvider);
			waveOut3.Play();
		}
		else
		{
			waveOut3.Stop();
			waveOut3.Dispose();
			waveOut3 = null;
		}
	}

	public static void PlayLooping4(this WaveFileReader reader4)
	{
		if (waveOut4 == null)
		{
			LoopStream waveProvider = new LoopStream(reader4);
			waveOut4 = new WaveOut();
			waveOut4.Init(waveProvider);
			waveOut4.Play();
		}
		else
		{
			waveOut4.Stop();
			waveOut4.Dispose();
			waveOut4 = null;
		}
	}

	public static void PlayLooping5(this WaveFileReader reader5)
	{
		if (waveOut5 == null)
		{
			LoopStream waveProvider = new LoopStream(reader5);
			waveOut5 = new WaveOut();
			waveOut5.Init(waveProvider);
			waveOut5.Play();
		}
		else
		{
			waveOut5.Stop();
			waveOut5.Dispose();
			waveOut5 = null;
		}
	}

	public static void PlayLooping6(this WaveFileReader reader6)
	{
		if (waveOut6 == null)
		{
			LoopStream waveProvider = new LoopStream(reader6);
			waveOut6 = new WaveOut();
			waveOut6.Init(waveProvider);
			waveOut6.Play();
		}
		else
		{
			waveOut6.Stop();
			waveOut6.Dispose();
			waveOut6 = null;
		}
	}

	public static void PlayLooping7(this WaveFileReader reader7)
	{
		if (waveOut7 == null)
		{
			LoopStream waveProvider = new LoopStream(reader7);
			waveOut7 = new WaveOut();
			waveOut7.Init(waveProvider);
			waveOut7.Play();
		}
		else
		{
			waveOut7.Stop();
			waveOut7.Dispose();
			waveOut7 = null;
		}
	}

	public static void PlayLooping8(this WaveFileReader reader8)
	{
		if (waveOut8 == null)
		{
			LoopStream waveProvider = new LoopStream(reader8);
			waveOut8 = new WaveOut();
			waveOut8.Init(waveProvider);
			waveOut8.Play();
		}
		else
		{
			waveOut8.Stop();
			waveOut8.Dispose();
			waveOut8 = null;
		}
	}

	public static void Play(this WaveFileReader reader)
	{
		if (output.PlaybackState != PlaybackState.Stopped)
		{
			output.Stop();
		}
		reader.Position = 0L;
		output.Init(reader);
		output.Play();
	}

	public static void Play2(this WaveFileReader reader2)
	{
		if (output2.PlaybackState != PlaybackState.Stopped)
		{
			output2.Stop();
		}
		reader2.Position = 0L;
		output2.Init(reader2);
		output2.Play();
	}

	public static void Stop(this WaveFileReader reader)
	{
		output.Stop();
	}

	public static void StopLooping(this WaveFileReader reader)
	{
		if (waveOut != null)
		{
			reader.Position = 0L;
			waveOut.Stop();
			waveOut.Dispose();
			waveOut = null;
		}
		if (waveOut2 != null)
		{
			reader.Position = 0L;
			waveOut2.Stop();
			waveOut2.Dispose();
			waveOut2 = null;
		}
		if (waveOut3 != null)
		{
			reader.Position = 0L;
			waveOut3.Stop();
			waveOut3.Dispose();
			waveOut3 = null;
		}
		if (waveOut4 != null)
		{
			reader.Position = 0L;
			waveOut4.Stop();
			waveOut4.Dispose();
			waveOut4 = null;
		}
		if (waveOut5 != null)
		{
			reader.Position = 0L;
			waveOut5.Stop();
			waveOut5.Dispose();
			waveOut5 = null;
		}
		if (waveOut6 != null)
		{
			reader.Position = 0L;
			waveOut6.Stop();
			waveOut6.Dispose();
			waveOut6 = null;
		}
		if (waveOut7 != null)
		{
			reader.Position = 0L;
			waveOut7.Stop();
			waveOut7.Dispose();
			waveOut7 = null;
		}
		if (waveOut8 != null)
		{
			reader.Position = 0L;
			waveOut8.Stop();
			waveOut8.Dispose();
			waveOut8 = null;
		}
	}
}
