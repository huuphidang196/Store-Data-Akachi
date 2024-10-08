using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoneCNhonUpDown : MonoBehaviour
{
    private int Speed = 1;
    public bool Up;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void FixedUpdate()
    {
        if (Up == true)
        {
            gameObject.transform.Translate(new Vector3(0, Speed * Time.deltaTime * 1, 0));
        }
        else if(Up == false)
        {
            gameObject.transform.Translate(new Vector3(0, Speed * Time.deltaTime * -1, 0));
        }    
    }
    public void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag =="Turn2")
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
