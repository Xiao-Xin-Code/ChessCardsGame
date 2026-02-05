using UnityEngine;

namespace ChessCards
{
	public class SFXView : BaseView
	{
		[SerializeField] private AudioSource audioSource;

		public AudioSource AudioSource => audioSource;
	}

}



