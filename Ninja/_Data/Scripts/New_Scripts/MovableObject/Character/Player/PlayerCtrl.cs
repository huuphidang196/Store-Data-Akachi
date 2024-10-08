using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCtrl : CharacterCtrl
{
    private static PlayerCtrl _instance;
    public static PlayerCtrl Instance => _instance;

    public PlayerDamReceiver PlayerDamReceiver => this._ObjDamageReceiver as PlayerDamReceiver;
    public PlayerCheckContactEnviroment PlayerCheckContactEnviroment => this._CharacterCheckContactEnviroment as PlayerCheckContactEnviroment;

    public PlayerMovement PlayerMovement => this._MovableObj_Movement as PlayerMovement;

    public PlayerAnimation PlayerAnimation => this._CharacterAnimation as PlayerAnimation;

    public PlayerSO PlayerSO => this._MObjScriptableObject as PlayerSO;

    [Header("Player Ctrl")]
    [SerializeField] protected PlayerObjDead _PlayerObjDead;
    public PlayerObjDead PlayerObjDead => _PlayerObjDead;

    [SerializeField] protected PlayerAttack _PlayerAttack;
    public PlayerAttack PlayerAttack => _PlayerAttack;

    protected override void Awake()
    {
        base.Awake();
        if (_instance != null) Debug.LogError("Only One PlayerCtrl is allowed to exist");

        _instance = this;
    }

    protected override void LoadComponents()
    {
        base.LoadComponents();

        this.LoadPlayerObjDead();
        this.LoadPlayerAttack();
    }

    protected virtual void LoadPlayerObjDead()
    {
        if (this._PlayerObjDead != null) return;

        this._PlayerObjDead = GetComponentInChildren<PlayerObjDead>();
    }

    protected virtual void LoadPlayerAttack()
    {
        if (this._PlayerAttack != null) return;

        this._PlayerAttack = GetComponentInChildren<PlayerAttack>();
    }

}
