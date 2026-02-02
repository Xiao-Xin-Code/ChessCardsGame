using QMVC;
using System.Collections.Generic;

namespace ChessCards
{
    public class MatchSystem : AbstractSystem
    {
        Dictionary<int, CardController> matchCards = new Dictionary<int, CardController>();
        Dictionary<int, PlayerController> matchPlayers = new Dictionary<int, PlayerController>();




        protected override void OnInit()
        {
            
        }



        #region Cards²Ù×÷

        public bool TryGetCard(int id, out CardController card)
        {
            return matchCards.TryGetValue(id, out card);
        }

        #endregion

        #region Player

        public bool TryGetPlayer(int id, out PlayerController player)
        {
            return matchPlayers.TryGetValue(id, out player);
        }

        #endregion
    }
}


