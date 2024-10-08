using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Plot : MonoBehaviour
{
    public GameObject imgIntroduce;

    public Sprite BGndefault,BGST2, BGST3, BGST4, BGST5;

    public GameObject txtAbout;
    public GameObject txtNinjaAkachi;
    public GameObject btnPlay;
    public GameObject txtAkachiDefault;

    public AudioClip AkachiBGStart;
    public AudioClip BGStartdefault;
    private AudioSource audi;
  
    // Start is called before the first frame update
    private void Awake()
    {
        audi = GetComponent<AudioSource>();
        PlayerPrefs.GetInt("SetPlot1", 0);
        
    }

    void Start()
    {
        if (PlayerPrefs.GetInt("SetPlot1") == 0)
        {
            audi.clip = AkachiBGStart;
            audi.Play();
            btnPlay.SetActive(false);
            txtAkachiDefault.SetActive(false);
            // Dành cho txtAbout
            StartCoroutine(txtAboutStart1());
            // Dành cho imgIntroduce
            StartCoroutine(imgIntroduceStart2());

            // Chuyển Sence LV1
            StartCoroutine(ProcessSetLV1());
        }
        else if(PlayerPrefs.GetInt("SetPlot1") == 1)
        {
            audi.clip = BGStartdefault;
            audi.Play();
            imgIntroduce.GetComponent<Image>().sprite = BGndefault;
            txtAbout.SetActive(false);
            txtNinjaAkachi.SetActive(false);
            btnPlay.SetActive(true);
            txtAkachiDefault.SetActive(true);
        }
        Debug.Log("Set" + PlayerPrefs.GetInt("SetPlot1"));
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void PlayGame()
    {
        //Application.LoadLevel("LevelMenu");
        SceneManager.LoadScene(1);
    }
    // Dành cho txtAbout
    public IEnumerator txtAboutStart1()
    {
        txtAbout.SetActive(true);
        txtAbout.GetComponent<Text>().text = "In 735, Japan suffered from a mysterious epidemic that killed millions of people. ".ToString();
        yield return new WaitForSeconds(5f);
        txtAbout.GetComponent<Text>().text = txtAbout.GetComponent<Text>().text + "\nWar, poverty, people wailing ...".ToString();

        yield return new WaitForSeconds(4f);
        txtAbout.GetComponent<Text>().text = "In the folklore at that time there was a rumor that in a cold and gloomy northern land grew a plant that could cure diseases.".ToString();

        yield return new WaitForSeconds(8f);
        txtAbout.GetComponent<RectTransform>().anchoredPosition = new Vector3(-407, 193, 0);
        txtAbout.GetComponent<Text>().text = "In the North of Kyuushuu there was a young and ambitious ninja named Akachi.".ToString();
        txtAbout.GetComponent<Text>().color = Color.black;
        txtNinjaAkachi.SetActive(true);

        yield return new WaitForSeconds(8f);
        txtAbout.GetComponent<RectTransform>().anchoredPosition = new Vector3(32, -160, 0);
        txtAbout.GetComponent<Text>().color = Color.white;
        txtAbout.GetComponent<Text>().text = "Akachi thinks about his hometown and feels so heartbroken".ToString(); // thay thế String này bằng nhìn về quê hương, String này cho BGST5
        txtNinjaAkachi.SetActive(false);

        yield return new WaitForSeconds(8f);
        txtAbout.GetComponent<Text>().text = "Knowing that rumor, Akachi set off to find a cure to save the country from the epidemic.\nOn the way to the North, Akachi will encounter many challenges, will he be able to overcome them?".ToString();
        txtAbout.GetComponent<RectTransform>().anchoredPosition = new Vector3(466, 136, 0);
       
        yield return new WaitForSeconds(6.25f);
        txtAbout.SetActive(false);
        txtNinjaAkachi.SetActive(false);

        Debug.Log("Thoi gian" + Time.time);
    }
    // Dành cho imgIntroduce
    public IEnumerator imgIntroduceStart2()
    {
        // BGST1
        yield return new WaitForSeconds(1.25f); // Dành riêng 
        imgIntroduce.GetComponent<Image>().color = new Color32(255, 255, 255, 250);
        for (int i = 0; i < 27; i++)
        {
             yield return new WaitForSeconds(0.25f);
            imgIntroduce.GetComponent<Image>().color = new Color32(255, 255, 255, (byte)(250 - 5 * (i + 1)));
        }
       
        // BGST2
        yield return new WaitForSeconds(1f);
        imgIntroduce.GetComponent<Image>().sprite = BGST2;
        imgIntroduce.GetComponent<Image>().color = new Color32(255, 255, 255, 255);
        for (int i = 0; i < 27; i++)
        {
            yield return new WaitForSeconds(0.25f);
            imgIntroduce.GetComponent<Image>().color = new Color32(255, 255, 255, (byte)(250 - 5 * (i + 1)));
        }

        // BGST3
        yield return new WaitForSeconds(1f);
        imgIntroduce.GetComponent<Image>().sprite = BGST3;
        imgIntroduce.GetComponent<Image>().color = new Color32(255, 255, 255, 255);

        for (int i = 0; i < 27; i++)
        {
            yield return new WaitForSeconds(0.25f);
             imgIntroduce.GetComponent<Image>().color = new Color32(255, 255, 255, (byte)(250 - 5 * (i + 1)));
        }

        //BGST4
        yield return new WaitForSeconds(1f);
        imgIntroduce.GetComponent<Image>().sprite = BGST4;
        imgIntroduce.GetComponent<Image>().color = new Color32(255, 255, 255, 255);

        for (int i = 0; i < 27; i++)
        {
            yield return new WaitForSeconds(0.25f);
            imgIntroduce.GetComponent<Image>().color = new Color32(255, 255, 255, (byte)(250 - 5 * (i + 1)));
        }
        //BGST5
        yield return new WaitForSeconds(1f);
        imgIntroduce.GetComponent<Image>().sprite = BGST5;
        imgIntroduce.GetComponent<Image>().color = new Color32(255, 255, 255, 255);
        
        yield return new WaitForSeconds(6.25f);
       
        imgIntroduce.SetActive(false);
       
    }    

    public IEnumerator ProcessSetLV1()
    {
        yield return new WaitForSeconds(39);
        SceneManager.LoadScene(2);
        PlayerPrefs.SetInt("i", 2);
        PlayerPrefs.SetInt("SetPlot1", 1);
    }    
}

// Đối với Text 
//rectTransform.anchoredPosition = new Vector3()