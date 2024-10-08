using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjCtrlHurtPlayer : ObjectCtrl
{
    [SerializeField] protected ObjDamSenderInfinity _ObjDamSenderInfinity;
    public ObjDamSenderInfinity ObjDamSenderInfinity => _ObjDamSenderInfinity;
    protected override void LoadComponents()
    {
        base.LoadComponents();

        this.LoadObjDamSenderInfinity();
    }

    protected virtual void LoadObjDamSenderInfinity()
    {
        if (this._ObjDamSenderInfinity != null) return;

        this._ObjDamSenderInfinity = transform.GetComponentInChildren<ObjDamSenderInfinity>();
    }

}
