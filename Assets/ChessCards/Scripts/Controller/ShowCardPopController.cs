using QMVC;
using UnityEngine;


namespace ChessCards
{

    public class ShowCardPopController : MonoController
    {
        [SerializeField] ShowCardPopView _view;


        public override void Init()
        {


            this.RegisterEvent<ShowCardVisibleEvent>(ShowCardVisible);

            _view.RegisterShowCardPressed(OnShowCardPressed);

        }


        private void Start()
        {
            gameObject.SetActive(false);
        }


        private void OnShowCardPressed()
        {
            Debug.Log("´¥·¢Ã÷ÅÆ£¡");
            gameObject.SetActive(false);
        }


        private void ShowCardVisible(ShowCardVisibleEvent evt)
        {
            gameObject.SetActive(evt.visible);
        }

    }

}


