using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wbox : MonoBehaviour
{
    public GameObject GoldBox, dmWBox, boom;
    GameObject obj;
    int i;
    public int hesoBoom;
    // Start is called before the first frame update
    void Start()
    {
        obj = gameObject;
        GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Kinematic;
        GetComponent<Collider2D>().isTrigger = true;
        hesoBoom = 0;
        if(PlayerPrefs.GetInt("i") == 2)
        {
            boom = null;
        }    

    }

    // Update is called once per frame
    void Update()
    {
       
    }
    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "St")
        { 
            Destroy(gameObject);
            i=Random.Range(1, 10);
            if (hesoBoom == 0)
            {
                if (i == 2 || i == 4 || i == 7 || i == 1)
                {
                    Instantiate(GoldBox, obj.transform.position, Quaternion.identity);
                    Instantiate(GoldBox, new Vector3(obj.transform.position.x + 2, obj.transform.position.y, obj.transform.position.z), Quaternion.identity);
                }
                else if (i == 3 )
                {
                    Instantiate(dmWBox, new Vector3(obj.transform.position.x + 1, obj.transform.position.y, obj.transform.position.z), Quaternion.identity);
                }
                // i =5 ra rỗng  
                else if (i == 6 || i == 9)
                {
                    Instantiate(boom, obj.transform.position, Quaternion.identity);
                }
            }
            else if(hesoBoom == 1)
            {
                if (i != 6)
                {
                    Instantiate(boom, obj.transform.position, Quaternion.identity);
                }
            }    
        }
        if (collision.tag == "KN2")
        {
            Destroy(gameObject);
            Instantiate(GoldBox, gameObject.transform.position, Quaternion.identity);
        }
    }
   
}
