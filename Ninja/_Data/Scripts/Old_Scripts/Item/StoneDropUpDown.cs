using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoneDropUpDown : MonoBehaviour
{
    public float moveSpeed=15f;
    public bool Up;
    // Start is called before the first frame update
    void Start()
    {
        Up = false;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (Up == true)
        {
            gameObject.transform.Translate(new Vector3(0, 1 * Time.deltaTime * moveSpeed, 0));
        }
        else
        {
            gameObject.transform.Translate(new Vector3(0, -1 * Time.deltaTime * moveSpeed, 0));
        } 
            
    }
    public void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Turn2")
        { 
            if(Up ==true)
            {   
                StartCoroutine(SetMoveDown());           
            }   
            else if(Up == false)
            {
                StartCoroutine(SetMoveUp());
            }    
        }    
    }
    public void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.tag == "Turn2")
        {
            if (Up == true)
            {
                StartCoroutine(SetMoveDown());
            }
            else if (Up == false)
            {
                StartCoroutine(SetMoveUp());
            }
        }
    }
    public IEnumerator SetMoveDown()
    {
        if (gameObject.transform.position.y >= -3.234f)
        {
            moveSpeed = 0;
            gameObject.transform.position = new Vector3(gameObject.transform.position.x, -3.234f, 0);
        }    
        yield return new WaitForSeconds(5);
        Up = false;
        moveSpeed = 10;
    }
    public IEnumerator SetMoveUp()
    {
        if (gameObject.transform.position.y <= -9.82f)
        {
            moveSpeed = 0;
            gameObject.transform.position = new Vector3(gameObject.transform.position.x, -9.82f, 0);
        }
        yield return new WaitForSeconds(3);
        Up = true;
        moveSpeed = 10;
    }
}
