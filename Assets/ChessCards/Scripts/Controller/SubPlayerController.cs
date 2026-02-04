using QMVC;
using UnityEngine;

namespace ChessCards
{
    /// <summary>
    /// 上下家
    /// </summary>
    public class SubPlayerController : MonoController
    {
        public int ID { get; private set; }

        [SerializeField] PlayerView _view;
        [SerializeField] SubHandCardsController handCards;

		CardLibrarySystem _cardLibrarySystem;
        AssetSystem _assetSystem;


		public override void Init()
        {
            _cardLibrarySystem = this.GetSystem<CardLibrarySystem>();
            _assetSystem = this.GetSystem<AssetSystem>();

        }


        public void SetId(int id)
        {
            ID = id;
            handCards.SetId(id);
        }

		public void OnRoleChanged(PlayerRole role)
		{
			if(_assetSystem.TryGetRoleIcon($"Role_{role}",out Sprite sprite))
            {
                _view.UpdateRole(sprite);
			}
		}


		#region HandCards操作

		public void AddHandCard(int entityId)
        {
			if (_cardLibrarySystem.TryGetCardEntity(entityId, out CardEntity entity))
			{
				handCards.AddHandCard(entity);
			}
		}

        public void RemoveHandCard(int entityId)
        {
			if (_cardLibrarySystem.TryGetCardEntity(entityId, out CardEntity entity))
			{
				handCards.RemoveHandCard(entity);
			}
		}



        #endregion



    }
}