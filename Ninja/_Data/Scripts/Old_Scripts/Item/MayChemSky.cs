using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MayChemSky : MonoBehaviour
{
    public float Speed;
    private int k;
    private Vector3 targetPosition;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        k++;
        targetPosition = new Vector3(0, 0, k);
        transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.Euler(targetPosition), Speed * Time.deltaTime);
    }
}
