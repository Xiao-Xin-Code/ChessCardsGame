using System.Collections;
using System.Collections.Generic;
using QMVC;
using UnityEngine;

namespace ChessCards
{
    public class FlowController : MonoController
    {
        MatchModel _matchModel;
        MatchSystem _matchSystem;
        CardLibrarySystem _cardLibrarySystem;


        public override void Init()
        {
            _matchModel = this.GetModel<MatchModel>();
            _matchSystem = this.GetSystem<MatchSystem>();
            _cardLibrarySystem = this.GetSystem<CardLibrarySystem>();

			_matchModel.State.Register(OnStateChanged);

		}

        private void Start()
        {

            _matchModel.State.Value = GameState.Init;
            OnStateChanged(_matchModel.State.Value);

			OnStateChanged(GameState.DealCard);
		}




        private void OnStateChanged(GameState state)
        {

            switch (state)
            {
                case GameState.Init:
                    
                    this.SendCommand<InitCardLibraryCommand>();
                    break;
                case GameState.Prepare:

                    break;
                case GameState.DealCard:
                    DealCards();

					break;
                case GameState.CallScore:
                    break;
                case GameState.DealBaseCard:
                    break;
                case GameState.PlayCard:
                    break;
                case GameState.GameOver:
                    break;
                default:
                    break;
            }

        }



		private void DealCards()
		{
            Debug.Log("∑÷≈‰" + _matchModel.players.Count);
			int start = Random.Range(0, _matchModel.players.Count);
			int count = Consts.TOTAL_CARD_COUNT - Consts.BASE_CARD_COUNT;

			for (int i = 0; i < count; i++)
			{
                Debug.Log(start);
                if (_matchSystem.TryGetPlayerEntity(_matchModel.players[start], out PlayerEntity playerEntity)) 
				{
					if (_cardLibrarySystem.TryPop(out int id))
                    {
						playerEntity.AddHandCard(id);
						start = start == _matchModel.players.Count - 1 ? 0 : start + 1;
					}
				}
			}

            List<int> trumpCards = new List<int>();
            for(int i = 0;i< Consts.BASE_CARD_COUNT; i++)
            {
                if(_cardLibrarySystem.TryPop(out int id))
                {
					trumpCards.Add(id);
				}
            }
            //∏¸–¬Trump
		}


	}


}

