using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjDamageSender : ObjectAbstract
{
    [Header("Obj Damage Sender")]
    //Load damage từ SO
    [SerializeField] protected float _damage = 1f;
    protected override void ResetValue()
    {
        base.ResetValue();

        this._damage = this.GetDamageObjectToSend();
    }

    protected virtual float GetDamageObjectToSend()
    {
        return 1;
    }

    public virtual void Send(Transform obj)
    {
        ObjDamageReceiver damagerReceiver = obj.GetComponentInChildren<ObjDamageReceiver>();

        if (damagerReceiver == null) return;
        this.Send(damagerReceiver);
    }

    public virtual void Send(ObjDamageReceiver damagerReceiver)
    {
        damagerReceiver.DeductHP(this._damage);
    }
}
