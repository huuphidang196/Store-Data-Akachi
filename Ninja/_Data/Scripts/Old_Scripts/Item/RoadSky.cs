using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoadSky : MonoBehaviour
{
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void Drop()
    {
        //GetComponent<Collider2D>().enabled = false;
        //this.enabled = false;
        GetComponent<Collider2D>().isTrigger = true;
    }
}
