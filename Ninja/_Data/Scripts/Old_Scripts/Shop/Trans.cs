using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Trans : MonoBehaviour
{
    public Text txtIntro;
    public int addGold;

    public GameObject GoogleAds;
    // Start is called before the first frame update
    void Start()
    {
        txtIntro.text = "You have " + PlayerPrefs.GetInt("dimondT") + " Diamonds.\nDo you want to change all Diamonds into Gold?".ToString();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void Transfer()
    {
        addGold = PlayerPrefs.GetInt("dimondT");
        if(addGold == 0)
        {
            txtIntro.text = "You have " + PlayerPrefs.GetInt("dimondT") + " Diamond.\nYou have to play to earn Diamonds".ToString();
        }    
        if (addGold < 1000 && addGold >0)
        {
            StartCoroutine(DeLayChange());
            PlayerPrefs.SetInt("goldT", PlayerPrefs.GetInt("goldT") + 10 * addGold);
            txtIntro.text = "You changed successfully !\nYou added " + 10 * addGold + " Gold".ToString();
            LoadInter();
        }   
        else if (addGold < 2000 && addGold >= 1000)
        {
            StartCoroutine(DeLayChange());
            PlayerPrefs.SetInt("goldT", PlayerPrefs.GetInt("goldT") + 15 * addGold);
            txtIntro.text = "You changed successfully !\nYou added " + 15 * addGold + " Gold".ToString();
            LoadInter();
        }
        else if (addGold >= 2000)
        {
            StartCoroutine(DeLayChange());
            PlayerPrefs.SetInt("goldT", PlayerPrefs.GetInt("goldT") + 20 * addGold);
            txtIntro.text = "You changed successfully !\nYou added " + 20 * addGold + " Gold".ToString();
            LoadInter();
        }
    }    
    public IEnumerator DeLayChange()
    {
        yield return new WaitForSeconds(0.1f);
        PlayerPrefs.SetInt("dimondT", 0);

    }    
    public void LoadInter()
    {
        //GoogleAds.GetComponent<GoogleAds>().RequestInterstitial();
    }    
}
