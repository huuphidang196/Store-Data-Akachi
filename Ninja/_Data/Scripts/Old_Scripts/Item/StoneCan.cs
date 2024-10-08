using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoneCan : MonoBehaviour
{
    private int moveSpeed = 3;
    public bool Right;
    public GameObject PhunAni;
  
    void Start()
    {
        Right = true;
    }

    // Update is called once per frame
    void Update()
    {
        if(Right==true)
        {
            gameObject.transform.Translate(new Vector3(moveSpeed * Time.deltaTime, 0, 0));
        }    
        else if(Right == false)
        {
            gameObject.transform.Translate(new Vector3(-1 * moveSpeed * Time.deltaTime, 0, 0));
        }    
    }
   
    public void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Turn2")
        {
            if(Right ==true)
            {
                Right = false;
                transform.localScale = new Vector2(-0.21f , 0.21f);
            }   
            else
            {
                Right = true;
                transform.localScale = new Vector3(0.21f , 0.21f);
            }    
           
        }
    
       
    }
    public void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.tag == "Turn2")
        {
            if (Right == true)
            {
                Right = false;
                transform.localScale = new Vector2(-0.21f, 0.21f);
            }
            else
            {
                Right = true;
                transform.localScale = new Vector3(0.21f, 0.21f);
            }

        }
    }


}
















//public void FixedUpdate()
//{
//    hitF = Physics2D.Raycast(First.transform.position , gameObject.transform.localScale.x * Vector2.right, rayLength);
//    Debug.DrawRay(First.transform.position, gameObject.transform.localScale.x * Vector2.right*rayLength  , Color.yellow, rayLength);
//    if (hitF.collider != null)
//    {
//        if(hitF.collider.tag == "Enemy")
//        {
//            PhunAni.GetComponent<PhunNguocAni>().OnEnter();
//        }    
//    }
//    hitE = Physics2D.Raycast(End.transform.position, gameObject.transform.localScale.x * Vector2.left, rayLength);
//    Debug.DrawRay(End.transform.position, gameObject.transform.localScale.x * Vector2.left * rayLength, Color.red, rayLength);
//    if (hitE.collider != null)
//    {
//        if (hitE.collider.tag == "Enemy")
//        {
//            PhunAni.GetComponent<PhunNguocAni>().OnExit();
//        }
//    }
//}
