using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace ChessCards
{
    public class TrumpCardsController : MonoController
    {
        TrumpCardsEntity _entity;

        public override void Init()
        {
            
        }



        private void SetTrumpCards(List<int> trumpCards)
        {
            foreach (var item in trumpCards) 
            {
                _entity.trumpCards.Add(item);
			}
        }

    }
}


