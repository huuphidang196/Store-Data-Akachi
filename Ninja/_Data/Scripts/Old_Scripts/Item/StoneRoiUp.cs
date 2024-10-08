using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoneRoiUp : MonoBehaviour
{
    private Vector3 oldLocation;
    Rigidbody2D Rid;
    // Start is called before the first frame update
    private void Awake()
    {
        oldLocation = gameObject.transform.position;
    }
    void Start()
    {
        Rid = GetComponent<Rigidbody2D>();
       
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {        
            StartCoroutine(SetLocationST());
        }    
        //if(collision.gameObject.tag == "Enemy")
        //{
        //    gameObject.GetComponent<BoxCollider2D>().isTrigger = true;
        //}    
    }
    public IEnumerator SetLocationST()
    {
        yield return new WaitForSeconds(0.1f);
        Rid.bodyType = RigidbodyType2D.Dynamic;
        yield return new WaitForSeconds(5);
        gameObject.transform.position = oldLocation;
        gameObject.transform.rotation = new Quaternion(0, 0, 0,0);
        Rid.bodyType = RigidbodyType2D.Static;
       // gameObject.GetComponent<BoxCollider2D>().isTrigger = false;

    }    
    public IEnumerator LatchingLocate()
    {
        yield return new WaitForSeconds(5);
        Rid.bodyType = RigidbodyType2D.Kinematic;
    }    
}
