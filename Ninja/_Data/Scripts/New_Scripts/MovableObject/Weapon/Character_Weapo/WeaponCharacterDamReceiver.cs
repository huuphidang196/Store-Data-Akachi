using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class WeaponCharacterDamReceiver : ObjDamageReceiver
{
    public WeaponCharacterCtrl WeaponCharacterCtrl => this._ObjectCtrl as WeaponCharacterCtrl;

    [Header("ShurikenDamReceiver")]

    [SerializeField] protected float _Time_Delay_InActive = 0.5f;

    protected override void ResetValue()
    {
        base.ResetValue();

        this._Time_Delay_InActive = this.WeaponCharacterCtrl.WeaponSO.Time_Delay_Disable;
        this.BoxCollider2D.enabled = false;
    }

    protected override void OnDead()
    {
        StartCoroutine(this.ProcessShurikenAfterImpacted());
    }

    protected IEnumerator ProcessShurikenAfterImpacted()
    {
        yield return new WaitForSeconds(this._Time_Delay_InActive);

        this.WeaponCharacterCtrl.gameObject.SetActive(false);
        this.MoveOverToHolder();

    }

    protected abstract void MoveOverToHolder();

    public virtual void OnDeadByInfiniteDamage()
    {
        this.DeductHP(9999f);
    }
}
