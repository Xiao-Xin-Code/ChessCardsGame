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
		MatchModel _matchModel;


		public override void Init()
        {
            _cardLibrarySystem = this.GetSystem<CardLibrarySystem>();
            _assetSystem = this.GetSystem<AssetSystem>();
            _matchSystem = this.GetSystem<MatchSystem>();
		}




        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.P))
            {
                handCards.Sort();
                handCards.Arrange();
            }

            if (Input.GetKeyDown(KeyCode.K))
            {
                _matchSystem.TryGetPlayerEntity(ID, out PlayerEntity entity);
                entity.SetRole(PlayerRole.Landlord);
            }
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
            
            if(role == PlayerRole.Landlord)
            {
                _matchSystem.TryGetPlayerEntity(ID, out PlayerEntity entity);
                foreach (var card in _cardLibrarySystem.TrumpCards)
                {
                    entity.AddHandCard(card);
                    entity.AddSelectCard(card);
                }


                //初始设置
                _matchSystem.SetPreviousHome(ID);
                _matchSystem.SetCurrentHome(ID);
                //直接设置
                this.SendCommand(new AffordVisibleCommand(true));
                this.SendCommand(new ActiveAffordCommand(true, false));

            }
        }

        public void OnTurnChanged()
        {
            if(_matchModel.State.Value == GameState.CallScore)
            {

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