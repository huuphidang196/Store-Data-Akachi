using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFoot : MonoBehaviour
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
    public void OnTriggerEnter2D(Collider2D col)
    {
        if (col.tag == "Ground")
        {
            Player.GetComponent<Player>().isGrounded = true;
            Player.GetComponent<Player>().Jump.GetComponent<Jump>().Ablebtn(); 
        }    
        else if (col.tag == "GroundStoneSky")
        {
            Player.GetComponent<Player>().isGrounded = true;
            Player.GetComponent<Player>().Jump.GetComponent<Jump>().Ablebtn();
           // GetComponent<Rigidbody2D>().gravityScale = 3;
        }
        else if (col.tag == "StoneRoadMove")
        {
            Player.GetComponent<Player>().isGrounded = true;
            Player.GetComponent<Player>().Jump.GetComponent<Jump>().Ablebtn();
            //Player.GetComponent<Player>().GetComponent<Rigidbody2D>().gravityScale = 3;
        }
        else if (col.tag == "StoneSkyDrop")
        {
            Player.GetComponent<Player>().isGrounded = true;
            Player.GetComponent<Player>().Jump.GetComponent<Jump>().Ablebtn();
        //    Player.GetComponent<Player>().GetComponent<Rigidbody2D>().gravityScale = 3;
        }
        

        else if (col.tag != "Ground" && col.tag != "GroundStoneSky" && col.tag != "StoneRoadMove" && col.tag != "StoneSkyDrop" && col.tag != "WBox" && col.tag != "Box" && col.tag == "Player")
        {
            Player.GetComponent<Player>().isGrounded = false;
        }
       
         
    }
    public void OnTriggerStay2D(Collider2D col)
    {
        if (col.tag == "Ground")
        {
            Player.GetComponent<Player>().isGrounded = true;
            Player.GetComponent<Player>().Jump.GetComponent<Jump>().Ablebtn();
            // Player.GetComponent<Player>().GetComponent<Rigidbody2D>().gravityScale = 3;
        }
        else if (col.tag == "GroundStoneSky")
        {
            Player.GetComponent<Player>().isGrounded = true;
            Player.GetComponent<Player>().Jump.GetComponent<Jump>().Ablebtn();
            // GetComponent<Rigidbody2D>().gravityScale = 3;
        }
        else if (col.tag == "StoneRoadMove")
        {
            Player.GetComponent<Player>().isGrounded = true;
            Player.GetComponent<Player>().Jump.GetComponent<Jump>().Ablebtn();
            //Player.GetComponent<Player>().GetComponent<Rigidbody2D>().gravityScale = 3;
        }
        else if (col.tag == "StoneSkyDrop")
        {

            Player.GetComponent<Player>().isGrounded = true;
            Player.GetComponent<Player>().Jump.GetComponent<Jump>().Ablebtn();
            //    Player.GetComponent<Player>().GetComponent<Rigidbody2D>().gravityScale = 3;
        }
        
        else if (col.tag == "Box")
        {

            Player.GetComponent<Player>().isGrounded = true;
            Player.GetComponent<Player>().Jump.GetComponent<Jump>().Ablebtn();
            //  Player.GetComponent<Player>().GetComponent<Rigidbody2D>().gravityScale = 3;
        }
        else if (col.tag != "Ground" && col.tag != "GroundStoneSky" && col.tag != "StoneRoadMove" && col.tag != "StoneSkyDrop" && col.tag != "WBox" && col.tag != "Box" && col.tag == "Player")
        {
            Player.GetComponent<Player>().isGrounded = false;
        }
      
        
    }
    public void OnTriggerExit2D(Collider2D col)
    {
        if(col.tag == "Ground")
        {
            Player.GetComponent<Player>().isGrounded = false;
            
        }
    }
}
