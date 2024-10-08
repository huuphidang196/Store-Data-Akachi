using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShurikenAbstract : SurMonoBehaviour
{
    [SerializeField] protected ShurikenCtrl _ShurikenCtrl;

    protected override void LoadComponents()
    {
        base.LoadComponents();

        this.LoadShurikenCtrl();
    }

    protected virtual void LoadShurikenCtrl()
    {
        if (this._ShurikenCtrl != null) return;

        this._ShurikenCtrl = GetComponentInParent<ShurikenCtrl>();
    }
}
