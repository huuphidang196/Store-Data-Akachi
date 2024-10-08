using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCtrl : CharacterCtrl
{
    public EnemySO EnemySO => this._MObjScriptableObject as EnemySO;
    public EnemyAnimations EnemyAnimations => this._CharacterAnimation as EnemyAnimations;
    public EnemyCheckContactEnvirment EnemyCheckContactEnviroment => this._CharacterCheckContactEnviroment as EnemyCheckContactEnvirment;

    public EnemyMovement EnemyMovement => this._MovableObj_Movement as EnemyMovement;

    public EnemyDamReceiver EnemyDamReceiver => this._ObjDamageReceiver as EnemyDamReceiver;

    public EnemyAttackActionVFXManager EnemyAttackActionVFXManager => this._CharacterVFXManager as EnemyAttackActionVFXManager;

    [Header("EnemyCtrl")]
    [SerializeField] protected EnemyImpact _EnemyImpact;
    public EnemyImpact EnemyImpact => this._EnemyImpact;

    [SerializeField] protected EnemyAttack _EnemyAttack;
    public EnemyAttack EnemyAttack => this._EnemyAttack;

    protected override void LoadComponents()
    {
        base.LoadComponents();

        this.LoadEnemyImpact();
        this.LoadEnemyAttack();
    }

    protected virtual void LoadEnemyImpact()
    {
        if (this._EnemyImpact != null) return;

        this._EnemyImpact = GetComponentInChildren<EnemyImpact>();
    }
    protected virtual void LoadEnemyAttack()
    {
        if (this._EnemyAttack != null) return;

        this._EnemyAttack = GetComponentInChildren<EnemyAttack>();
    }

}
