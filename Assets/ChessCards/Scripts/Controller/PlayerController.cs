using System.Collections.Generic;
using QMVC;
using UnityEngine;

namespace ChessCards
{
    public class PlayerController : MonoController
    {
        [SerializeField] PlayerView _view;
        PlayerEntity _entity;


        MatchSystem _matchSystem;
        AssetSystem _AssteSystem;
		MatchModel _matchModel;

        #region ÊôÐÔ

        public int ID { get => _entity.id; set => _entity.id = value; }
        public PlayerRole Role { get => _entity.PlayerRole.Value; set => _entity.PlayerRole.Value = value; }

        #endregion



        public override void Init()
        {
			_matchSystem = this.GetSystem<MatchSystem>();
            _AssteSystem = this.GetSystem<AssetSystem>();

			_entity = new PlayerEntity();


            


            _entity.PlayerRole.Register(RoleChanged);

		}

		#region HandCards

		public void AddHandCard(int id)
		{
			_entity.handCards.Add(id);

			_matchSystem.TryGetCard(id, out CardController card);
			card.RectTransform.SetParent(_view.HandRectTransform);
            card.RectTransform.anchoredPosition = Vector2.zero;

        }

		public void AddHandCards(List<int> ids)
		{
			for (int i = 0; i < ids.Count; i++)
			{
				AddHandCard(ids[i]);
			}
		}

		public void RemoveHandCard(int id)
		{
			_entity.handCards.Remove(id);
		}

		public void RemoveHandCards(List<int> ids)
		{
			for (int i = 0; i < ids.Count; i++)
			{
				RemoveHandCard(ids[i]);
			}
		}

		#endregion

		#region SelectCards

		public void AddSelectCard(int id)
		{

		}

		public void AddSelectCards(List<int> ids)
		{

		}


		public void RemoveSelectCard(int id)
		{

		}

		public void RemoveSelectCards(List<int> ids)
		{

		}


		private void PopSelectCards()
		{
			_matchModel.previousCards = _entity.selectCards;
			_matchModel.previousHome = _entity.id;

			for(int i = 0; i < _entity.selectCards.Count; i++)
			{
				_entity.handCards.Remove(_entity.selectCards[i]);
			}
			_entity.selectCards.Clear();
			//ÇÐ»»ÏÂÒ»Player
		}

		#endregion


		private void RoleChanged(PlayerRole role)
        {
            switch (role)
            {
                case PlayerRole.None:
                    break;
                case PlayerRole.Landlord:
                    if (_AssteSystem.TryGetRoleIcon("Role_Landlord", out Sprite landlord))
                        _view.UpdateRole(landlord);
                    break;
                case PlayerRole.Farmer:
					if (_AssteSystem.TryGetRoleIcon("Role_Farmer", out Sprite farmer))
						_view.UpdateRole(farmer);
					break;
                default:
                    break;
            }

        }




    }

}


