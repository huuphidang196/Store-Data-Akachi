using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonHidenSkillActiveByTime : ActiveByTimer
{
    [SerializeField] protected float _Time_Delay_Button_Hiden = 5f;
    protected override void ResetValue()
    {
        base.ResetValue();

        this._Time_Delay_Button_Hiden = 5f;
        this._Time_Delay_Button_Active = 12f;
    }

    protected override void Update()
    {
        if (!this.GetBoolVariable() && this._Timer != 0 && this.CheckConditionPlayer())
        {
            this.SetAllConfigurationBeforeInActiveButton();
            this.ProcedureCountDownHideButton();

            return;
        }

        if (this.GetBoolVariable() && !this.CheckTimeDelayByParameter(this._Time_Delay_Button_Hiden)) return;

        base.Update();
    }

    protected virtual bool CheckConditionPlayer()
    {
        return (PlayerCtrl.Instance.PlayerMovement.IsHiding);
    }

    protected override void SetBoolVariableFalse()
    {
        if (!PlayerCtrl.Instance.PlayerMovement.IsHiding) return;
        InputManager.Instance.PointerHidenModeSkillPresAndUp();//run more correctly than setallconfig
    }

    protected override bool GetBoolVariable()
    {
        return InputManager.Instance.Press_Hiden_Mode;
        //return !PlayerCtrl.Instance.PlayerMovement.IsHiding && InputManager.Instance.Press_Hiden_Mode;

    }
    protected override bool CheckAllPrequisite()
    {
        return PlayerCtrl.Instance.PlayerMovement.IsDashing;
    }

    protected override void SetAllConfigurationBeforeInActiveButton()
    {
        if (this.GetBoolVariable() && this.CheckTimeDelayByParameter(this._Time_Delay_Button_Hiden)) this._Timer = 0f;

        base.SetAllConfigurationBeforeInActiveButton();
    }

}
