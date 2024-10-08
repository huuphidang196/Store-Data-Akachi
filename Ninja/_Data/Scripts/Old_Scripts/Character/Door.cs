using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    public float moveSpeed;
    public bool AllowMove;
    public bool Up; 
    // Start is called before the first frame update
    void Start()
    {
        AllowMove = false;
        Up = true;   /// để khi hdong là = false ko thay đôi cái này    
    }

    // Update is called once per frame
    void Update()
    {
        if(Up == true)
        {
            gameObject.transform.Translate(0, 1 * moveSpeed * Time.deltaTime, 0);
        }
        else
        {
            gameObject.transform.Translate(0, -1 * moveSpeed * Time.deltaTime, 0);
        } 
            
    }
    public void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Turn2")
        {
            if (Up == false)
            {
                Up = true;
            }
            else if (Up == true)
            {
                Up = false;
            }
            moveSpeed = 0;
        }
          
    }
}
