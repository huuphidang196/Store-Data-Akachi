using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletEnemyShooterCtrl : WeaponCharacterCtrl
{
    public BulletEnemyShooterImpact BulletEnemyShooterImpact => this.WeaponCharacterImpact as BulletEnemyShooterImpact;
    public BulletEmemyShooterDamReceiver BulletEmemyShooterDamReceiver => this.WeaponCharacterDamReceiver as BulletEmemyShooterDamReceiver;

    protected override string GetNameFolderTypeObjectUsing()
    {
        return "Enemy" + "/";
    }
}
