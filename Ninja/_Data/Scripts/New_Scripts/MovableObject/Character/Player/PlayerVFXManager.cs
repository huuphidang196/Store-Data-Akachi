using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerVFXManager : CharacterVFXManager
{
    public PlayerCtrl PlayerCtrl => this._CharacterCtrl as PlayerCtrl;

    [Header("PlayerVFXManager")]
    [SerializeField] protected GameObject _VFX_Rivival;
    [SerializeField] protected GameObject _VFX_Dashing;
    [SerializeField] protected GameObject _VFX_Dashing_Fire;

    protected override void LoadComponents()
    {
        base.LoadComponents();

        this.LoadVFXRivival();
        this.LoadVFXDashing();
        this.LoadVFXDashingFire();
    }

    protected virtual void LoadVFXRivival()
    {
        if (this._VFX_Rivival != null) return;

        this._VFX_Rivival = transform.Find("VFX_Rivival").gameObject;
    }

    protected virtual void LoadVFXDashing()
    {
        if (this._VFX_Dashing != null) return;

        this._VFX_Dashing = transform.Find("VFX_Dashing").gameObject;
    }
    protected virtual void LoadVFXDashingFire()
    {
        if (this._VFX_Dashing_Fire != null) return;

        this._VFX_Dashing_Fire = transform.Find("VFX_Dashing_Fire").gameObject;
    }
    protected override void Update()
    {
        base.Update();
        //Pause Game
        this.UpdateVFXRivival();

        this.UpdateVFXDashing();

    }

    protected virtual void UpdateVFXRivival()
    {
        if (this._VFX_Rivival.activeInHierarchy == this.PlayerCtrl.PlayerMovement.IsRiviving) return;

        this._VFX_Rivival.SetActive(this.PlayerCtrl.PlayerMovement.IsRiviving);

    }
    protected virtual void UpdateVFXDashing()
    {
        if (this._VFX_Dashing.activeInHierarchy == this.PlayerCtrl.PlayerMovement.IsDashing) return;

        this._VFX_Dashing.SetActive(this.PlayerCtrl.PlayerMovement.IsDashing);
        this._VFX_Dashing_Fire.SetActive(this.PlayerCtrl.PlayerMovement.IsDashing);

    }
}
