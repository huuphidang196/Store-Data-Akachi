using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttackAlways : EnemyAttackByImpact
{
    protected override void Update()
    {
        base.Update();
        this.ChangeLayerWeaponToAttacKPlayer(true);
    }
}
