using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChongCenter : MonoBehaviour
{

    public float moveSpeed = 5f;
    public bool moveRight, Up;
    GameObject obj;
    // Start is called before the first frame update
    void Start()
    {
        obj = gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        if (PlayerPrefs.GetInt("i") != 14)
        {
            if (moveRight)
            {
                transform.Translate(1 * Time.deltaTime * moveSpeed, 0, 0);
                transform.localScale = new Vector2(2, 2);

            }
            else
            {
                transform.Translate(-1 * Time.deltaTime * moveSpeed, 0, 0);
                transform.localScale = new Vector2(-2, 2);
            }
        }
        else if(PlayerPrefs.GetInt("i") == 14)
        {
            if (Up)
            {
                transform.Translate( 0, 0.6f * Time.deltaTime * moveSpeed, 0);
            }
            else
            {
                transform.Translate (0, -0.6f * Time.deltaTime * moveSpeed, 0);
            }
        }    
    }
    void OnTriggerEnter2D(Collider2D turnC)
    {
        if (turnC.gameObject.tag=="TurnC")
        {
            if (moveRight) { moveRight = false; }
            else { moveRight = true; }
        }
        else if (PlayerPrefs.GetInt("i") == 14)
        {
            if (turnC.gameObject.tag == "Turn2")
            {
                if (Up == true) { Up = false; }
                else { Up = true; }
            }
        }

    }
}
