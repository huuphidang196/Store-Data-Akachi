using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletEmemyShooterDamReceiver : WeaponCharacterDamReceiver
{
    protected override void MoveOverToHolder()
    {
        //Holder
        WeaponCharacterSpawner.Instance.Despawn(this.WeaponCharacterCtrl.transform);
    }

 
}
