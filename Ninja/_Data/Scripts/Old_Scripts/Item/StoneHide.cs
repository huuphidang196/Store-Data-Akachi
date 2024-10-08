using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoneHide : MonoBehaviour
{
    private int maxHealthy=10, currentHealthy, damage=5;
    // Start is called before the first frame update
    void Start()
    {
        currentHealthy = maxHealthy;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void OnTriggerEnter2D(Collider2D col)
    {
        if(col.tag=="St" )
        {
            currentHealthy -= damage;
            if(currentHealthy<=0)
            {
                GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Dynamic;
                GetComponent<Collider2D>().isTrigger = true;
            }    
        } 
        if(col.tag == "KN2")
        {
            GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Dynamic;
            GetComponent<Collider2D>().isTrigger = true;
        }    
    }
}
