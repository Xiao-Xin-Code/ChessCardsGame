using QMVC;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ChessCards
{
    public class BaseView : IView
    {
        public IArchitecture GetArchitecture()
        {
            return ChessCards.Interface;
        }
    }

}


