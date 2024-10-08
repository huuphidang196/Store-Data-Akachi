using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class txtGoldBoxCreat : MonoBehaviour
{
    GameObject gameController;
    int CsGb, DmC;
    // Start is called before the first frame update
    void Start()
    {
        if(gameController == null)
        {
            gameController = GameObject.FindGameObjectWithTag("GameController");
        }

    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void FlyGB()
    {
        int Gb = Random.Range(10, 22);
        PlayerPrefs.SetInt("Gb", Gb);//Dùng cho text Fly
        gameObject.GetComponent<TextMesh>().text = "+" +PlayerPrefs.GetInt("Gb");
        gameObject.GetComponent<TextMesh>().color = Color.yellow;
        Destroy(gameObject, 1);
    }  
    public void FlyDm()
    {
        int DmC = Random.Range(1, 2);
        PlayerPrefs.SetInt("DmC", DmC); //Dùng cho text Fly

        gameObject.GetComponent<TextMesh>().text = "+" + PlayerPrefs.GetInt("DmC");
        gameObject.GetComponent<TextMesh>().color = Color.blue;
        Destroy(gameObject, 1);
    }    
}
