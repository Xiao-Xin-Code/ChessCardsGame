using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;


namespace ChessCards
{
	public class CallScorePopView : BaseView
	{
		[SerializeField] Button nonescore;
		[SerializeField] Button onescore;
		[SerializeField] Button twoscore;
		[SerializeField] Button threescore;


		#region Register

		public void RegisterNoneScorePressed(UnityAction action)
		{
			nonescore?.onClick.AddListener(action);
		}

		public void RegisterOneScorePressed(UnityAction action)
		{
			onescore?.onClick.AddListener(action);
		}

		public void RegisterTwoScorePressed(UnityAction action)
		{
			twoscore?.onClick.AddListener(action);
		}

		public void RegisterThreeScorePressed(UnityAction action)
		{
			threescore?.onClick.AddListener(action);
		}

		#endregion
	}

}


