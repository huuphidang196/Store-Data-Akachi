using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class JoyStick : MonoBehaviour, IPointerUpHandler, IPointerDownHandler
{
    private Player player;
    void Awake()
    {
        player = GameObject.Find("Player").GetComponent<Player>();

    }
    public void OnPointerDown(PointerEventData eventData1)
    {
        if (player.isDied == false)
        {
            if (gameObject.tag == "btnLeft")
            {
                if (player.OnWallLeft == false && player.CanMoveSky == false)
                {
                    player.SetMoveLeft(true);
                }
                else if (player.OnWallRight == true && player.CanMoveSky == true)
                {
                    player.SetMoveLeft(true);
                }
                player.isController = true;   // sử dụng để dừng khi chạy bắt đầu game
            }
            else if (gameObject.tag == "btnRight")
            {
                if (player.OnWallRight == false && player.CanMoveSky == false)
                {
                    player.SetMoveLeft(false);
                }
                else if (player.OnWallLeft == true && player.CanMoveSky == true)
                {
                    player.SetMoveLeft(false);
                }
                player.isController = true;
            }
        }
        else if (player.isDied == true)
        {
            player.StopMoving();
            player.audi.clip = player.DiedClip;
            player.audi.Play();
            player.isController = false;
        }
    }

    public void OnPointerUp(PointerEventData eventData1)
    {
        player.StopMoving();
        player.isController = false;
    }

}
