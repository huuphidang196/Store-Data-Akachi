using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponCharacterAbstract : SurMonoBehaviour
{
    [SerializeField] protected WeaponCharacterCtrl _WeaponCharacterCtrl;

    protected override void LoadComponents()
    {
        base.LoadComponents();

        this.LoadWeaponCharacterCtrl();
    }

    protected virtual void LoadWeaponCharacterCtrl()
    {
        if (this._WeaponCharacterCtrl != null) return;

        this._WeaponCharacterCtrl = GetComponentInParent<WeaponCharacterCtrl>();
    }
}
