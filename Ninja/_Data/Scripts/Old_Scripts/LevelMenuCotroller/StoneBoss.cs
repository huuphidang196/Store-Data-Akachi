using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoneBoss : MonoBehaviour
{
    Rigidbody2D rid;
    Vector3 Scale;
    public GameObject Boss;
    int moveForce ;

    public bool hitSky, hit6, hit7, hit8, hit9;
    // Start is called before the first frame update
    public void Awake()
    {
        Boss = GameObject.FindGameObjectWithTag("Bossct"); 
        rid = gameObject.GetComponent<Rigidbody2D>();
        Scale = Boss.transform.localScale;

        hitSky = Boss.GetComponent<Boss>().hitSky;
        hit6 = Boss.GetComponent<Boss>().hitSky6;
        hit7 = Boss.GetComponent<Boss>().hitSky7;
        hit8 = Boss.GetComponent<Boss>().hitSky8;
        hit9 = Boss.GetComponent<Boss>().hitSky9;
    }
    void Start()
    {
        if(hitSky == false)
        {
            moveForce = 1200;
            rid.AddForce(new Vector2(0.5f * Scale.x * -moveForce, 0.09f * moveForce));
        }    
        if(hit6 == true || hit9 == true)
        {
            moveForce = 1200 ;
            rid.AddForce(new Vector2(0.5f * Scale.x * -moveForce,0.45f* moveForce));
        }
        if (hit7 == true || hit8 == true)
        {
            moveForce = 1200;
            rid.AddForce(new Vector2(0.5f * Scale.x * -moveForce, 0.9f * moveForce));
        }

    }

    // Update is called once per frame
    void Update()
    {
       
    }
    public void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Player" || collision.gameObject.tag == "Ground")
        {
            moveForce = 0;
            Destroy(gameObject, 1);
        }    
    }
    public void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "KN2")
        {
            Destroy(gameObject);    
        }    
    }

}
