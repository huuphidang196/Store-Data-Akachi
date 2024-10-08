using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stone2 : MonoBehaviour
{
    Animator anim;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {

    }
    public void Anim2()
    {
        anim.SetBool("Run", true);
    }

}
