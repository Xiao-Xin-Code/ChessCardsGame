using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ChessCards
{

    public class PlayerEntity : BaseEntity
    {

        public int id;

        public List<int> handCards = new List<int>();
        public List<int> selectCards = new List<int>();


    }

}

