using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelMenuController : SystemController
{
    private static LevelMenuController m_instance;
    public static LevelMenuController Instance => m_instance;

    
    public static Action<int> ClickedButtonLevel;

    public Text txtGoldS1, txtDimond;

    public GameObject NextLvBoss;
    public GameObject BackLevel;
    public GameObject btnPlay;
    // Trượt đến level unlock
    public GameObject levelBtn;

    public Sprite btnSelect;
    public Sprite btnDen;
    public Sprite btnLock;
    public Sprite btnBossDen;
    public Sprite spLvBoss;
    public Sprite spLvPlay;

    public Image imgStart;

    public int i;
    protected override void Awake()
    {
        base.Awake();
        if (m_instance != null) Debug.LogError("Allow only LevelMenuController has been exist");

        m_instance = this;

        this.SetDataAfterLoadFromDisk();
    }

    protected virtual void SetDataAfterLoadFromDisk()
    {
        PlayerPrefs.GetInt("UnLock", 2);
        // PlayerPrefs.SetInt("UnLock", 2);
        PlayerPrefs.GetInt("i", 2);
        // PlayerPrefs.SetInt("i", 2);
        PlayerPrefs.GetInt("SetStart", 0);
        // PlayerPrefs.SetInt("SetStart", 0);
    }

    protected override void Start()
    {
        base.Start();
        this._SystemConfig.Level_Unlock = PlayerPrefs.GetInt("UnLock");
        i = PlayerPrefs.GetInt("i");

        if (PlayerPrefs.GetInt("SetStart") == 0)
        {
            PlayerPrefs.SetInt("i", 2);
            PlayerPrefs.SetInt("UnLock", 2);
        }

        txtGoldS1.text = " " + PlayerPrefs.GetInt("goldT").ToString();
        txtDimond.text = " " + PlayerPrefs.GetInt("dimondT").ToString();
        btnPlay.SetActive(false);
        NextLvBoss.SetActive(true);
        BackLevel.SetActive(false);
        Application.targetFrameRate = 60;

    }

    public void BackToMenu()
    {
        SceneManager.LoadScene(0);
        PlayerPrefs.SetInt("i", 0);
    }


    public virtual void ClickSelectScenePlayByLevel(Transform buttonLevel)
    {
        //Sound
        string str_Level = buttonLevel.name.Substring(buttonLevel.name.LastIndexOf("_") + 1);
        int LevelButton = int.Parse(str_Level);

        ClickedButtonLevel?.Invoke(LevelButton);Debug.Log("LevelButton " + LevelButton);

        if (this._SystemConfig.Level_Unlock < LevelButton) return;

        this._SystemConfig.Current_Level = LevelButton;

    }

    public virtual string GetNameSceneCurrent() => "Level_" + this._SystemConfig.Current_Level.ToString("D2");

    public void NextLevelBoss()
    {
        imgStart.GetComponent<Image>().sprite = spLvBoss;

        //LvBoss.SetActive(true);
        //Lv1.SetActive(false);
        //Lv2.SetActive(false);
        //Lv3.SetActive(false);
        //Lv4.SetActive(false);
        //Lv5.SetActive(false);
        //Lv6.SetActive(false);
        //Lv7.SetActive(false);
        //Lv8.SetActive(false);
        //Lv9.SetActive(false);
        //Lv10.SetActive(false);
        //Lv11.SetActive(false);
        //Lv12.SetActive(false);
        //Lv13.SetActive(false);
        //Lv14.SetActive(false);
        //Lv15.SetActive(false);

        BackLevel.SetActive(true);
        NextLvBoss.SetActive(false);
    }

    public void BackLevelPlay()
    {
        imgStart.GetComponent<Image>().sprite = spLvPlay;

        BackLevel.SetActive(false);
        NextLvBoss.SetActive(true);

        //Lv1.SetActive(true);
        //Lv2.SetActive(true);
        //Lv3.SetActive(true);
        //Lv4.SetActive(true);
        //Lv5.SetActive(true);
        //Lv6.SetActive(true);
        //Lv7.SetActive(true);
        //Lv8.SetActive(true);
        //Lv9.SetActive(true);
        //Lv10.SetActive(true);
        //Lv11.SetActive(true);
        //Lv12.SetActive(true);
        //Lv13.SetActive(true);
        //Lv14.SetActive(true);
        //Lv15.SetActive(true);

        //LvBoss.SetActive(false);
    }
    public void StartGamePlay()
    {
       
        SceneManager.LoadScene(19);
    }
}
