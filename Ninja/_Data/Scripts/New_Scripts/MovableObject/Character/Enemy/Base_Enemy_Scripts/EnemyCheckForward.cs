using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCheckForward : CharacterCheckForward
{
    public EnemyCheckContactEnvirment EnemyCheckContactEnviroment => this._CharacterCheckContactEnviroment as EnemyCheckContactEnvirment;
    [Header("EnemyCheckForward")]
    [SerializeField] protected Transform _TargetFollow;
    public Transform TargetFollow => this._TargetFollow;

    [SerializeField] protected float _Distance_Change_Dir_Enemy = 0.5f;
    [SerializeField] protected float _DetectionRange = 3f;
    [SerializeField] protected float _FieldOfViewAngle = 180f;

    [SerializeField] protected bool isChangedDirForward = false;
    public bool IsChangedDirForward => this.isChangedDirForward;

    protected override void LoadLayerMaskForward()
    {
        if (this._ObjForwardLayer.Length > 0) return;
        //this._ObjForwardLayer = new LayerMask[2];
        //this._ObjForwardLayer[0] = 1 << LayerMask.NameToLayer("Player");
        //this._ObjForwardLayer[1] = 1 << LayerMask.NameToLayer("Enemy");
        this._ObjForwardLayer = new string[2];
        this._ObjForwardLayer[0] = "Player";
        this._ObjForwardLayer[1] = "Enemy";
    }

    protected override void ResetValue()
    {
        base.ResetValue();

        this._Distance_Change_Dir_Enemy = this.EnemyCheckContactEnviroment.EnemyCtrl.EnemySO.Distance_Change_Dir_Enemy;
        this._DetectionRange = this.EnemyCheckContactEnviroment.EnemyCtrl.EnemySO.DetectionRange;
        this._FieldOfViewAngle = this.EnemyCheckContactEnviroment.EnemyCtrl.EnemySO.FieldOfViewAngle;
    }
    protected override void Update()
    {
        base.Update();
        this.UpdateTargetPlayerAppear();
    }

    protected virtual void UpdateTargetPlayerAppear()
    {
        if (!this.CheckIsFacingPlayer())
        {
            this.ScanTargetOnFOV();
            return;
        }
        // Transform col = this.CheckForwardIsHaveRightObjectLayer().collider.transform;

        this._TargetFollow = PlayerCtrl.Instance.transform;
        this.isChangedDirForward = false;
        // Debug.Log("Don't change");
    }

    protected virtual void SetChangeDirection(Vector2 directionToPlayer)
    {
        float localX = this.EnemyCheckContactEnviroment.EnemyCtrl.transform.localScale.x;
        this.isChangedDirForward = (localX * directionToPlayer.x > 0) ? false : true;
    }

    protected virtual void ScanTargetOnFOV()
    {
        if (this._TargetFollow == null)
        {
            this.isChangedDirForward = false;
            return;
        }
        Vector2 directionToPlayer = this._TargetFollow.position - this.EnemyCheckContactEnviroment.EnemyCtrl.transform.position;
        float angle = Vector2.Angle(this.EnemyCheckContactEnviroment.EnemyCtrl.transform.right, directionToPlayer);

        if (directionToPlayer.magnitude < this._DetectionRange && angle < this._FieldOfViewAngle)
        {
            // Player nằm trong FOV, bắt đầu follow
            this.SetChangeDirection(directionToPlayer);
            //Debug.Log("Detect, magnitude" + directionToPlayer.magnitude + ", angle : " + angle);
            return;
        }
        //Debug.Log("NonDetect, magnitude" + directionToPlayer.magnitude + ", angle : " + angle);

        //Check Forward cannot find and it isn't on sacn range so target = null
        this._TargetFollow = null;
    }

    public virtual bool CheckIsFacingPlayer()
    {
        return this._ForwardObjRight;
    }

    public virtual float GetDistanceFacingPlayer()
    {
        if (!this.CheckIsFacingPlayer()) return 0;

        return this.GetDistanceForwardIsHaveRightObjectLayerCustom(this._ObjForwardLayer[0]);
    }

    protected virtual float GetDistanceForwardIsHaveRightObjectLayerCustom(string layerCheck)
    {
        RaycastHit2D hit = this.GetHitForwardIsHaveRightObjectLayerCustom(layerCheck);

        if (hit.collider == null) return 0;

        return hit.distance;
    }
}
