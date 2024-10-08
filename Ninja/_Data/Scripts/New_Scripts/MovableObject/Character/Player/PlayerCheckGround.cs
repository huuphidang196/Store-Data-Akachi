using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCheckGround : SurMonoBehaviour
{
    [SerializeField] protected float _Radius_Check = 0.1f;

    [SerializeField] protected Transform _GroundCheck;
    [SerializeField] protected LayerMask _GroundLayer;
    [SerializeField] protected bool isGround;
    public bool IsGround => isGround;
    protected override void ResetValue()
    {
        base.ResetValue();

        this._Radius_Check = 0.1f;
        this._GroundCheck = this.transform;
        this._GroundLayer = 1 << LayerMask.NameToLayer("Ground");
    }

    protected virtual void Update()
    {
        this.isGround = this.IsGrounded();
    }    
    protected virtual bool IsGrounded()
    {
        
        return Physics2D.OverlapCircle(this._GroundCheck.position, this._Radius_Check, this._GroundLayer);
    }
    protected virtual void OnDrawGizmos()
    {
        // Thiết lập màu cho Gizmos
        Gizmos.color = Color.red;

        // Vẽ hình tròn tại vị trí (point) với bán kính (radius)
        Gizmos.DrawWireSphere(this._GroundCheck.position, this._Radius_Check);
    }
}
