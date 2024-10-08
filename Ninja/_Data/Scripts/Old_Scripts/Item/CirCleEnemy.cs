using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CirCleEnemy : MonoBehaviour
{

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if( collision.gameObject.tag == "Enemy")
        {
            GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Kinematic;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.tag == "VC2")
        {
            GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Dynamic;
        }    
    }
}
