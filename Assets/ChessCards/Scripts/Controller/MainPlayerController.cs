using System.Collections;
using QMVC;
using UnityEngine;

namespace ChessCards
{
    /// <summary>
    /// 本机用户
    /// </summary>
    public class MainPlayerController : MonoController
    {
        /// <summary>
        /// ID 用于字典记录时的ID
        /// </summary>
        public int ID { get; private set; }

		[SerializeField] PlayerView _view;
		[SerializeField] MainHandCardsController handCards;
        
        CardLibrarySystem _cardLibrarySystem;
        AssetSystem _assetSystem;
        MatchSystem _matchSystem;


        public override void Init()
        {
            _cardLibrarySystem = this.GetSystem<CardLibrarySystem>();
            _assetSystem = this.GetSystem<AssetSystem>();
            _matchSystem = this.GetSystem<MatchSystem>();
		}


        public void SetId(int id)
        {
            ID = id;
            handCards.SetId(id);
        }

		public void OnRoleChanged(PlayerRole role)
		{
			if (_assetSystem.TryGetRoleIcon($"Role_{role}", out Sprite sprite))
			{
				_view.UpdateRole(sprite);
			}
		}


		#region HandCards操作


		/// <summary>
		/// Entity数据驱动显示变化，添加
		/// </summary>
		/// <param name="entityId"></param>
		public void AddHandCard(int entityId)
        {
			if(_cardLibrarySystem.TryGetCardEntity(entityId,out CardEntity entity))
            {
                Debug.Log($"触发添加{entity}");
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


        private void AddSelectCard(int entityId)
        {
			if(_matchSystem.TryGetPlayerEntity(ID, out PlayerEntity playerEntity))
            {
                playerEntity.AddSelectCard(entityId);
            }
		}

        #endregion


    }
}