using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShurikenImpact : WeaponCharacterImpact
{
    protected override string GetNameTargetAttack()
    {
        return "Enemy";
    }
}
