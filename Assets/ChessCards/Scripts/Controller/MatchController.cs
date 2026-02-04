using System.Collections;
using System.Collections.Generic;
using System.Linq;
using QMVC;
using UnityEngine;

namespace ChessCards
{
    public class MatchController : MonoController
    {

        MatchSystem _matchSystem;
        CardLibrarySystem _cardLibrarySystem;
        MatchModel _matchModel;

        public override void Init()
        {
            _matchSystem = this.GetSystem<MatchSystem>();
            _matchModel = this.GetModel<MatchModel>();

            
		}

        private void Start()
        {
			
		}


        


    }

}

