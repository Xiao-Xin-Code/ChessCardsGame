using System.Collections;
using System.Collections.Generic;
using QMVC;
using UnityEngine;

namespace ChessCards
{
    public class PoolSystem : AbstractSystem
    {
        AssetSystem _assetSystem;

        MonoPool<CardController> cardPool;


        Transform poolRoot;


        protected override void OnInit()
        {
            _assetSystem = this.GetSystem<AssetSystem>();
            poolRoot = new GameObject("Pools").transform;
            Transform cardParent = new GameObject(_assetSystem.card.GetType().Name).transform;
            cardParent.SetParent(poolRoot);
            cardPool = new MonoPool<CardController>(_assetSystem.card, cardParent, Consts.TOTAL_CARD_COUNT);
		}



        public CardController GetCard()
        {
            return cardPool.Get();
        }

        public void RecycleCard()
        {

        }


        public void RecycleAllCard()
        {
            cardPool.RecycleAll();
        }
    }

}


