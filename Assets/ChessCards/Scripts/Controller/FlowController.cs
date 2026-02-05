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
        AudioSystem _audioSystem;


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

			OnStateChanged(GameState.Prepare);
		}




        private void OnStateChanged(GameState state)
        {
            switch (state)
            {
                case GameState.Init:
                    this.SendCommand<InitCardLibraryCommand>();
                    break;
                case GameState.Prepare:
                    this.SendCommand(new PrepareVisibleCommand(true));
                    break;
                case GameState.DealCard:
                    this.SendCommand(new ShowCardVisibleCommand(true));
                    StartCoroutine(DealCardsCoroutine());
                    //设置开始位置
					break;
                case GameState.CallScore:
                    //触发开始叫分
                    break;
                case GameState.DealBaseCard:
                    break;
                case GameState.PlayCard:
                    //触发开始出牌
                    break;
                case GameState.GameOver:
                    break;
                default:
                    break;
            }
        }


		IEnumerator DealCardsCoroutine()
        {
			float dealCardInterval = 0.2f;
			int start = Random.Range(0, _matchModel.players.Count);
			int count = Consts.TOTAL_CARD_COUNT - Consts.BASE_CARD_COUNT;

			for (int i = 0; i < count; i++)
			{
				if (_matchSystem.TryGetPlayerEntity(_matchModel.players[start], out PlayerEntity playerEntity))
				{
					if (_cardLibrarySystem.TryPop(out int id))
					{
						playerEntity.AddHandCard(id);
						yield return new WaitForSeconds(dealCardInterval);
						start = start == _matchModel.players.Count - 1 ? 0 : start + 1;
					}
				}
			}

            this.SendCommand(new ShowCardVisibleCommand(false));

			List<int> trumpCards = new List<int>();
			for (int i = 0; i < Consts.BASE_CARD_COUNT; i++)
			{
				if (_cardLibrarySystem.TryPop(out int id))
				{
					trumpCards.Add(id);
				}
			}
			_cardLibrarySystem.TrumpCards = trumpCards;

			//更新Trump
			this.SendCommand<SetTrumpCardsCommand>();

            //切换分数
            this.SendCommand(new CallScoreVisibleCommand(true));
		}


		private void PrepareChangedAndCheck(bool prepare)
        {
            if (prepare)
            {
                _matchModel.prepareCount++;
                if(_matchModel.prepareCount >= 3)
                {
                    _matchModel.State.Value = GameState.DealCard;
				}
            }
            else
            {
                _matchModel.prepareCount--;
            }
        }



        

	}
}

