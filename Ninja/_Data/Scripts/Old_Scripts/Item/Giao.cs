using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Giao : MonoBehaviour
{
    Animator anim;
    public AudioClip giaoClip;
    AudioSource audi;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        audi = GetComponent<AudioSource>();
        audi.clip = null;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void TurnOn()
    {
        
        StartCoroutine(SetTag());
    }
    public IEnumerator SetTag()
    {
        anim.SetTrigger("TurnOn");
        audi.clip = giaoClip;
        audi.Play();
        yield return new WaitForSeconds(3.15f);
        gameObject.tag = "Enemy";
        audi.clip = null;
        audi.volume = 0;
    }    
}
