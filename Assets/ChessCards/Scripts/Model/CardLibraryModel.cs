using System.Collections.Generic;
using QMVC;

namespace ChessCards
{

	public class CardLibraryModel : AbstractModel
	{
        public Dictionary<int, CardEntity> cards = new Dictionary<int, CardEntity>();


        public List<int> cardLibrary = new List<int>();
        public List<int> trumpCards = new List<int>();

        protected override void OnInit()
        {
            
        }
	}

}

