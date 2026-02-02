using QMVC;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ChessCards
{

    public abstract class BaseEntity : IEntity
    {
        public IArchitecture GetArchitecture()
        {
            return ChessCards.Interface;
        }
    }
}


