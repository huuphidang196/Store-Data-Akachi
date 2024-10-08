using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponCharacterDespawnByDistance : ObjDespawnByDistance
{
    public WeaponCharacterCtrl WeaponCharacterCtrl => this._ObjectCtrl as WeaponCharacterCtrl;

    protected override float GetDistanceLimit() => 40f;

    protected override void Start()
    {
        base.Start();

        Transform camera_Main = CameraFollowTarget.Instance.transform;
        this.SetTargetToReference(camera_Main);
    }

    public override void DespawnObject()
    {
        //Call to overall despawn
        this.WeaponCharacterCtrl.WeaponCharacterDamReceiver.OnDeadByInfiniteDamage();
    }
}
