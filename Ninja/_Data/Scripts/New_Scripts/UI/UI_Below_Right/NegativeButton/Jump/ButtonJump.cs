using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ButtonJump : BaseButton, IPointerDownHandler, IPointerUpHandler
{
    public void OnPointerDown(PointerEventData eventData)
    {
        InputManager.Instance.PointerJumpDown();
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        InputManager.Instance.PointerJumpUp();
    }


}
