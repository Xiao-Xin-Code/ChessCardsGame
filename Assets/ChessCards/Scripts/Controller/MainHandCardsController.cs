using System.Collections.Generic;
using QMVC;
using UnityEngine;

namespace ChessCards
{
    /// <summary>
    /// 本机手牌区
    /// </summary>
    public class MainHandCardsController : MonoController
    {
        public int ID { get; private set; }

        MonoPool<CardController> cardPool;
        List<CardController> activeCards = new List<CardController>();


        AssetSystem _assetSystem;
        CardLibrarySystem _cardLibrarySystem;
        float offset = 60;

        public override void Init()
        {
            _assetSystem = this.GetSystem<AssetSystem>();
            _cardLibrarySystem = this.GetSystem<CardLibrarySystem>();
            cardPool = new MonoPool<CardController>(_assetSystem.mainCard, transform);
		}

        public void SetId(int id)
        {
            ID = id;
        }

        private void Sort()
        {
			activeCards.Sort((a, b) => _cardLibrarySystem.GetCardEntity(a.ID).weight.CompareTo(_cardLibrarySystem.GetCardEntity(a.ID).weight));
		}

        private void Arrange()
        {
            float width = _assetSystem.mainCard.RectTransform.rect.width;
			float total_width = activeCards.Count > 0 ? width + offset * (activeCards.Count - 1) : 0;
            float location_x = -(total_width / 2 - width / 2);
			for (int i = 0; i < activeCards.Count; i++)
			{
				activeCards[i].RectTransform.SetSiblingIndex(i);
                float curx = location_x + offset * i;
                Debug.Log($"更新位置{curx}");
                activeCards[i].RectTransform.anchoredPosition = new Vector2(curx, 0);
			}
		}

        public void AddHandCard(CardEntity cardEntity)
        {
            CardController card = cardPool.Get();
            activeCards.Add(card);
            card.SetEntity(cardEntity);
            Arrange();
		}

        public void RemoveHandCard(CardEntity cardEntity)
        {
            for(int i = 0; i < activeCards.Count; i++)
            {
                if (activeCards[i].ID == cardEntity.id)
                {
                    CardController card = activeCards[i];
					activeCards.RemoveAt(i);
                    cardPool.Recycle(card);
                    break;
                }
			}
            Arrange();
		}

        
    }
}