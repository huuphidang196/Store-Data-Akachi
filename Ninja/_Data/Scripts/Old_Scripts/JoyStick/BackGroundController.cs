using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackGroundController : MonoBehaviour
{
    public Rigidbody2D Rig;
    GameObject obj;
    // Start is called before the first frame update
    void Start()
    {
        obj = gameObject;
        Rig = GetComponent<Rigidbody2D>();
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
     void OnTriggerEnter2D(Collider2D vCham)
    {
        
    }
}
