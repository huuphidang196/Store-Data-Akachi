using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayerTarget : FollowTargetSC
{
    [Header("FollowPlayerTarget")]
    public Vector3 _Offset_Distance; // Khoảng cách giữa camera và player

    protected override float GetSpeedFollowTarget() => 2f;

    protected override void ResetValue()
    {
        base.ResetValue();

        this._Offset_Distance = new Vector3(1.5f, 0, 0);
    }

    protected override void Start()
    {
        base.Start();

        Transform player = PlayerCtrl.Instance.transform;
        this.SetTarget(player);
    }

    protected override Vector3 GetPositionTarget()
    {
        // Vị trí mong muốn của camera
        Vector3 desiredPosition = this._Target_Follow.position + this._Offset_Distance;

        return new Vector3(desiredPosition.x, 0, this.transform.position.z);
    }
    protected virtual void FixedUpdate()
    {
       // this.Moving();
    }    

    protected virtual void LateUpdate()
    {
        if (this.transform == null) return;

        transform.position = Vector3.Lerp(transform.position, this.GetPositionTarget(), this._Speed);
    }    
}
