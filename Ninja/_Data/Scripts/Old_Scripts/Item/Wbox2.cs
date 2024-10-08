using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wbox2 : MonoBehaviour
{
    public GameObject GoldBox, dmWBox, boom;
    GameObject obj;
    int i;
    // Start is called before the first frame update
    void Start()
    {
        obj = gameObject;
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
            Instantiate(GoldBox, obj.transform.position, Quaternion.identity);
            Instantiate(dmWBox, new Vector3(obj.transform.position.x + 2, obj.transform.position.y, obj.transform.position.z), Quaternion.identity);
            i = Random.Range(1, 3);
            if (i == 2 || i==1)
            {
                Instantiate(boom, obj.transform.position, Quaternion.identity);
            }
           
        }


        if (collision.tag == "KN2")
        {
            Destroy(gameObject);
            Instantiate(GoldBox, gameObject.transform.position, Quaternion.identity);
        }
    }
}
