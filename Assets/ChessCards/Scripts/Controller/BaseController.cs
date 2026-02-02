using QMVC;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ChessCards
{
    public class BaseController : IController
    {
        public IArchitecture GetArchitecture()
        {
            return ChessCards.Interface;
        }
    }
}


