using System.Collections;
using System.Collections.Generic;
using Frame;
using QMVC;
using UnityEngine;

namespace ChessCards
{
    public class AudioSystem : AbstractSystem
    {
        AssetSystem _assetSystem;
        PoolSystem _poolSystem;


        AudioSource _bgmSource;
        float _bgmVolume = 1;
        float _bgmFadeTime = 0.5f;
        private Coroutine _bgmFadeCoroutine;



        protected override void OnInit()
        {
            
        }


		#region BGM

		public void PlayBGM(string clip)
		{
			//_assetSystem.
		}

		public void PlayBGM(AudioClip audioClip)
		{
			if (audioClip == null)
			{
				return;
			}
			if (_bgmFadeCoroutine != null)
			{
				MonoService.Instance.StopCoroutine(_bgmFadeCoroutine);
			}
			if (_bgmSource.isPlaying)
			{
				_bgmFadeCoroutine = MonoService.Instance.StartCoroutine(FadeOutAndSwitchBGM(audioClip, true));
			}
			else
			{
				_bgmSource.clip = audioClip;
				_bgmSource.loop = true;
				_bgmSource.volume = 0;
				_bgmSource.Play();
				_bgmFadeCoroutine = MonoService.Instance.StartCoroutine(FadeInBGM());
			}
		}

		public void StopBGM()
		{
			if (_bgmFadeCoroutine != null)
			{
				MonoService.Instance.StopCoroutine(_bgmFadeCoroutine);
			}
			_bgmFadeCoroutine = MonoService.Instance.StartCoroutine(FadeOutBGM());
		}

		private IEnumerator FadeInBGM()
		{
			float currentVolume = 0;
			while (currentVolume < _bgmVolume)
			{
				currentVolume += Time.deltaTime / _bgmFadeTime;
				currentVolume = Mathf.Min(currentVolume, _bgmVolume);
				_bgmSource.volume = currentVolume;
				yield return null;
			}
			_bgmFadeCoroutine = null;
		}

		private IEnumerator FadeOutBGM()
		{
			float currentVolume = _bgmSource.volume;
			while (currentVolume > 0)
			{
				currentVolume -= Time.deltaTime / _bgmFadeTime;
				currentVolume = Mathf.Max(currentVolume, 0);
				_bgmSource.volume = currentVolume;
				yield return null;
			}
			_bgmSource.Stop();
			_bgmSource.clip = null;
			_bgmFadeCoroutine = null;
		}

		private IEnumerator FadeOutAndSwitchBGM(AudioClip newClip, bool isLoop)
		{
			yield return FadeOutBGM();
			_bgmSource.clip = newClip;
			_bgmSource.loop = isLoop;
			_bgmSource.volume = 0;
			_bgmSource.Play();
			yield return FadeInBGM();
		}

		#endregion


		#region SFX

		public void PlaySFX(AudioClip clip)
		{


		}

		#endregion
	}


}


