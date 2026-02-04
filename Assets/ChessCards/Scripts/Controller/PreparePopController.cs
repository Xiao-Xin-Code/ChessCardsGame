using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ChessCards
{
	public class PreparePopController : MonoController
	{
        PreparePopView _view;
        

        public override void Init()
        {
            _view.RegisterPreparePressed(OnPreparePressed);
        }


        private void OnPreparePressed()
        {
            //´¥·¢ÅÐ¶Ï
        }
	}
}


