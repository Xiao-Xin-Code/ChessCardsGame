using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace ChessCards
{

	public class PreparePopView : BaseView
	{
		[SerializeField] Button prepare;



		#region Register

		public void RegisterPreparePressed(UnityAction action)
		{
			prepare.onClick.AddListener(action);
		}

		#endregion


		#region UnRegister

		public void UnRegisterPreparePressed(UnityAction action)
		{
			prepare.onClick.RemoveListener(action);
		}

		#endregion
	}
}


