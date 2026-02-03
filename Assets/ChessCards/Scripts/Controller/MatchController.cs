using System.Collections;
using System.Collections.Generic;
using System.Linq;
using QMVC;
using UnityEngine;

namespace ChessCards
{
    public class MatchController : MonoController
    {
        [SerializeField] PlayerController[] players = new PlayerController[3];


        MatchSystem _matchSystem;
        CardLibrarySystem _cardLibrarySystem;
        MatchModel _matchModel;

        public override void Init()
        {
            _matchSystem = this.GetSystem<MatchSystem>();
            _matchModel = this.GetModel<MatchModel>();


            InitPlayer();

            
		}

        private void Start()
        {
			players[0].Role = PlayerRole.Landlord;
		}


        private void InitPlayer()
        {
            for(int i = 0; i < players.Length; i++)
            {
                _matchSystem.AddPlayer(players[i].GetInstanceID(), players[i]);
                _matchModel.players.Add(players[i].GetInstanceID());

			}
        }


    }

}

