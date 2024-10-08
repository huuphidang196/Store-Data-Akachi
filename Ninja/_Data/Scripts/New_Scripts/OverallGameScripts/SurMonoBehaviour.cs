using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SurMonoBehaviour : MonoBehaviour
{
    protected virtual void Awake()
    {
        this.LoadComponents();
    }    

    protected virtual void Reset()
    {
        this.LoadComponents();
        this.ResetValue();
    }

    protected virtual void LoadComponents()
    {
        //ForOveride
    }
    
    protected virtual void Start()
    {
        
    }    
    protected virtual void ResetValue()
    {

    }

    protected virtual void OnEnable()
    {
        this.ResetValue();
    }

    protected virtual void OnDisable()
    {
       
    }
}
