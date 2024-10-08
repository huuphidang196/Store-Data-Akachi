using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttackActionVFXManager : CharacterVFXManager
{
    public EnemyCtrl EnemyCtrl => this._CharacterCtrl as EnemyCtrl;

    [Header("EnemyAttackActionVFXManager")]
    [SerializeField] protected GameObject _VFX_Attack;
    public GameObject VFX_Attack => this._VFX_Attack;

    protected override void LoadComponents()
    {
        base.LoadComponents();

        this.LoadVFXAttack();
    }
    protected virtual void LoadVFXAttack()
    {
        if (this._VFX_Attack != null) return;

        this._VFX_Attack = transform.Find("VFX_Attack").gameObject;
        this._VFX_Attack.SetActive(false);

    }

    protected override void Update()
    {
        //Pause Game
        this.UpdateVFXAttack();
        base.Update();

    }

    protected virtual void UpdateVFXAttack()
    {
        if (this._VFX_Attack.activeInHierarchy == this.EnemyCtrl.EnemyAttack.isSlashing) return;

        this._VFX_Attack.SetActive(this.EnemyCtrl.EnemyAttack.isSlashing);

    }
}
