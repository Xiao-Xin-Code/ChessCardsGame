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

        public int weight { get; private set; }

        public CardEntity(int id, Suit suit, Rank rank, int weight)
        {
            this.id = id;
            this.suit = suit;
            this.rank = rank;
            this.weight = weight;
        }


        public BindableProperty<bool> IsSelect = new BindableProperty<bool>(false);

    }
}

