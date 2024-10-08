using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class CharacterCheckForward : CharacterContactAbstract
{
    [Header("CharacterCheckForward")]
    [SerializeField] protected float _Length_Raycast = 0.5f;

    [SerializeField] protected Transform _PosForwardCheck;

    // [SerializeField] protected LayerMask[] _ObjForwardLayer;
    [SerializeField] protected string[] _ObjForwardLayer;

    [SerializeField] protected bool _ForwardObjRight = false;
    public bool ForwardObjRight => _ForwardObjRight;

    [SerializeField] protected RaycastHit2D[] _Hits;

    [SerializeField] protected Vector2 _Direction_Raycast2D;

    protected override void ResetValue()
    {
        this.LoadLayerMaskForward();

        this._Length_Raycast = this._CharacterCheckContactEnviroment.CharacterCtrl.CharacterSO.Length_Ray_Forward_Limit;
    }

    protected abstract void LoadLayerMaskForward();

    protected virtual void LoadPosCheckForward()
    {
        if (this._PosForwardCheck != null) return;

        this._PosForwardCheck = transform.Find("Pos_Check_Forward").transform;
    }

    protected override void LoadComponents()
    {
        base.LoadComponents();

        this.LoadPosCheckForward();
    }

    protected virtual void Update()
    {
        if (this._CharacterCheckContactEnviroment.CharacterCtrl.ObjDamageReceiver.ObjIsDead) return;

        this.GenerateAndDrawAllRaycastHits();

        this._ForwardObjRight = this.CheckForwardIsHaveRightObjectLayerCustom(this._ObjForwardLayer[0]);
    }

    public virtual bool CheckForwardIsHaveRightObjectLayerCustom(string layerCheck)
    {
        RaycastHit2D hit = this.GetHitForwardIsHaveRightObjectLayerCustom(layerCheck);

        return hit.collider != null;
    }

    protected virtual RaycastHit2D GetHitForwardIsHaveRightObjectLayerCustom(string layerCheck)
    {
        foreach (RaycastHit2D hit in this._Hits)
        {
            //  Debug.Log(hit.collider.gameObject.layer.ToString() + ", layercheck : " + LayerMask.NameToLayer(layerCheck).ToString());
            if (hit.collider.gameObject.layer == LayerMask.NameToLayer(layerCheck)) return hit;
        }

        return new RaycastHit2D();
    }

    protected virtual void GenerateAndDrawAllRaycastHits()
    {
        this._Direction_Raycast2D = this._CharacterCheckContactEnviroment.CharacterCtrl.transform.localScale.x * Vector2.right;
        Debug.DrawRay(this._PosForwardCheck.position, this._Direction_Raycast2D * this._Length_Raycast, Color.red);
        // Thực hiện Raycast
        this._Hits = Physics2D.RaycastAll(this._PosForwardCheck.position, this._Direction_Raycast2D, this._Length_Raycast);
    }

}
