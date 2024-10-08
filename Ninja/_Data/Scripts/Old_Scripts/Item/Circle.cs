using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Circle : MonoBehaviour
{
    public float R = 0.06f;
    public float Speed = 2f;
    public float K1, K2;
    public int i = -1;
    public GameObject Circle1, Circle2;
    // Update is called once per frame
    void Update()
    {
        if (PlayerPrefs.GetInt("i") == 13 || PlayerPrefs.GetInt("i") == 16)
        {
            i++;
            K1 = R * Mathf.Cos(Speed * i / 4 * (2 * Mathf.PI) / 180);
            K2 = R * Mathf.Sin(Speed * i / 4 * (2 * Mathf.PI) / 180);
            Circle1.transform.Translate(new Vector3(K1, K2, 0));
            Circle2.transform.Translate(new Vector3(-K1, -K2, 0));

        }
      
    }
}
