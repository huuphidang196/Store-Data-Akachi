using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EmemyImpactTriggerSendDam : CharacterImpactTrigger
{
    [Header("EmemyImpactTriggerSendDam")]

    [SerializeField] protected EnemyAttackByImpact _EnemyAttack;
    protected override void LoadComponents()
    {
        this.LoadPlayerAttack();
        base.LoadComponents();
    }

    protected virtual void LoadPlayerAttack()
    {
        if (this._EnemyAttack != null) return;

        this._EnemyAttack = GetComponentInParent<EnemyAttackByImpact>();
    }

    protected override string GetNameLayerImpactTrigger()
    {
        return "Player";
    }

    protected override void ProcessImpactTrigger()
    {
        this._EnemyAttack.ObjDamSenderInfinity.Send(this._parentObj);
        //   Debug.Log("Name : " + this._parentObj);
    }
}
