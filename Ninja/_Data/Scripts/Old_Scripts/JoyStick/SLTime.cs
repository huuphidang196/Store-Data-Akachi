using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SLTime : MonoBehaviour
{
    public Slider slTime;
    public float timer = 5f;
    private float timeBurn = 1f;
    public bool isFirst;
    public GameObject pLayer;
    // Start is called before the first frame update
    void Start()
    {
        slTime.minValue = 0f;
        slTime.maxValue = timer;
        slTime.value = slTime.minValue;
        pLayer = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {   if (isFirst == true)
        { 
            slTime.value = timer;
            timer -= timeBurn * Time.deltaTime;
            slTime.value = timer;
            if(slTime.value==0)
            {
                isFirst = false;
                pLayer.GetComponent<Player>().Hide();
            }
        }
          
        if(isFirst==false)
        {
            slTime.value = 0f;
            timer = 5f;
        }    
    }
}
