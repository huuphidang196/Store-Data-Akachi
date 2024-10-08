using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SettingMenuLv : MonoBehaviour
{
    public Button btnMusic;
    public Button btnPlot;
    public Button btnBack;
    public int i,k;
    // Start is called before the first frame update
    private void Awake()
    { 
        PlayerPrefs.GetInt("Touch", 0);
        i = PlayerPrefs.GetInt("Touch");
    }
    void Start()
    {
        if (PlayerPrefs.GetInt("SoundLv") == 1)
        {
            btnMusic.GetComponentInChildren<Text>().text = "Music : ON".ToString();
        }
        else if (PlayerPrefs.GetInt("SoundLv") == 0)
        {
            btnMusic.GetComponentInChildren<Text>().text = "Music : OFF".ToString();
        }
       
    }

    // Update is called once per frame
    void Update()
    {
        if(i == 2)
        {
            StartCoroutine(Seti());
        }
        
        k = PlayerPrefs.GetInt("SoundLv");
        
    }
    public void OnOffMuiscLv()
    {
        i++;
        PlayerPrefs.SetInt("Touch", i);
        if (i == 1)
        {
            PlayerPrefs.SetInt("SoundLv", 0);
            btnMusic.GetComponentInChildren<Text>().text = "Music : OFF".ToString();
        }    
        else if( i == 2)
        {
            PlayerPrefs.SetInt("SoundLv", 1);
            btnMusic.GetComponentInChildren<Text>().text = "Music : ON".ToString();
        }    

    }   
    public IEnumerator Seti()
    {
        yield return new WaitForSeconds(0.01f);
        i = 0;
    }    
    public void btnPlotAkachi()
    {
        SceneManager.LoadScene(23);
        PlayerPrefs.SetInt("i", 23);
    }
    public void LevelMenuAkachi()
    {
        SceneManager.LoadScene(1);
    }
}
