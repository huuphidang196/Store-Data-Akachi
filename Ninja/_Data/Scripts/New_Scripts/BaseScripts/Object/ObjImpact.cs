using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(BoxCollider2D))]
[RequireComponent(typeof(Rigidbody2D))]

public class ObjImpact : ObjectAbstract
{
    [Header("Object Impact")]
    //Từng weapon hay fx đều có radius riêng
    [SerializeField] protected Transform _parentObj;
    [SerializeField] protected bool isImpact = false;
    public bool IsImpact => isImpact;

   // [SerializeField] protected float _maxRadius = 2f;
    [SerializeField] protected Rigidbody2D _Rigidbody2D;
    [SerializeField] protected BoxCollider2D _boxCollider;


    protected override void OnEnable()
    {
        this.isImpact = false;
    }

    protected override void LoadComponents()
    {
        base.LoadComponents();

        this.LoadCollider2D();
        this.LoadRigidbody2D();
    }

    protected virtual void LoadCollider2D()
    {
        if (this._boxCollider != null) return;

        this._boxCollider = GetComponent<BoxCollider2D>();
      //  this._boxCollider.isTrigger = true;
    }

    protected virtual void LoadRigidbody2D()
    {
        if (this._Rigidbody2D != null) return;

        this._Rigidbody2D = GetComponent<Rigidbody2D>();
        //this._rigidbody.isKinematic = true;
    }    

    protected virtual void OnCollisionEnter2D(Collision2D collision)
    {
        this._parentObj = (collision.transform.parent == null) ? collision.transform : collision.transform.parent;

        bool allowImpact = this.CheckObjectImapactAllowedImpactCollision();
        if (!allowImpact)
        {
            this._parentObj = null;
            return;
        }

        this.isImpact = true;

        this.ProcessAfterObjectImapactCollision();
       // Debug.Log(transform.name + " Impact " + collision.transform.name);
    }
    protected virtual bool CheckObjectImapactAllowedImpactCollision() => false;
    protected virtual void ProcessAfterObjectImapactCollision()
    {

    }    

}
