using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterVFXManager : CharacterAbstract
{
    [Header("EnemyVFXManager")]

    [SerializeField] protected GameObject _VFX_Dead;
    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadVFXDead();
    }

    protected virtual void LoadVFXDead()
    {
        if (this._VFX_Dead != null) return;

        this._VFX_Dead = transform.Find("VFX_Dead").gameObject;
        this._VFX_Dead.SetActive(false);
    }

    protected virtual void Update()
    {
        //Pause Game
        this.UpdateVFXDead();
    }

    protected virtual void UpdateVFXDead()
    {
        if (this._VFX_Dead.activeInHierarchy == this._CharacterCtrl.ObjDamageReceiver.ObjIsDead) return;

        this._VFX_Dead.SetActive(this._CharacterCtrl.ObjDamageReceiver.ObjIsDead);

    }
}
