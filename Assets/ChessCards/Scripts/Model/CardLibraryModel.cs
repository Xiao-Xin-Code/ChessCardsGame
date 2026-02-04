using System.Collections;
using System.Collections.Generic;
using QMVC;
using UnityEngine;

namespace ChessCards
{

	public class CardLibraryModel : AbstractModel
	{
        public Dictionary<int, CardEntity> cards = new Dictionary<int, CardEntity>();


        public List<int> cardLibrary = new List<int>();

        protected override void OnInit()
        {
            
        }
	}

}

