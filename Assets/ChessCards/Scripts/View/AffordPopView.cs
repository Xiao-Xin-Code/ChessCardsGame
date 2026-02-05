using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace ChessCards
{

	public class AffordPopView : BaseView
	{
		[SerializeField] Button nonout;
		[SerializeField] Button afford;
		[SerializeField] Button nonafford;



		#region Register

		public void RegisterNonOutPressed(UnityAction action)
		{
			nonout?.onClick.AddListener(action);
		}

		public void RegisterAffordPressed(UnityAction action)
		{
			afford?.onClick.AddListener(action);
		}

		public void RegisterNonAffordPressed(UnityAction action)
		{
			nonafford?.onClick.AddListener(action);
		}

		#endregion



		public void ViewState(bool canAfford,bool withNonOut)
		{
			if (canAfford)
			{
				nonout.gameObject.SetActive(withNonOut);
				afford.gameObject.SetActive(true);
				nonafford.gameObject.SetActive(false);
			}
			else
			{
				nonout.gameObject.SetActive(false);
				afford.gameObject.SetActive(false);
				nonafford.gameObject.SetActive(true);
			}
		}

	}
}


