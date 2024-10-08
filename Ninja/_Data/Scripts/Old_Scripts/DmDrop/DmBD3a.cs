using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DmBD3a : MonoBehaviour
{
    Animator anim;
    // Start is called before the first frame update
    private void Awake()
    {
        anim = GetComponent<Animator>();
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void Xhien()
    {
        anim.SetTrigger("Move");
    }
    public void Destroy()
    {
        Destroy(gameObject);

    }    
}
