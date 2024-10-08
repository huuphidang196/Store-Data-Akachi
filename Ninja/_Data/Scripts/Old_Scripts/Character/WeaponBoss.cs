using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponBoss : MonoBehaviour
{
    public GameObject Player;
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
            Player.GetComponent<Player>().AllowDie = false;
        }
        if (collision.tag == "Player")
        {
            Player.GetComponent<Player>().AllowDie = true;
        }
    }
      
}
