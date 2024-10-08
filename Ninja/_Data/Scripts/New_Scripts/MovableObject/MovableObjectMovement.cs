using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class MovableObjectMovement : MovableObjAbstract
{
    [Header("MovableObjectMovement")]

    [SerializeField] protected Rigidbody2D _Rigidbody2D;
    public Rigidbody2D Rigidbody2D => _Rigidbody2D;

    [SerializeField] protected float _Horizontal = 0f;
    [SerializeField] protected float _Speed_Move_Horizontal = 8f;///Set from scriptable Object

    [SerializeField] protected bool isFacingRight = true;
    [SerializeField] protected bool _Move_Right = false;

    protected override void ResetValue()
    {
        base.ResetValue();

        this.ResetSpeedConfiguration();
    }

    protected virtual void ResetSpeedConfiguration()
    {
        //    this._Speed_MoveHorizontal = this._MovableObjCtrl.MObjScriptableObject.Speed_Horizontal;
    }

    protected override void LoadComponents()
    {
        base.LoadComponents();

        this.LoadRigidbody2D();
    }

    protected virtual void LoadRigidbody2D()
    {
        if (this._Rigidbody2D != null) return;

        this._Rigidbody2D = this._MovableObjCtrl.transform.GetComponent<Rigidbody2D>();
    }

    protected virtual void Update()
    {
        if (this._MovableObjCtrl.ObjDamageReceiver.ObjIsDead) this._Horizontal = 0;
        this.Flip();

    }
    protected virtual void Flip()
    {
        if (this.isFacingRight && this._Horizontal < 0f || !this.isFacingRight && this._Horizontal > 0f) this.isFacingRight = !this.isFacingRight;

        this.ConductFlip();
    }

    protected virtual void ConductFlip()
    {
        Vector3 localScale = this._MovableObjCtrl.transform.localScale;
        localScale.x = (this.isFacingRight) ? Mathf.Abs(localScale.x) : -1f * Mathf.Abs(localScale.x);

        this._MovableObjCtrl.transform.localScale = localScale;
    }

    //protected abstract void UpdateBoolByInputManager();


}
