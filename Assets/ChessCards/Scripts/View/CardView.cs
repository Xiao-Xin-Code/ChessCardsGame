using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace ChessCards
{
    public class CardView : BaseView,
        IPointerDownHandler,IPointerUpHandler
    {
        [SerializeField] RectTransform rectTransform;

        [SerializeField] Image rankIcon;


        public RectTransform RectTransform { get => rectTransform; }



        event Action<PointerEventData> onPointerDownEvent;
        event Action<PointerEventData> onPointerUpEvent;



        public void OnPointerDown(PointerEventData eventData)
        {
            onPointerDownEvent?.Invoke(eventData);
        }

        public void OnPointerUp(PointerEventData eventData)
        {
            onPointerUpEvent?.Invoke(eventData);
        }



        public void RegisterPointerDown(Action<PointerEventData> action)
        {

        }

        public void RegisterPointerUp(Action<PointerEventData> action)
        {

        }

        public void UnRegisterDown(Action<PointerEventData> action)
        {

        }

        public void UnRegisterPointerUp(Action<PointerEventData> action)
        {

        }



        public void UpdateIcon(Sprite sprite)
        {
            rankIcon.sprite = sprite;
        }
    }
}

