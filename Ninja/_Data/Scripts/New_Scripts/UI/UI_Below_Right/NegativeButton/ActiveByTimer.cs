using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ActiveByTimer : BaseImage
{
    [SerializeField] protected ButtonActiveParent _ButtonActiveParent;
    [SerializeField] protected float _Time_Delay_Button_Active = 1f;
    public float Time_Delay_Button_Active => _Time_Delay_Button_Active;

    [SerializeField] protected float _Timer = 0f;
    public float Timer => _Timer;

    protected override void LoadComponents()
    {
        base.LoadComponents();

        this.LoadButtonActiveParent();
    }

    protected virtual void LoadButtonActiveParent()
    {
        if (this._ButtonActiveParent != null) return;

        this._ButtonActiveParent = GetComponentInParent<ButtonActiveParent>();
    }

    protected override void Start()
    {
        base.Start();

        this._BaseImage.enabled = false;
    }
    protected virtual void Update()
    {
        if (this.CheckAllPrequisite())
        {
            this.ConductActiveFasleButton();
            return;
        }

        this.SetAllConfigurationBeforeInActiveButton();

        if (!this.GetBoolVariable() && this._Timer == 0) return;

        this.ProcedureCountDownHideButton();
       
    }

    protected virtual void ProcedureCountDownHideButton()
    {
        this.SetBoolVariableFalse();

        this._BaseImage.enabled = true;

        if (!this.CheckTimeDelayByParameter(this._Time_Delay_Button_Active))
        {
            this.ConductActiveFasleButton();

            //CountDown 360
            this._BaseImage.fillAmount = this._Timer / this._Time_Delay_Button_Active;
            return;
        }
        this.ResetAllConfiguration();
    }

    protected virtual bool CheckTimeDelayByParameter(float timeDelay)
    {
        this._Timer += Time.deltaTime;
        return this._Timer >= timeDelay;
    }

    protected virtual void SetAllConfigurationBeforeInActiveButton()
    {
        this._ButtonActiveParent.BaseButton_Exect.ButtonExect.interactable = true;
    }

    protected virtual void ConductActiveFasleButton()
    {
        this._ButtonActiveParent.BaseButton_Exect.ButtonExect.interactable = false;

    }

    protected virtual bool CheckAllPrequisite()
    {
        return false;
    }

    protected virtual void ResetAllConfiguration()
    {
        this._ButtonActiveParent.BaseButton_Exect.ButtonExect.interactable = true;

        this._BaseImage.enabled = false;
        this._Timer = 0f;
        this._BaseImage.fillAmount = 0f;
    }

    protected abstract void SetBoolVariableFalse();

    protected virtual bool GetBoolVariable() => false;
}
