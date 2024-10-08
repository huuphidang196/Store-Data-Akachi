using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoneSkyDrop : MonoBehaviour
{
    private Vector3 oldPosition;

    // Start is called before the first frame update
    void Start()
    {
        oldPosition = gameObject.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
       
    }
    public IEnumerator SetPosition()
    {
        yield return new WaitForSeconds(5);
        gameObject.transform.position = oldPosition;
        GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Static;
        GetComponent<Collider2D>().isTrigger = false;

    }    
    public void OnCollisionEnter2D(Collision2D col)
    {
        if(col.gameObject.tag == "Player")
        {
            StartCoroutine(DropStoneSky());
        }    
    }
    private IEnumerator DropStoneSky()
    {
        yield return new WaitForSeconds(1.5f);
        GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Dynamic;
        GetComponent<Collider2D>().isTrigger = true;
        StartCoroutine(SetPosition());
        
        
    }   
}
