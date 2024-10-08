using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjImpactTargetPlayer : ObjImpact
{
    //  [Header("Object Impact Harmful")]
    public ObjCtrlHurtPlayer ObjCtrlHurtPlayer => this._ObjectCtrl as ObjCtrlHurtPlayer;

    //protected override void OnCollisionEnter2D(Collision2D collision)
    //{
    //    this._parentObj = (collision.transform.parent == null) ? collision.transform : collision.transform.parent;

    //    base.OnCollisionEnter2D(collision);

    //}

    protected override bool CheckObjectImapactAllowedImpactCollision()
    {
        // if (this._parentObj.gameObject.layer == LayerMask.NameToLayer("Player")) return true;
        if (this._parentObj.gameObject.layer == LayerMask.NameToLayer("Player")) return true;
        //if (this._parentObj.CompareTag("Inventory")) return false;

        //if (this._parentObj.CompareTag("VFX")) return false;

        //if (this._parentObj.CompareTag("Weapon")) return false;

        //if (this._parentObj.CompareTag("ItemDrop")) return false;

        //if (this._parentObj.CompareTag("SkillChoice")) return false;

        return false;

    }

    protected override void ProcessAfterObjectImapactCollision()
    {
        //Send Damage to Player
        ObjDamSenderInfinity objDamSenderInfinity = this.ObjCtrlHurtPlayer.ObjDamSenderInfinity;

        objDamSenderInfinity.Send(this._parentObj);
    }
}
