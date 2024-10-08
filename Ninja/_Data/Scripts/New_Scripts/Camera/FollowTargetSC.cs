using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowTargetSC : SurMonoBehaviour
{
    [Header("Follow Target")]

    [SerializeField] protected Transform _Target_Follow;
    public Transform TargetFollow => _Target_Follow;

    [SerializeField] protected float _Speed = 2f;

    protected override void ResetValue()
    {
        base.ResetValue();

        this._Speed = this.GetSpeedFollowTarget();
    }

    protected virtual float GetSpeedFollowTarget() => 2f;
  

    protected virtual void Moving()
    {
        if (this.transform == null) return;

        transform.position = Vector3.Lerp(transform.position, this.GetPositionTarget(), this._Speed * Time.fixedDeltaTime);
        // transform.position = Vector3.SmoothDamp(transform.position, this.Target.position, ref _velocity, 0.25f);
    }

    protected virtual Vector3 GetPositionTarget()
    {
        return this._Target_Follow.position;
    }

    public virtual void SetTarget(Transform Target)
    {
        this._Target_Follow = Target;
    }
}
