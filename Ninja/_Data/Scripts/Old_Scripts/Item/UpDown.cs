using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpDown : MonoBehaviour
{
    public int moveSpeed = 2;
    public bool Up;
    //public bool isSpaceGround;
    // Start is called before the first frame update
    void Start()
    {
        Up = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (Up == true)
        {
            gameObject.transform.Translate(new Vector3(1 * Time.deltaTime * moveSpeed, 0,  0));
        }
        else
        {
            gameObject.transform.Translate(new Vector3(-1 * Time.deltaTime * moveSpeed, 0,  0));
        }
        

    }
    public void OnTriggerEnter2D(Collider2D col)
    {
        if (col.tag == "Turn2")
        {
            if (Up)
            {
                Up = false;
            }
            else
            {
                Up = true;
            }
        }

    }
   
}
