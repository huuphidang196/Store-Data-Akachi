using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ObjImpactTrigger : ObjImpact
{
    [SerializeField] protected bool isImpact_Trigger;
    public bool IsImpact_Trigger => this.isImpact_Trigger;

    protected override void OnEnable()
    {
        base.OnEnable();

        this.Reborn();

    }

    protected virtual void Reborn()
    {
        this.isImpact_Trigger = false;
    }

    protected override void LoadCollider2D()
    {
        base.LoadCollider2D();
        this._boxCollider.isTrigger = true;
    }
    protected virtual void OnTriggerEnter2D(Collider2D collider2D)
    {
        if (this._ObjectCtrl.ObjDamageReceiver.ObjIsDead) return;
        //Debug.Log("collider2D : " + collider2D);
        this._parentObj = this.GetParentOfCollider(collider2D); 
        // Debug.Log("Name " + this._parentObj.name);

        this.isImpact_Trigger = this.CheckConditionOverallAllowImpact();

        if (this.isImpact_Trigger) this.ProcessImpactTrigger();
        //  Debug.Log(this.isImpacted_Turn);
    }

    protected virtual Transform GetParentOfCollider(Collider2D collider2D)
    {      
        return (collider2D.transform.parent == null) ? collider2D.transform : collider2D.transform.parent;
    }

    protected virtual bool CheckConditionOverallAllowImpact()
    {
        return true;
    }

    protected abstract void ProcessImpactTrigger();

    public virtual void SetChangeImpacTurn() => this.isImpact_Trigger = false;

    protected virtual bool CheckParentObjectImpactWithAnyLayer(string nameLayerCheck)
    {
        return this._parentObj.gameObject.layer == LayerMask.NameToLayer(nameLayerCheck);
    }

    protected virtual bool CheckParentObjectImpactWithAnyLayer(string[] strnameLayerCheck)
    {
        foreach (string itemName in strnameLayerCheck)
        {
            if (this.CheckParentObjectImpactWithAnyLayer(itemName)) return true;
        }

        return false;
    }
}
