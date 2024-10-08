using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShurikenCtrl : WeaponCharacterCtrl
{
    public ShurikenImpact ShurikenImpact => this.WeaponCharacterImpact as ShurikenImpact;
    public ShurikenDamReceiver ShurikenDamReceiver => this.WeaponCharacterDamReceiver as ShurikenDamReceiver;

    protected override string GetNameFolderTypeObjectUsing()
    {
        return "Player" + "/";
    }
}
