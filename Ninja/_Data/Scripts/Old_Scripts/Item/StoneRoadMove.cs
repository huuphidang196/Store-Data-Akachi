using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoneRoadMove : MonoBehaviour
{
    public float moveSpeed = 2;
    public int hesoCos = 0;
    private int i  ;
    public int n;
    private int k;
    private float R = 0.12f;
    private float K1,K2;

    public bool Up, SetD;
    //public bool isSpaceGround;
    // Start is called before the first frame update
    void Start()
    {
        if (hesoCos == 0)
        {
            Up = true;
        }
        SetD = false;
        i = 0;
    }

    // Update is called once per frame
    void Update()
    {
        i++;
        K1 = R * Mathf.Cos(moveSpeed * i / 2 * (2 * Mathf.PI) / 180);
        K2 = R * Mathf.Sin(moveSpeed * i / 2 * (2 * Mathf.PI) / 180);
        if (SetD == false)
        {
            gameObject.transform.Translate(new Vector3(K1, K2, 0));
        }
        else
        {
            gameObject.transform.Translate(new Vector3(-K1, K2, 0));
        }    
    }
 
    public void OnTriggerEnter2D(Collider2D col)
    {
        if (col.tag == "Turn2")
        {
            if (Up)
            {
                Up = false;
            }
            else
            {
                Up = true;
            }
        }
        if (col.tag == "TurnCR")
        {
            if( SetD == false)
            {
                SetD = true;
            }  
            else
            {
                SetD = false;
            }    
        }
      
    }
}
