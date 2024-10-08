using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowTarget : SurMonoBehaviour
{
    [Header("Follow Target")]
    [SerializeField] protected Transform _Target;
    public Transform TargetFollow => _Target;

    [SerializeField] protected float _speed = 2f;


    protected virtual void Moving()
    {
        if (this.transform == null) return;

        transform.position = Vector3.Lerp(transform.position, this.GetPositionTarget() , this._speed * Time.fixedDeltaTime);

        // transform.position = Vector3.SmoothDamp(transform.position, this.Target.position, ref _velocity, 0.25f);

    }

    protected virtual Vector3 GetPositionTarget()
    {
        return this._Target.position;
    }

    public virtual void SetTarget(Transform Target)
    {
        this._Target = Target;
    }
}
