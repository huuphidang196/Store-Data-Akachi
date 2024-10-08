using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDamReceiver : ObjDamageReceiver
{
    public PlayerCtrl PlayerCtrl => this._ObjectCtrl as PlayerCtrl;

    protected override void Start()
    {
        base.Start();
        Physics2D.IgnoreLayerCollision(LayerMask.NameToLayer("Player"), LayerMask.NameToLayer("Enemy"), true);
    }
    protected override float GetMaxHP()
    {
        return 1;// Load from Scriptable Object
    }
    protected override void OnDead()
    {
        this.PlayerCtrl.PlayerObjDead.EventPlayerDead();

        InputManager.Instance.SetFalseAllBoolWhenPlayerDead();
        //  Debug.Log("Player Dead");

        this.PlayerCtrl.gameObject.layer = LayerMask.NameToLayer("Default");
        this.PlayerCtrl.PlayerMovement.Rigidbody2D.gravityScale = 10f;

    }

    public virtual void RiviveCharacter()
    {
        this.ReBorn();
        this.PlayerCtrl.gameObject.layer = LayerMask.NameToLayer("Player");
        this.PlayerCtrl.PlayerMovement.Rigidbody2D.gravityScale = 3f;

    }

    public override void DeductHP(float damage)
    {
        if (this.PlayerCtrl.PlayerMovement.IsDashing) return;

        base.DeductHP(damage);
    }
   
}
