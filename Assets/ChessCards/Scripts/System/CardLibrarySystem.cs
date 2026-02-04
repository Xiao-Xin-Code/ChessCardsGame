using System;
using System.Collections;
using System.Collections.Generic;
using QMVC;
using UnityEngine;

namespace ChessCards
{
	public class CardLibrarySystem : AbstractSystem
	{
		CardLibraryModel _cardLibraryModel;


		public List<int> TrumpCards { get => _cardLibraryModel.trumpCards; set => _cardLibraryModel.trumpCards = value; }


		protected override void OnInit()
		{
			_cardLibraryModel = this.GetModel<CardLibraryModel>();

			this.RegisterEvent<InitCardLibraryEvent>(InitCardLibrary);
		}

		public bool TryGetCardEntity(int id, out CardEntity value)
		{
			return _cardLibraryModel.cards.TryGetValue(id, out value);
		}

		public CardEntity GetCardEntity(int id)
		{
			if(_cardLibraryModel.cards.TryGetValue(id, out CardEntity value))
			{
				return value;
			}
			throw new NullReferenceException($"Null is Key {id}");
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
			int id = 0;
			for (int i = 1; i <= Consts.CARD_RANK; i++)
			{
				Rank rank = (Rank)i;
				for (int j = 1; j <= Consts.CARD_SUIT; j++)
				{
					Suit suit = (Suit)j;
					id++;
					CardEntity cardEntity = new CardEntity(id, suit, rank, i);
					_cardLibraryModel.cards.Add(id, cardEntity);
					_cardLibraryModel.cardLibrary.Add(id);
				}
            }
            id++;
            CardEntity joker_small = new CardEntity(id, Suit.None, Rank.JokerSmall, (int)Rank.JokerSmall);
            _cardLibraryModel.cards.Add(id, joker_small);
            _cardLibraryModel.cardLibrary.Add(id);
            id++;
            CardEntity joker_big = new CardEntity(id, Suit.None, Rank.JokerBig, (int)Rank.JokerBig);
            _cardLibraryModel.cards.Add(id, joker_big);
            _cardLibraryModel.cardLibrary.Add(id);



            Shuffle();
		}

		private void Shuffle()
		{
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

		private void InitTrumpCards(List<int> trumpCards)
		{
			_cardLibraryModel.trumpCards = trumpCards;
		}


        
    }

}


