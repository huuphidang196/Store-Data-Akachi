using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoneMoveSky : MonoBehaviour
{
    public int moveSpeed = 3;

    public GameObject pLayer;

    public bool Right;
    public bool isSpaceSky;

    public Vector3 newLocationLv4, newLocationLv10a, newLocationLv10b, newLocationLv12, newLocation13a, newLocation13b, newLocationSpecial13a, newLocationSpecial13b;
    // Start is called before the first frame update
    void Start()
    {
        Right = true;
        newLocationLv4 = new Vector3(230, 3, 0);
        newLocationLv10a = new Vector3(197, -4.33f, 0);
        newLocationLv10b = new Vector3(302.5f, 0.95f, 0);
        newLocationLv12 = new Vector3(275, 1, 0);
        newLocation13a = new Vector3(271.66f, 4.37f, 0);
        newLocation13b = new Vector3(273.65f, 4.37f, 0);
        newLocationSpecial13a = new Vector3(246.27f, 1.63f, 0);
        newLocationSpecial13b = new Vector3(287.3f, 1.63f, 0);
    }

    // Update is called once per frame
    void Update()
    {
        if (Right == true)
        {
             gameObject.transform.Translate(new Vector3(1 * Time.deltaTime * moveSpeed, 0, 0));
        }
        else if(Right ==false)
        {
             gameObject.transform.Translate(new Vector3(-1 * Time.deltaTime * moveSpeed, 0, 0));
        }
        
        if (isSpaceSky == true)
        {
             pLayer.transform.SetParent(this.transform);
        }
        else if (isSpaceSky == false)
        {
            pLayer.transform.SetParent(null);
        }
        
    }
    public void OnTriggerEnter2D(Collider2D col)
    {
        if(col.tag == "Turn2")
        {
            if(Right)
            {
                Right = false;
            }
            else
            {
                Right = true;
            }
        }
        
    }
    public void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            isSpaceSky = true;
        }
    }
    
    public void OnCollisionExit2D(Collision2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            isSpaceSky = false;
        }
    }
    public void SetLocation()
    {
        if (PlayerPrefs.GetInt("i") == 5)
        {
            gameObject.transform.position = newLocationLv4;
        }
        else if (PlayerPrefs.GetInt("i") == 11)
        {
            if (pLayer.GetComponent<Player>().transform.position.x <= newLocationLv10a.x)
            { 
                gameObject.transform.position = newLocationLv10a; 
            }
            else if(newLocationLv10a.x <= pLayer.GetComponent<Player>().transform.position.x && pLayer.GetComponent<Player>().transform.position.x  <= newLocationLv10b.x)
            {
                gameObject.transform.position = newLocationLv10b;
            }    
        }
        else if (PlayerPrefs.GetInt("i") == 13)
        {
            if (pLayer.GetComponent<Player>().transform.position.x <= newLocationLv12.x)
            {
                gameObject.transform.position = newLocationLv12;
            }
        }
        else if (PlayerPrefs.GetInt("i") == 14)
        {
            if (pLayer.GetComponent<Player>().transform.position.x <= newLocation13a.x)
            {
                gameObject.transform.position = newLocationSpecial13a;
            }
            else if (pLayer.GetComponent<Player>().transform.position.x >= newLocation13b.x)
            {
                gameObject.transform.position = newLocationSpecial13b;
            }
        }
    }    
}
