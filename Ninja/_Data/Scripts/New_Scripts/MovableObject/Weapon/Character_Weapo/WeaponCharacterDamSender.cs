using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponCharacterDamSender : ObjDamageSender
{
    public WeaponCharacterCtrl WeaponCharacterCtrl => this._ObjectCtrl as WeaponCharacterCtrl;

    protected override float GetDamageObjectToSend()
    {
        return this.WeaponCharacterCtrl.WeaponSO.Damage_Send;
    }
}
