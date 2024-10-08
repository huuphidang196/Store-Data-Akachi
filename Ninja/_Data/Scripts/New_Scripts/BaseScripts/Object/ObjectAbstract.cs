using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectAbstract : SurMonoBehaviour
{
    [SerializeField] protected ObjectCtrl _ObjectCtrl;
    public ObjectCtrl ObjectCtrl => _ObjectCtrl;

    protected override void LoadComponents()
    {
        base.LoadComponents();

        this.LoadObjectCtrl();
    }

    protected virtual void LoadObjectCtrl()
    {
        if (this._ObjectCtrl != null) return;
        this._ObjectCtrl = transform.parent.GetComponent<ObjectCtrl>();

        if (this._ObjectCtrl != null) return;
        this._ObjectCtrl = GetComponentInParent<ObjectCtrl>();
        //parent use recursives
    }
}
