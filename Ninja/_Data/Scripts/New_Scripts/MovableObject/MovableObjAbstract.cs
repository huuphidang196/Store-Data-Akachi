using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovableObjAbstract : SurMonoBehaviour
{
    [SerializeField] protected MovableObjCtrl _MovableObjCtrl;
    public MovableObjCtrl MovableObjCtrl => _MovableObjCtrl;

    protected override void LoadComponents()
    {
        base.LoadComponents();

        this.LoadMovableObjCtrl();
    }

    protected virtual void LoadMovableObjCtrl()
    {
        if (this._MovableObjCtrl != null) return;

        this._MovableObjCtrl = transform.parent.GetComponent<MovableObjCtrl>();

    }
}
