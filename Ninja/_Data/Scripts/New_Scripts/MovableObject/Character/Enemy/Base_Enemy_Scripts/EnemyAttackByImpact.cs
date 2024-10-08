using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttackByImpact : EnemyAttack
{
    [Header("EnemyAttackByImpact")]

    [SerializeField] protected ObjDamSenderInfinity _ObjDamSenderInfinity;
    public ObjDamSenderInfinity ObjDamSenderInfinity => this._ObjDamSenderInfinity;

    [SerializeField] protected EmemyImpactTriggerSendDam _EmemyImpactTriggerSendDam;
    public EmemyImpactTriggerSendDam EmemyImpactTriggerSendDam => this._EmemyImpactTriggerSendDam;


    protected override void LoadComponents()
    {
        base.LoadComponents();

        this.LoadObjDamSenderInfinity();
        this.LoadEmemyImpactTriggerSendDam();
    }

    protected virtual void LoadEmemyImpactTriggerSendDam()
    {
        if (this._EmemyImpactTriggerSendDam != null) return;

        this._EmemyImpactTriggerSendDam = GetComponentInChildren<EmemyImpactTriggerSendDam>();
    }

    protected virtual void LoadObjDamSenderInfinity()
    {
        if (this._ObjDamSenderInfinity != null) return;

        this._ObjDamSenderInfinity = GetComponentInChildren<ObjDamSenderInfinity>();
    }

    protected override void LoadCharacterCtrl()
    {
        base.LoadCharacterCtrl();

        this._CharacterCtrl = GetComponentInParent<EnemyCtrl>();
    }

    protected virtual void ChangeLayerWeaponToAttacKPlayer(bool isAttack)
    {
        string nameLayer = isAttack ? "WeaponEnemy" : "Enemy";
        this._EmemyImpactTriggerSendDam.gameObject.layer = LayerMask.NameToLayer(nameLayer);
    }

    //protected virtual void EnemyAttackPlayer()
    //{
    //    Physics2D.IgnoreLayerCollision(LayerMask.NameToLayer("Player"), LayerMask.NameToLayer("Enemy"), !this.isSlash);
    //    this._EmemyImpactTriggerSendDam.gameObject.SetActive(this.isSlash);
    //}
}
