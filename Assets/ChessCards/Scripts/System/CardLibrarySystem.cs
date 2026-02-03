using System.Collections;
using System.Collections.Generic;
using QMVC;
using UnityEngine;

namespace ChessCards
{
	public class CardLibrarySystem : AbstractSystem
	{
		PoolSystem _poolSystem;
		MatchSystem _matchSystem;
		CardLibraryModel _cardLibraryModel;

		Transform libraryParent;

		protected override void OnInit()
		{
			libraryParent = new GameObject("CardLibrary").transform;

			_poolSystem = this.GetSystem<PoolSystem>();
			_matchSystem = this.GetSystem<MatchSystem>();
			_cardLibraryModel = this.GetModel<CardLibraryModel>();


			this.RegisterEvent<InitCardLibraryEvent>(InitCardLibrary);
		}



		//分发
		public bool TryPop(out int cardId)
        {
            if (_cardLibraryModel.cardLibrary != null && _cardLibraryModel.cardLibrary.Count > 0)
            {
                cardId = _cardLibraryModel.cardLibrary[0];
				_cardLibraryModel.cardLibrary.RemoveAt(0);
                return true;
			}
            cardId = -1;
            return false;
        }


        //回收
        public void Push(int id)
        {
            if (_cardLibraryModel.cardLibrary.Contains(id))
            {
				_cardLibraryModel.cardLibrary.Add(id);
            }
		}



		//可以只在最开始触发一次
		private void InitCardLibrary(InitCardLibraryEvent evt)
		{
			for (int i = 1; i <= Consts.CARD_RANK; i++)
			{
				for (int j = 1; j <= Consts.CARD_SUIT; j++)
				{
					CardController card = _poolSystem.GetCard();
					card.RectTransform.SetParent(libraryParent);
					int id = card.GetInstanceID();
					card.ID = id;
					card.Suit = (Suit)j;
					card.Rank = (Rank)i;
					card.UpdateIcon();
					_matchSystem.AddCard(id, card);
					_cardLibraryModel.cardLibrary.Add(id);
				}
			}

			System.Random random = new System.Random();
			int n = _cardLibraryModel.cardLibrary.Count - 1;

			//只更新数据位置即可
			while (n > 0)
			{
				var temp = random.Next(n + 1);
				(_cardLibraryModel.cardLibrary[temp], _cardLibraryModel.cardLibrary[n]) = (_cardLibraryModel.cardLibrary[n], _cardLibraryModel.cardLibrary[temp]);
				n--;
			}
		}

        
    }

}


