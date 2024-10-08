using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System;

public abstract class BaseButton : SurMonoBehaviour
{
    [Header("Button Base")]
    [SerializeField] protected Button _btnExect;
    public Button ButtonExect => _btnExect;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadButton();
    }

   
    protected virtual void LoadButton()
    {
        if (this._btnExect != null) return;
        this._btnExect = GetComponent<Button>();

    }
    
    protected virtual void AddOnClickEvent()
    {
        this._btnExect.onClick.AddListener(this.OnClick);
    }

    protected override void Start()
    {
        base.Start();
        this.AddOnClickEvent();
    }
    protected virtual void OnClick()
    {

    }    
      
}
