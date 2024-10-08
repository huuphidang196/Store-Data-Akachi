using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttackWaiting : EnemyAttackByImpact
{
    //[Header("EnemyAttackWaiting")]

    protected override void Update()
    {
        base.Update();

        if (this.isSlash == this._EmemyImpactTriggerSendDam.gameObject.activeInHierarchy) return;

        Invoke(nameof(this.EnemyAttackPlayer), 0.2f);
    }

    protected virtual void EnemyAttackPlayer()
    {
        this.ChangeLayerWeaponToAttacKPlayer(true);
        this._EmemyImpactTriggerSendDam.gameObject.SetActive(this.isSlash);
    }
}
