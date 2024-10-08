using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Demonstrate : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void DemonstrateBuy()    
    {
        SceneManager.LoadScene(21);
    }
    public void Change()
    {
        SceneManager.LoadScene(24);
        PlayerPrefs.SetInt("i" ,24);
    }
}
