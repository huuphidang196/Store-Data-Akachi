using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAbstract : SurMonoBehaviour
{
    [SerializeField] protected PlayerCtrl _PlayerCtrl;

    protected override void LoadComponents()
    {
        base.LoadComponents();

        this.LoadPlayerCtrl();
    }

    protected virtual void LoadPlayerCtrl()
    {
        if (this._PlayerCtrl != null) return;

        this._PlayerCtrl = GetComponentInParent<PlayerCtrl>();
    }
}
