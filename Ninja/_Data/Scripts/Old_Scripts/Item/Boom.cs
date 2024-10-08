using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boom : MonoBehaviour
{
    Animator anim;
    public GameObject Player;

    private AudioSource audi;
    public AudioClip Bust;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        audi = GetComponent<AudioSource>();
        StartCoroutine(BustSource());
    }

    // Update is called once per frame
    void Update()
    {
        StartCoroutine(BoomDestroys());
        if(Player.GetComponent<Player>().isDied ==true)
        {
            Destroy(gameObject);
        }    
    }
    public IEnumerator BoomDestroys()
    {
        gameObject.tag = "Untagged";
        yield return new WaitForSeconds(1);
        GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Kinematic;
        anim.SetTrigger("Bum");
        
        gameObject.tag = "Boom";
        yield return new WaitForSeconds(2);
        Destroy(gameObject);
    } 
    public IEnumerator BustSource()
    {
        yield return new WaitForSeconds(1f);
        audi.clip = Bust;
        audi.Play();
    }    
    
}
