using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : CharacterObjMovement
{
    public EnemyCtrl EnemyCtrl => this._MovableObjCtrl as EnemyCtrl;

    [Header("EnemyMovement")]
    [SerializeField] protected bool isFacingPlayer;

    [SerializeField] protected bool isChangeDir = false;
    public bool IsChangeDir => this.isChangeDir;

    protected override void Reborn()
    {
        base.Reborn();

        this._Rigidbody2D.bodyType = RigidbodyType2D.Dynamic;
    }

    protected override void ResetSpeedConfiguration()
    {
        this._Move_Right = true;

        this._Horizontal = this.EnemyCtrl.EnemySO.Speed_Move_Horizontal;
        this._Speed_Dash_Horizontal = this.EnemyCtrl.EnemySO.Speed_Dash_Horizontal;
        this._Speed_Move_Horizontal = this._Horizontal;
        this.isFacingPlayer = false;
    }
    protected override void LoadRigidbody2D()
    {
        base.LoadRigidbody2D();

        this._Rigidbody2D.gravityScale = 3f;
        this._Rigidbody2D.constraints = RigidbodyConstraints2D.FreezeRotation;
    }

    protected override void UpdateBoolByInputManager()
    {
        //Change Direction by check forward player and enemy Impact turn collider2D
        this.isChangeDir = (this.EnemyCtrl.EnemyCheckContactEnviroment.EnemyCheckForward.IsChangedDirForward || 
            this.EnemyCtrl.EnemyImpact.IsImpact_Trigger);

        if (this.isChangeDir)
            this.ChangeDirectionMovement();

        //Must facing after set change Direct
        this.isFacingPlayer = this.EnemyCtrl.EnemyCheckContactEnviroment.EnemyCheckForward.CheckIsFacingPlayer();

    }

    protected override void Update()
    {
        if (this.EnemyCtrl.EnemyDamReceiver.ObjIsDead) return;

        this.UpdateBoolByInputManager();
        this.UpdateSpeedHorizontal();
        base.Update();
    }

    protected virtual void UpdateSpeedHorizontal()
    {
        if (this.EnemyCtrl.EnemyAttack.isSlashing)
        {
            this._Horizontal = 0;
            return;
        } 
            
        float speed_Move = this.isFacingPlayer ? this._Speed_Dash_Horizontal : this._Speed_Move_Horizontal;

        this._Horizontal = (this._Move_Right) ? 1f * speed_Move : -1f * speed_Move;
    }

    protected virtual void FixedUpdate()
    {
        if (this.EnemyCtrl.EnemyDamReceiver.ObjIsDead) return;

        this._Rigidbody2D.velocity = new Vector2(this._Horizontal, this._Rigidbody2D.velocity.y);
        //Debug.Log("Speed : " + this._Rigidbody2D.velocity);
    }

    protected virtual void ChangeDirectionMovement()
    {
        this._Move_Right = !this._Move_Right;
        this.EnemyCtrl.EnemyImpact.SetChangeImpacTurn();
    }
}
