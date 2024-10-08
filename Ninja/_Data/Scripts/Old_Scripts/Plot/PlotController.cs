using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlotController : MonoBehaviour
{
    public GameObject btnNextPlot;
    public GameObject btnBackPlot;
    public GameObject GoogleAds;

    public Image imgPlot;
    public Sprite Plot, Plot1, Plot2, Plot3, Plot4;
    public GameObject txtContentPlot;

    public int i = 0;

    // Start is called before the first frame update
    void Start()
    {
        btnBackPlot.SetActive(false);
        btnNextPlot.SetActive(true);
        imgPlot.GetComponent<Image>().sprite = Plot;
        txtContentPlot.GetComponent<Text>().text = "In 735, Japan suffered from a mysterious epidemic that killed millions of people.\nWar, poverty, people wailing ...";
    }

    // Update is called once per frame
    void Update()
    {
        if(i == 0)
        {
            btnBackPlot.SetActive(false);
            btnNextPlot.SetActive(true);
            imgPlot.GetComponent<Image>().sprite = Plot;
            txtContentPlot.GetComponent<RectTransform>().anchoredPosition = new Vector3(-157, 82, 0);
            txtContentPlot.GetComponent<Text>().text = "In 735, Japan suffered from a mysterious epidemic that killed millions of people.\nWar, poverty, people wailing ...";
        }    
        else if(i == 1)
        {
            btnBackPlot.SetActive(true);
            btnNextPlot.SetActive(true);
            imgPlot.GetComponent<Image>().sprite = Plot1;
            txtContentPlot.GetComponent<RectTransform>().anchoredPosition = new Vector3(-157, 82, 0);
            txtContentPlot.GetComponent<Text>().text = "In the folklore at that time there was a rumor that in a cold and gloomy northern land grew a plant that could cure diseases.";
        }
        else if (i == 2)
        {
            btnBackPlot.SetActive(true);
            btnNextPlot.SetActive(true);
            imgPlot.GetComponent<Image>().sprite = Plot2;
            txtContentPlot.GetComponent<RectTransform>().anchoredPosition = new Vector3(-157, 172, 0);
            txtContentPlot.GetComponent<Text>().text = "In the North of Kyuushuu there was a young and ambitious ninja named Akachi.";
        }
        else if (i == 3)
        {
            btnBackPlot.SetActive(true);
            btnNextPlot.SetActive(true);
            imgPlot.GetComponent<Image>().sprite = Plot3;
            txtContentPlot.GetComponent<RectTransform>().anchoredPosition = new Vector3(86, -56, 0);
            txtContentPlot.GetComponent<Text>().text = "Akachi thinks about his hometown and feels so heartbroken";
        }
        else if (i == 4)
        {
            btnBackPlot.SetActive(true);
            btnNextPlot.SetActive(false);
            imgPlot.GetComponent<Image>().sprite = Plot4;
            txtContentPlot.GetComponent<RectTransform>().anchoredPosition = new Vector3(238, 148, 0);
            txtContentPlot.GetComponent<Text>().text = "Knowing that rumor, Akachi set off to find a cure to save the country from the epidemic.\nOn the way to the North, Akachi will encounter many challenges, will he be able to overcome them?";

        }
    }
    public void NextPlot()
    {
        i++;
        if(i == 4 )
        {
            //GoogleAds.GetComponent<GoogleAds>().RequestInterstitial();
        }    
    }    
    public void BackPlot()
    {
        i--;
    }   
    public void BackSetting()
    {
        SceneManager.LoadScene(22);
    }    
}
