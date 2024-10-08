using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhunNguocAni : MonoBehaviour
{
    private Animator anim, anim2, anim3;
    private Rigidbody2D Rid;
    public GameObject phunAni;
    public bool Hai;
    public int i = 0;
    // Start is called before the first frame update
    public void Awake()
    {
        anim = GetComponent<Animator>();
    }
    void Start()
    {
        
       
    }

    // Update is called once per frame
    void Update()
    {
        if (PlayerPrefs.GetInt("i") == 13 || PlayerPrefs.GetInt("i") == 11)
        {
            Hai = false;
            if (i == 0)
            {
                StartCoroutine(PhunNguoc());
            }
        }
    }
    public IEnumerator PhunNguoc()
    {
        if(Hai == false)
        {
            i++;
            yield return new WaitForSeconds(0.01f);
            if (i == 1)
            { 
                if (PlayerPrefs.GetInt("i") == 13 || PlayerPrefs.GetInt("i") == 11)
                {
                   Instantiate(phunAni, new Vector3(gameObject.transform.position.x + 5, gameObject.transform.position.y, 0), Quaternion.identity);
                    
                   
                } 
            }
            yield return new WaitForSeconds(0.01f);
            i++;
            if (i == 2)
            {
                if (PlayerPrefs.GetInt("i") == 13 || PlayerPrefs.GetInt("i") == 11)
                {
                    Instantiate(phunAni, new Vector3(gameObject.transform.position.x + 10, gameObject.transform.position.y, 0), Quaternion.identity);
                    
                }
            }
        }    
    }
    public void OnTriggerEnter2D(Collider2D collision)
    {
       if(collision.tag == "First")
       {
           anim.SetTrigger("VaCham");
       }   
       else if(collision.tag == "End")
       {
            anim.SetTrigger("ExitCol");
       }    
    }
    
    public void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.tag == "First")
        {
            anim.SetTrigger("VaCham");
        }
        else if (collision.tag == "End")
        {
            anim.SetTrigger("ExitCol");
        }
    }
    
        


}









