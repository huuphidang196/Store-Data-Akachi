using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerObjDeadByDistance : ObjDespawnByDistance
{
    public PlayerCtrl PlayerCtrl => this._ObjectCtrl as PlayerCtrl;

    protected override float GetDistanceLimit() => 30f;

    protected override void Start()
    {
        base.Start();

        Transform camera_Main = CameraFollowTarget.Instance.transform;
        this.SetTargetToReference(camera_Main);
    }

    public override void DespawnObject()
    {
        //Call to overall despawn
        this.PlayerCtrl.PlayerDamReceiver.DeductHP(99999f);
    }
}
