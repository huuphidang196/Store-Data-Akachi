using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GRedDrop : MonoBehaviour
{
   
    public int moveDrop=15;
    public AudioClip PikeClip;
    AudioSource audi;
    // Start is called before the first frame update
    void Start()
    {
        gameObject.transform.Rotate(0, 0, Random.Range(120, 180));
        audi = GetComponent<AudioSource>();
        audi.clip = PikeClip;
        audi.Play();   
    }

    // Update is called once per frame
    void Update()
    {
        gameObject.transform.Translate(0, 1 * Time.deltaTime * moveDrop, 0);
       
    }
    public void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Turn2")
        {
            moveDrop = 0;
            GetComponent<Collider2D>().isTrigger = true;
            gameObject.tag = "Untagged";
        }    
    }

}
