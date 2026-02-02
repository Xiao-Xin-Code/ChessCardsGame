using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ChessCards
{
    public class CardEntity : BaseEntity
    {
        public int id;

        public Suit suit = Suit.None;
        public Rank rank = Rank.None;

    }
}

