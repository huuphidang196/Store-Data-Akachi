using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoneHidden : MonoBehaviour
{
    public GameObject transferTurn2 ;
    public GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(player.GetComponent<Player>().currentLocation.x);
    }
    public void TransferHidden()
    {
        if ( PlayerPrefs.GetInt("i") != 12 && PlayerPrefs.GetInt("i") != 13 && PlayerPrefs.GetInt("i") != 14)
        {
            transferTurn2.GetComponent<Collider2D>().isTrigger = true;
            transferTurn2.tag = "Turn2";
        }
        else if (PlayerPrefs.GetInt("i") == 12)
        {
            if (player.GetComponent<Player>().currentLocation.x < 350)
            {
                transferTurn2.GetComponent<Collider2D>().isTrigger = true;
                transferTurn2.tag = "Turn2";
            }
        }
        else if(PlayerPrefs.GetInt("i") == 13)
        {
            if(player.GetComponent<Player>().currentLocation.x < 266)
            {
                transferTurn2.GetComponent<Collider2D>().isTrigger = true;
                transferTurn2.tag = "Turn2";
            }
        }
        else if (PlayerPrefs.GetInt("i") == 14)
        {
            if (player.GetComponent<Player>().currentLocation.x < 125)
            {
                transferTurn2.GetComponent<Collider2D>().isTrigger = true;
                transferTurn2.tag = "Turn2";
            }
        }

        else if (PlayerPrefs.GetInt("i") == 15)
        {
            if (player.GetComponent<Player>().currentLocation.x < 220)
            {
                transferTurn2.GetComponent<Collider2D>().isTrigger = true;
                transferTurn2.tag = "Turn2";
            }
        }

        else if (PlayerPrefs.GetInt("i") == 16)
        {
            if (player.GetComponent<Player>().currentLocation.x < 150)
            {
                transferTurn2.GetComponent<Collider2D>().isTrigger = true;
                transferTurn2.tag = "Turn2";
            }
        }
    } 
    public void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Enemy2")
        {
            GetComponent<Collider2D>().isTrigger = false;
            gameObject.tag = "Ground";
        }

    }
}
