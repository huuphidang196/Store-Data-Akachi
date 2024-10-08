using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerImpact : CharacterImpactTrigger
{
    [Header("PlayerImpact")]

    [SerializeField] protected PlayerAttack _PlayerAttack;
    protected override void LoadComponents()
    {
        base.LoadComponents();

        this.LoadPlayerAttack();
    }

    protected virtual void LoadPlayerAttack()
    {
        if (this._PlayerAttack != null) return;

        this._PlayerAttack = GetComponentInParent<PlayerAttack>();
    }

    protected override string GetNameLayerImpactTrigger()
    {
        return "Enemy";
    }

    protected override void ProcessImpactTrigger()
    {
        this._PlayerAttack.ObjDamSenderInfinity.Send(this._parentObj);
    }
}
