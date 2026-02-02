using QMVC;
using UnityEngine;


namespace ChessCards
{
    public abstract class MonoController : MonoBehaviour,IController
    {
        private void Awake()
        {
            Init();
        }

        public abstract void Init();


        public IArchitecture GetArchitecture()
        {
            return ChessCards.Interface;
        }
    }


}

