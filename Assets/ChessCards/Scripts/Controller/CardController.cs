using DG.Tweening;
using QMVC;
using UnityEngine;
using UnityEngine.EventSystems;


namespace ChessCards
{

    public class CardController : MonoController
    {
        AssetSystem _assetSystem;
        MatchSystem _matchSystem;
        MatchModel _matchModel;

        [SerializeField] CardView _view;


        #region 属性

        public RectTransform RectTransform { get => _view.RectTransform; }

        public int ID { get; private set; }


        #endregion


        public override void Init()
        {
            _assetSystem = this.GetSystem<AssetSystem>();
            _matchSystem = this.GetSystem<MatchSystem>();


            _view.RegisterPointerUp(OnPointerUp);
        }



        private void OnSelectCahnegd(bool isSelect)
        {
            float dis = isSelect ? 20 : 0;
            _view.RectTransform.DOAnchorPosY(dis, 0.2f);
        }



        private void OnPointerDown(PointerEventData eventData)
        {

        }

        private void OnPointerUp(PointerEventData eventData)
        {
            if(_matchSystem.TryGetLocalEntity(out PlayerEntity localHome))
            {
                localHome.AddSelectCard(ID);
            }

		}


        public void SetEntity(CardEntity entity)
        {
            ID = entity.id;
            if (_assetSystem.TryGetRankIcon($"{entity.suit}_{entity.rank}", out Sprite sprite)) 
            {
                Debug.Log("存在更新");
                _view.UpdateIcon(sprite);
            }
        }
    }


}

