using System.Collections;
using System.Collections.Generic;
using QMVC;
using UnityEngine;

namespace ChessCards
{
    public class CallScorePopController : MonoController
    {
        [SerializeField] CallScorePopView _view;
        MatchSystem _matchSystem;

        public override void Init()
        {
            _matchSystem = this.GetSystem<MatchSystem>();

            this.RegisterEvent<CallScoreVisibleEvent>(CallScoreVisible);


            _view.RegisterNoneScorePressed(CallNoneScorePressed);
            _view.RegisterOneScorePressed(CallOneScorePressed);
            _view.RegisterTwoScorePressed(CallTwoScorePressed);
            _view.RegisterThreeScorePressed(CallThreeScorePressed);


        }

        private void Start()
        {
            gameObject.SetActive(false);
        }



        private void CallScoreVisible(CallScoreVisibleEvent evt)
        {
            gameObject.SetActive(evt.visible);
        }


        private void CallNoneScorePressed()
        {


            gameObject.SetActive(false);
        }

        private void CallOneScorePressed()
        {

            gameObject.SetActive(false);
        }

        private void CallTwoScorePressed()
        {


            gameObject.SetActive(false);
        }

        private void CallThreeScorePressed()
        {
            _matchSystem.TryGetLocalEntity(out PlayerEntity entity);
            entity.SetRole(PlayerRole.Landlord);
			gameObject.SetActive(false);
        }


    }

}


