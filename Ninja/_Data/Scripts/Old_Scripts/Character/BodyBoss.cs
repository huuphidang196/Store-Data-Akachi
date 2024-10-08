using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BodyBoss : MonoBehaviour
{
    public GameObject Boss;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "KN2")
        {
            Boss.GetComponent<Boss>().IsAttackKN2();
        }    
        if(collision.tag == "St")
        {
            Boss.GetComponent<Boss>().IsAttackedSt();
        }    
    }
}
