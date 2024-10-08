using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NJst : MonoBehaviour
{
    public float moveSpeed;
    private GameObject obj;
    public bool Right;
    Animator anim;
  
    // Start is called before the first frame update
    void Start()
    {
        obj = gameObject;
        moveSpeed = 20f;
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {   
        if (Right == true )
        {
            obj.transform.Translate(new Vector3(1 * Time.deltaTime * moveSpeed, 0, 0));
            Vector3 scale = transform.localScale;
            scale.x = 0.7f;
            transform.localScale = scale; 
        }

        else if (Right == false )
        {
            obj.transform.Translate(new Vector3(-1 * Time.deltaTime * moveSpeed, 0, 0));
            Vector3 scale = transform.localScale;
            scale.x = -0.7f;
            transform.localScale = scale;
        }
    }
    public void OnTriggerEnter2D(Collider2D sta)
    {
        if(sta.gameObject.tag == "Ground")
        {
            StartCoroutine(TN());
            moveSpeed = 0;
            anim.SetTrigger("VaCham");
           
        }

        if (sta.gameObject.tag == "GroundV")
        {
            StartCoroutine(TN());
            moveSpeed = 0;
            anim.SetTrigger("VaCham");
        }
        if (sta.gameObject.tag == "StoneVR")
        {
            StartCoroutine(TN());
            moveSpeed = 0;
            anim.SetTrigger("VaCham");
        }
        if (sta.gameObject.tag == "BanXoay1")
        {
            StartCoroutine(TN());
            moveSpeed = 0;
            anim.SetTrigger("VaCham");
        }
        if (sta.gameObject.tag == "Enemy")            //enemy này là các phụ kiện ko phản bandit
        {
            StartCoroutine(TN());
            moveSpeed = 0;
            anim.SetTrigger("VaCham");
        }
        if (sta.gameObject.tag == "Enemy1")            
        {
            StartCoroutine(TN());
            moveSpeed = 0;
            anim.SetTrigger("VaCham");
        }
        if (sta.gameObject.tag == "Enemy2")           
        {
            StartCoroutine(TN());
            moveSpeed = 0;
            anim.SetTrigger("VaCham");
        }
        if (sta.gameObject.tag == "Enemy3")            
        {
            StartCoroutine(TN());
            moveSpeed = 0;
            anim.SetTrigger("VaCham");
        }
        if (sta.gameObject.tag == "WBox")
        {
            StartCoroutine(TN());
            moveSpeed = 0;
            anim.SetTrigger("VaCham");
        }
        if (sta.gameObject.tag == "WBox2")
        {
            StartCoroutine(TN());
            moveSpeed = 0;
            anim.SetTrigger("VaCham");
        }
        if (sta.gameObject.tag == "Box")
        {
            StartCoroutine(TN());
            moveSpeed = 0;
            anim.SetTrigger("VaCham");
        }
        if (sta.gameObject.tag == "CircleChan")
        {
            StartCoroutine(TN());
            moveSpeed = 0;
            anim.SetTrigger("VaCham");
            GetComponent<Collider2D>().isTrigger = false; 
        }
        //LVBoss
        if (sta.gameObject.tag == "BodyBoss")
        {
            StartCoroutine(TN());
            moveSpeed = 0;
            anim.SetTrigger("VaCham");

        }
    }    

    public IEnumerator TN()
    {
        yield return new WaitForSeconds(0.5f);
        Destroy(gameObject);
    }
}
