using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponCharacterMovement : MovableObjectMovement
{
    public WeaponCharacterCtrl WeaponCharacterCtrl => this._MovableObjCtrl as WeaponCharacterCtrl;

    public virtual void SetDirectionFly(Transform ObjThrow)
    {
        float localX = ObjThrow.localScale.x;
        this._Move_Right = (localX > 0);
        //Debug.Log("ObjThrow: " + ObjThrow.name + ", localX : " + localX + ",_Move_Right: " + _Move_Right);
    }

    protected override void ResetValue()
    {
        base.ResetValue();

        this._Speed_Move_Horizontal = this.WeaponCharacterCtrl.WeaponSO.Speed_Move_Horizontal;
        this._Horizontal = this._Speed_Move_Horizontal;
    }

    protected override void LoadRigidbody2D()
    {
        base.LoadRigidbody2D();

        this._Rigidbody2D.bodyType = RigidbodyType2D.Kinematic;
        this._Rigidbody2D.constraints = RigidbodyConstraints2D.FreezePositionY;
    }

    protected override void Update()
    {
        if (this.WeaponCharacterCtrl.WeaponCharacterImpact.IsImpact_Trigger)
        {
            this._Horizontal = 0f;
            return;
        }
        this._Horizontal = (this._Move_Right) ? 1f * this._Speed_Move_Horizontal : -1f * this._Speed_Move_Horizontal;

        base.Update();
    }

    protected virtual void FixedUpdate()
    {
        this._Rigidbody2D.velocity = new Vector2(this._Horizontal, this._Rigidbody2D.velocity.y);
    }
}
