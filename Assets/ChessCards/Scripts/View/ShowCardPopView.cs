using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;


namespace ChessCards
{
	public class ShowCardPopView : BaseView
	{
		[SerializeField] Button showCard;


		#region Register

		public void RegisterShowCardPressed(UnityAction action)
		{
			showCard?.onClick.AddListener(action);
		}

		#endregion
	}

}


