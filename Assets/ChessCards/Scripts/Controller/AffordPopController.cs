using System.Collections;
using System.Collections.Generic;
using QMVC;
using UnityEngine;

namespace ChessCards
{
    public class AffordPopController : MonoController
    {
        [SerializeField] AffordPopView _view;

        public override void Init()
        {
            this.RegisterEvent<AffordVisibleEvent>(AffordVisible);
            this.RegisterEvent<ActiveAffordEvent>(ActiveAfford);
        }

        private void Start()
        {
            gameObject.SetActive(false);
        }



        private void ActiveAfford(ActiveAffordEvent evt)
        {
            _view.ViewState(evt.canAfford, evt.nonWithOut);
        }



        private void AffordVisible(AffordVisibleEvent evt)
        {
            gameObject.SetActive(evt.visible);
        }

    }

}


