using System.Collections;
using System.Collections.Generic;
using QMVC;
using UnityEngine;

namespace ChessCards
{
	public class PreparePopController : MonoController
	{
        [SerializeField] PreparePopView _view;

        MatchModel _matchModel;

        public override void Init()
        {
            _matchModel = this.GetModel<MatchModel>();

			_view.RegisterPreparePressed(OnPreparePressed);
        }


        private void OnPreparePressed()
        {
            //´¥·¢ÅÐ¶Ï
            _matchModel.State.Value = GameState.DealCard;
            gameObject.SetActive(false);

		}
	}
}


