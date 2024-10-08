using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletEnemyShooterImpact : WeaponCharacterImpact
{
    protected override string GetNameTargetAttack()
    {
        return "Player";
    }
}
