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
        MatchSystem _matchSystem;
        public float offset = 60;

        public override void Init()
        {
            _assetSystem = this.GetSystem<AssetSystem>();
            _matchSystem = this.GetSystem<MatchSystem>();
			_cardLibrarySystem = this.GetSystem<CardLibrarySystem>();
            cardPool = new MonoPool<CardController>(_assetSystem.mainCard, transform);
		}

        public void SetId(int id)
        {
            ID = id;
        }


        public void Sort()
        {
			activeCards.Sort((a, b) => _cardLibrarySystem.GetCardEntity(a.ID).weight.CompareTo(_cardLibrarySystem.GetCardEntity(b.ID).weight));
		}

        public void Arrange()
        {
            _matchSystem.TryGetLocalEntity(out PlayerEntity localHome);

            float width = _assetSystem.mainCard.RectTransform.rect.width;
			float total_width = activeCards.Count > 0 ? width + offset * (activeCards.Count - 1) : 0;
            float location_x = -(total_width / 2 - width / 2);
			for (int i = 0; i < activeCards.Count; i++)
			{
				activeCards[i].RectTransform.SetSiblingIndex(i);
                float curx = location_x + offset * i;
                if (localHome.SelectCards.Contains(activeCards[i].ID))
                {
                    Debug.Log("c存在"+ activeCards[i].ID);
                }
                activeCards[i].RectTransform.anchoredPosition = localHome.SelectCards.Contains(activeCards[i].ID) ? new Vector2(curx, 50) : new Vector2(curx, 0);
			}
		}

        public void AddHandCard(CardEntity cardEntity)
        {
            CardController card = cardPool.Get();
            activeCards.Add(card);
            card.SetEntity(cardEntity);
            Sort();
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
			Sort();
			Arrange();
		}

        

        public void OnSelectChanged()
        {
            


        }

    }
}