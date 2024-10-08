using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonActiveParent : SurMonoBehaviour
{
    [SerializeField] protected ActiveByTimer _ActiveByTimer;

    [SerializeField] protected BaseButton _BaseButton_Exect;
    public BaseButton BaseButton_Exect => _BaseButton_Exect;

    protected override void LoadComponents()
    {
        base.LoadComponents();

        this.LoadActiveByTimer();
        this.LoadBaseButton();
    }

    protected virtual void LoadActiveByTimer()
    {
        if (this._ActiveByTimer != null) return;

        this._ActiveByTimer = GetComponentInChildren<ActiveByTimer>();
    }

    protected virtual void LoadBaseButton()
    {
        if (this._BaseButton_Exect != null) return;

        this._BaseButton_Exect = GetComponentInChildren<BaseButton>();
    }


}
