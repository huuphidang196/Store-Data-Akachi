using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : EnemyAbstract
{
    [Header("EnemyAttack")]

    [SerializeField] protected bool isSlash = false;
    public bool isSlashing => this.isSlash;

    [SerializeField] protected float _Distance_Attack_Player = 0.5f;

    protected override void ResetValue()
    {
        base.ResetValue();

        this._Distance_Attack_Player = this.EnemyCtrl.EnemySO.Distance_Attack_Player;
        this.isSlash = false;
    }

    protected override void LoadCharacterCtrl()
    {
        base.LoadCharacterCtrl();

        this._CharacterCtrl = GetComponentInParent<EnemyCtrl>();
    }

    protected virtual void Update()
    {
        if (this.EnemyCtrl.EnemyDamReceiver.ObjIsDead) return;

        this.UpdateInputConfigurations();
    }

    protected virtual void UpdateInputConfigurations()
    {

        this.UpdateBoolSlash();
    }

    protected virtual void UpdateBoolSlash()
    {
        //Check distance enemy with player < distance attack => attack
        if (!this.EnemyCtrl.EnemyCheckContactEnviroment.EnemyCheckForward.CheckIsFacingPlayer())
        {
            this.isSlash = false;
            return;
        }

        this.isSlash = this.EnemyCtrl.EnemyCheckContactEnviroment.EnemyCheckForward.GetDistanceFacingPlayer() < this._Distance_Attack_Player;
    }
}
