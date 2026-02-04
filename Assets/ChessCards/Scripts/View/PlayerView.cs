using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace ChessCards
{

    public class PlayerView : BaseView
    {
        [SerializeField] Image roleImage;

        [SerializeField] RectTransform rectTransform;

        [SerializeField] RectTransform handRectTransform;


        public RectTransform RectTransform { get => rectTransform; }

        public RectTransform HandRectTransform { get => handRectTransform; }



        public void UpdateRole(Sprite sprite)
        {
            roleImage.sprite = sprite;
        }
    }
}


