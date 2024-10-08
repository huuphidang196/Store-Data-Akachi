using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ButtonLevelCtrl : SurMonoBehaviour
{
    [SerializeField] protected int _Level_Rep;
    [SerializeField] protected Image _ImageBG_Selected;
    public Image ImageBG_Selected => _ImageBG_Selected;

    [SerializeField] protected TextMeshProUGUI _txtLevelDisplay;
    [SerializeField] protected Image _Image_Lock;

    #region LoadComponents
    protected override void LoadComponents()
    {
        base.LoadComponents();

        this.LoadImageBG_Selected();
        this.LoadTextLevelDisplay();
        this.LoadImageLock();
    }

    protected virtual void LoadImageBG_Selected()
    {
        if (this._ImageBG_Selected != null) return;

        this._ImageBG_Selected = transform.Find("ImageBG_Selected").GetComponent<Image>();
    }

    protected virtual void LoadTextLevelDisplay()
    {
        if (this._txtLevelDisplay != null) return;

        this._txtLevelDisplay = transform.Find("btn_Level").GetComponentInChildren<TextMeshProUGUI>();

    }

    protected virtual void LoadImageLock()
    {
        if (this._Image_Lock != null) return;

        this._Image_Lock = transform.Find("Image_Lock").GetComponent<Image>();
    }
    #endregion

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
    protected virtual void ProcessEventClickedSelectLevel(int levelButton)
    {
        this._ImageBG_Selected.gameObject.SetActive(false);

        bool isSelect = this._Level_Rep == levelButton;
        this._ImageBG_Selected.gameObject.SetActive(isSelect);

    }
    protected override void Start()
    {
        base.Start();

        this.SetElementOfButtonBegin();
    }

    protected virtual void SetElementOfButtonBegin()
    {
        //Set Level string
        string str_Level = transform.name.Substring(transform.name.LastIndexOf("_") + 1);
        this._Level_Rep = int.Parse(str_Level);

        this._txtLevelDisplay.text = this._Level_Rep + "";

        this._ImageBG_Selected.gameObject.SetActive(false);

        //Call open
        bool allowUnlock = this.CheckAllowByLevelUnlock(this._Level_Rep);
        this._Image_Lock.gameObject.SetActive(!allowUnlock);

    }

    protected virtual bool CheckAllowByLevelUnlock(int LevelCheck)
    {
        return LevelCheck <= GameController.Instance.SystemConfig.Level_Unlock;
    }

}
