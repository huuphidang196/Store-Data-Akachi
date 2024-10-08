using System;
using UnityEngine;

public class PlayerAnimation : CharacterAnimation
{
    [SerializeField] protected PlayerCtrl _PlayerCtrl => this._CharacterCtrl as PlayerCtrl;

    [Header("PlayerAnimation")]
    [SerializeField] protected bool _Jump_Ani = false;
    [SerializeField] protected bool _Dropping = false;
    [SerializeField] protected bool _Wall_Sliding_Ani = false;
    [SerializeField] protected bool _Attack_Throw_Ani = false;
    [SerializeField] protected bool _Attack_Dashing_Ani = false;

    [SerializeField] protected bool _Hiden_Mode_Skill_Ani = false;

    [SerializeField] protected bool _Rivive_Again_Ani = false;

    [SerializeField] protected float _Time_Delay_Hiden = 5f;
    public float Time_Delay_Hiden => _Time_Delay_Hiden;

    protected override void ProcessUpdateProcedureObjectLife()
    {
        this.UpdateBoolByInputManager();

        if (this._Rivive_Again_Ani)
        {
            this.SetAnimationPlayerIsRiviving();
            return;
        }

        if (this._Hiden_Mode_Skill_Ani)
        {
            this.SetAnimationHidenModeSkill();
            return;
        }

        if (this._Attack_Dashing_Ani)
        {
            this.SetAnimationDashing();
            return;
        }

        int id_Attack = !this._Attack_Throw_Ani ? 0 : 1;
        if (id_Attack == 0) this._Timer_Animation = 0f;

        this._Animator.SetFloat("Throw_ID", id_Attack);

        if (!this._Wall_Sliding_Ani && !this._Jump_Ani && !this._Dropping) this.SetAnimationRun();

        if (this._Jump_Ani) this.SetAnimationJump();

        if (this._Dropping) this.SetAnimationDropping();

        if (this._Wall_Sliding_Ani) this.SetAnimationSliding();

        this.ReturnIdleFromAllState();

    }



    protected virtual void ReturnIdleFromAllState()
    {
        //if (!this._Rivive_Again_Ani) InputManager.Instance.PlayerRiviveAgainCompleted();

        if (this._Jump_Ani || this._Attack_Throw_Ani) return;

        if (this.CheckAnimationCurrent("Idle")) return;

        if (!this._Hiden_Mode_Skill_Ani) this.SetAnimationHidenCompleted();

        if (!this._Dropping) this.SetAnimationDropped();

        if (!this._Wall_Sliding_Ani) this.SetAnimationWallSlided();


    }

    protected virtual void UpdateBoolByInputManager()
    {
        this._Attack_Throw_Ani = !this.isDead && !this._Hiden_Mode_Skill_Ani && InputManager.Instance.Press_Attack_Throw;

        this._Run_Ani = (this._PlayerCtrl.PlayerCheckContactEnviroment.PlayerCheckGround.IsGround
            && InputManager.Instance.Press_Left != InputManager.Instance.Press_Right);

        this._Jump_Ani = (!this.isDead && !this._Hiden_Mode_Skill_Ani && this._PlayerCtrl.PlayerMovement.Rigidbody2D.velocity.y > 0.2f
            && !this._PlayerCtrl.PlayerCheckContactEnviroment.PlayerCheckGround.IsGround);

        this._Wall_Sliding_Ani = !this.isDead && !this._Hiden_Mode_Skill_Ani && this._PlayerCtrl.PlayerMovement.IsWallSliding;

        this._Dropping = (!this.isDead && !this._Hiden_Mode_Skill_Ani && !this._Jump_Ani && !this._PlayerCtrl.PlayerCheckContactEnviroment.PlayerCheckGround.IsGround && !this._Wall_Sliding_Ani);

        this._Attack_Dashing_Ani = !this.isDead && !this._Hiden_Mode_Skill_Ani && this._PlayerCtrl.PlayerMovement.IsDashing;

        this._Hiden_Mode_Skill_Ani = !this.isDead && this._PlayerCtrl.PlayerMovement.IsHiding;

        this._Rivive_Again_Ani = InputManager.Instance.IsRiviving;

    }

    protected virtual void SetAnimationRun()
    {
        string nameAnimation = (this._Run_Ani) ? "Run" : "Idle";

        if (this.CheckAnimationCurrent(nameAnimation)) return;

        this._Animator.SetBool("Run", this._Run_Ani);
    }

    protected virtual void SetAnimationJump()
    {
        string nameAnimation = "Jump";

        if (this.CheckAnimationCurrent(nameAnimation)) return;

        this._Animator.SetTrigger("Jump");
    }

    protected virtual void SetAnimationSliding()
    {
        string nameAnimation = "Wall_Sliding";

        if (this.CheckAnimationCurrent(nameAnimation)) return;

        this._Animator.SetTrigger("Sliding");
    }
    protected virtual void SetAnimationDropping()
    {
        string nameAnimation = "Drop";

        if (this.CheckAnimationCurrent(nameAnimation)) return;

        this._Animator.SetTrigger("Dropping");
        // Debug.Log("Droopping");
    }

    protected virtual void SetAnimationDashing()
    {
        string nameAnimation = "Dashing";

        if (this.CheckAnimationCurrent(nameAnimation)) return;

        this._Animator.SetTrigger("Dashing");
    }

    protected virtual void SetAnimationPlayerIsRiviving()
    {
        string nameAnimation = "Rivival";

        this.SetTimeDurationByAnimationClip(nameAnimation);

        if (!this.CheckTimer())
        {
            if (this.CheckAnimationCurrent(nameAnimation)) return;

            this._Animator.SetTrigger("Rivival");
            return;
        }
        //Debug.Log("Completed");
        InputManager.Instance.PlayerRiviveAgainCompleted();
    }
    protected override bool CheckAnimationCurrent(string nameClip)
    {
        if (this._Attack_Throw_Ani)
        {
            nameClip += "_Throw";
            this.SetTimeDurationByAnimationClip(nameClip);
            //   Debug.Log("Name : " + nameClip + ", Time : " + this._Time_Duration);
        }

        bool result = base.CheckAnimationCurrent(nameClip);
        //if (result) Debug.Log("Name : " + nameClip + ", Time : " + this._Time_Duration);

        return result;
    }

    protected virtual void SetAnimationHidenModeSkill()
    {
        string nameAnimation = "Hiden_Mode";

        this._Time_Duration = this._Time_Delay_Hiden;

        if (!this.CheckTimer())
        {
            if (this.CheckAnimationCurrent(nameAnimation)) return;

            this._Animator.SetTrigger("Hiden");
            //  Debug.Log("HIden");
        }
    }

    #region Return_Idle
    protected virtual void SetAnimationDropped()
    {
        //adjust for wall sliding
        string nameAnimation = "Drop";

        this.SetAnimationReturnIdleByName(nameAnimation);
    }

    protected virtual void SetAnimationWallSlided()
    {
        string nameAnimation = "Wall_Sliding";

        this.SetAnimationReturnIdleByName(nameAnimation);
    }

    protected virtual void SetAnimationHidenCompleted()
    {
        string nameAnimation = "Hiden_Mode";

        this.SetAnimationReturnIdleByName(nameAnimation);
        // Debug.Log("Hiden_Mode");

    }
    protected virtual void ReturnIdle() => this._Animator.SetTrigger("Dropped");//=> Debug.Log("Return Idle");

    protected virtual void SetAnimationReturnIdleByName(string nameAnimation)
    {
        //Debug.Log("réesult: " + this.CheckAnimationCurrent(nameAnimation) + ", current : " + this._Animator.GetCurrentAnimatorClipInfo(0)[0].clip.name);
        if (!this.CheckAnimationCurrent(nameAnimation)) return;

        this.ReturnIdle();
        //  Debug.Log("Name: " + nameAnimation);

    }
    #endregion
}
