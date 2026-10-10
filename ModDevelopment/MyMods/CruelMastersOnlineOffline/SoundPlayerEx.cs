using System;
using System.Media;
using System.Threading;
using System.Threading.Tasks;

namespace CruelMastersOnlineOffline;

public class SoundPlayerEx : SoundPlayer
{
	public static bool Talk;

	public bool TalkTimer = false;

	private Task _playTask;

	private CancellationTokenSource _tokenSource = new CancellationTokenSource();

	private CancellationToken _ct;

	private string _fileName;

	private bool _playingAsync = false;

	public bool Finished { get; private set; }

	public event EventHandler SoundFinished;

	public SoundPlayerEx(string soundLocation)
		: base(soundLocation)
	{
		_fileName = soundLocation;
		_ct = _tokenSource.Token;
	}

	public void PlayAsync()
	{
		Finished = false;
		_playingAsync = true;
		Task.Run(() =>
		{
			try
			{
				double value = SoundInfo.GetSoundLength(_fileName);
				DateTime dateTime = DateTime.Now.AddMilliseconds(value);
				Play();
				while (DateTime.Now < dateTime)
				{
					_ct.ThrowIfCancellationRequested();
					Task.Delay(10).Wait();
				}
			}
			catch (OperationCanceledException)
			{
				base.Stop();
			}
			finally
			{
				OnSoundFinished();
			}
		}, _ct);
	}

	public new void Stop()
	{
		if (_playingAsync)
		{
			_ct.ThrowIfCancellationRequested();
			base.Stop();
			OnSoundFinished();
		}
		else
		{
			base.Stop();
		}
	}

	protected virtual void OnSoundFinished()
	{
		Finished = true;
		_playingAsync = false;
		SoundFinished?.Invoke(this, EventArgs.Empty);
	}
}
