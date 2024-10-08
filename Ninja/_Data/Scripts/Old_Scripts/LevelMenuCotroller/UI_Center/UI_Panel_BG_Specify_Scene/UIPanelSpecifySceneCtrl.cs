using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIPanelSpecifySceneCtrl : SurMonoBehaviour
{
    [SerializeField] ButtonPlay _btnPlay;

    protected override void LoadComponents()
    {
        base.LoadComponents();

        this.LoadButtonPlay();
    }

    protected virtual void LoadButtonPlay()
    {
        if (this._btnPlay != null) return;

        this._btnPlay = transform.Find("btnPlay").GetComponent<ButtonPlay>();
    }

    protected override void OnEnable()
    {
        base.OnEnable();

        LevelMenuController.ClickedButtonLevel += this.ProcessEventClickedSelectLevel;
    }

    protected override void OnDisable()
    {
        base.OnDisable();
        LevelMenuController.ClickedButtonLevel -= this.ProcessEventClickedSelectLevel;
    }
    protected virtual void ProcessEventClickedSelectLevel(int LevelButton)
    {
        //After Call Invoke 
        this._btnPlay.gameObject.SetActive(this.CheckAllowActive(LevelButton));

        Debug.Log("LevelButton :" + LevelButton + ", bool " + this.CheckAllowActive(LevelButton));
    }

    protected virtual bool CheckAllowActive(int LevelCheck)
    {
        return LevelCheck <= GameController.Instance.SystemConfig.Level_Unlock;
    }

    protected override void Start()
    {
        base.Start();

        //false button Play
        this.ProcessEventClickedSelectLevel(SystemController.CountScene + 1);
    }
}
