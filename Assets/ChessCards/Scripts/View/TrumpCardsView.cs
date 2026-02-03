using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace ChessCards
{
	public class TrumpCardsView : BaseView
	{
		[SerializeField] Image[] trumpCards = new Image[3];


		public void SetTrumpCards(List<Sprite> sprites)
		{
			for(int i = 0; i < trumpCards.Length; i++)
			{
				trumpCards[i].sprite = sprites[i];
			}
		}
	}


}

