using QMVC;
using UnityEngine;

namespace ChessCards
{

	public class DeskController : MonoController
	{
        [SerializeField] MainPlayerController localPlayer;
        [SerializeField] SubPlayerController leftPlayer;
        [SerializeField] SubPlayerController rightPlayer;


        MatchSystem _matchSystem;
        MatchModel _matchModel;


        public override void Init()
        {
			_matchSystem = this.GetSystem<MatchSystem>();
            _matchModel = this.GetModel<MatchModel>();


			InitPlayerEntity();

            
		}

        private void Start()
        {
			//_matchModel.State.Value = GameState.DealCard;
		}


        private void InitPlayerEntity()
        {
            int localId = localPlayer.GetInstanceID(), leftId = leftPlayer.GetInstanceID(), rightId = rightPlayer.GetInstanceID();
            localPlayer.SetId(localId); leftPlayer.SetId(leftId); rightPlayer.SetId(rightId);
            _matchSystem.AddPlayerEntity(localId, new PlayerEntity(localPlayer.OnRoleChanged, localPlayer.AddHandCard, localPlayer.RemoveHandCard));
            _matchSystem.AddPlayerEntity(leftId, new PlayerEntity(leftPlayer.OnRoleChanged, leftPlayer.AddHandCard, leftPlayer.RemoveHandCard));
            _matchSystem.AddPlayerEntity(rightId, new PlayerEntity(rightPlayer.OnRoleChanged, rightPlayer.AddHandCard, rightPlayer.RemoveHandCard));
            _matchSystem.SetLocalHome(localId);
		}

        
	}

}

