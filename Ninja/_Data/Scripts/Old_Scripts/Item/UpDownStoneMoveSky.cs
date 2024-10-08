using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpDownStoneMoveSky : MonoBehaviour
{
    public float moveSpeed;
    public bool Up;
    // Start is called before the first frame update
    void Start()
    {
        Up = true;
    }

    // Update is called once per frame
    void Update()
    {
      if(Up == true)
      {
            transform.Translate(0, 1 * moveSpeed * Time.deltaTime, 0);
      }
      else if(Up == false)
      {
            transform.Translate(0,-1 * moveSpeed * Time.deltaTime, 0);
      } 
            
    }
    public void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Turn2")
        {
            if(Up == true)
            {
                Up = false;
            }
            else if(Up == false)
            {
                Up = true; 
            }
        }    
    }
}
