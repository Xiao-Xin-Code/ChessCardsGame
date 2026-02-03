using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
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
        CardEntity _entity;


        #region ÊôÐÔ

        public RectTransform RectTransform { get => _view.RectTransform; }

        public int ID { get => _entity.id; set => _entity.id = value; }
        public Suit Suit { get => _entity.suit; set => _entity.suit = value; }
        public Rank Rank { get => _entity.rank; set => _entity.rank = value; }


        #endregion


        public override void Init()
        {
            _entity = new CardEntity();
            _entity.IsSelect.Register(OnSelectCahnegd);

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
            _entity.IsSelect.Value = !_entity.IsSelect.Value;
            _matchSystem.TryGetPlayer(_matchModel.curHome,out PlayerController player);
            player.AddSelectCard(_entity.id);

		}




        public void UpdateIcon()
        {
            Debug.Log($"¸üÐÂ{_entity.suit}_{_entity.rank}");
        }
    }


}

