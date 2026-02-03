using QMVC;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ChessCards
{
    public class BaseView : MonoBehaviour, IView
    {
        public IArchitecture GetArchitecture()
        {
            return ChessCards.Interface;
        }
    }

}


