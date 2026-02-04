using System.Collections.Generic;
using QMVC;
using UnityEngine;

namespace ChessCards
{
    /// <summary>
    /// 上下家手牌区
    /// </summary>
    public class SubHandCardsController : MonoController
    {
        public int ID { get; private set; }

        ComponentPool<RectTransform> cardPool;
        List<RectTransform> activeCards = new List<RectTransform>();


        AssetSystem _assetSystem;
        public Vector2 offset = new Vector2(15, 15);


        public override void Init()
        {
            _assetSystem = this.GetSystem<AssetSystem>();

            cardPool = new ComponentPool<RectTransform>(_assetSystem.subCard, transform);

        }


        public void SetId(int id)
        {
            ID = id;
        }


        private void Arrange()
        {

            for(int i = 0; i < activeCards.Count; i++)
            {
                activeCards[i].anchoredPosition += offset;
			}
        }


        public void AddHandCard(CardEntity cardEntity)
        {
			RectTransform card = cardPool.Get();
            activeCards.Add(card);
			Arrange();
		}

		public void RemoveHandCard(CardEntity cardEntity)
		{
            RectTransform card = activeCards[0];
            activeCards.RemoveAt(0);
            cardPool.Recycle(card);
            Arrange();
		}
	}
}