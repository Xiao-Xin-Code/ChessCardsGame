using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace ChessCards
{

    public class CardController : MonoController
    {

        CardEntity _entity;


        #region ÊôÐÔ

        public int ID { get => _entity.id; set => _entity.id = value; }
        public Suit Suit { get => _entity.suit; set => _entity.suit = value; }
        public Rank Rank { get => _entity.rank; set => _entity.rank = value; }


        #endregion


        public override void Init()
        {
            
        }
    }


}

