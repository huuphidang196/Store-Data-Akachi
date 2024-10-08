using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class CharacterAnimation : CharacterAbstract
{
    [SerializeField] protected Animator _Animator;

    [SerializeField] protected AnimationClip[] _Clips;

    [SerializeField] protected float _Timer_Animation = 0f;

    [SerializeField] protected float _Time_Duration = 0f;
    public float Time_Duration => _Time_Duration;

    [SerializeField] protected bool isDead = false;

    [SerializeField] protected bool _Run_Ani = false;

    protected override void LoadComponents()
    {
        base.LoadComponents();

        this.LoadCharacterAnimator();
        this.LoadAllClipsAnimation();
    }

    protected virtual void LoadCharacterAnimator()
    {
        if (this._Animator != null) return;

        this._Animator = GetComponent<Animator>();
    }
    protected override void OnEnable()
    {
        base.OnEnable();
        this._Timer_Animation = this._Time_Duration = 0f;
    }

    protected override void Start()
    {
        base.Start();

        this.LoadAllClipsAnimation();
    }


    protected virtual void LoadAllClipsAnimation()
    {
        this._Clips = this._Animator.runtimeAnimatorController.animationClips;
    }

    public virtual float GetAnimationDuration(string nameAnimation)
    {
        foreach (AnimationClip clip in this._Clips)
        {
            if (clip.name == nameAnimation) return clip.length;

        }

        return 1;
    }
    protected virtual void Update()
    {
        this.isDead = this._CharacterCtrl.ObjDamageReceiver.ObjIsDead;
        if (this.isDead) this.SetAnimationDead();

        this.ProcessUpdateProcedureObjectLife();

    }

    protected abstract void ProcessUpdateProcedureObjectLife();

    public virtual bool CheckTimer()
    {
        this._Timer_Animation += Time.deltaTime;
        return (this._Timer_Animation >= this._Time_Duration);

    }

    protected virtual void SetAnimationDead()
    {
        string nameAnimation = "Dead";

        if (this.CheckAnimationCurrent(nameAnimation)) return;

        this._Animator.SetTrigger("Dead");

    }
    protected virtual bool CheckAnimationCurrent(string nameClip)
    {
        AnimatorStateInfo currentState = this._Animator.GetCurrentAnimatorStateInfo(0);
        if (currentState.fullPathHash != 0)
        {
            string currentClipName = this._Animator.GetCurrentAnimatorClipInfo(0)[0].clip.name;

            return currentClipName == nameClip;
            // Debug.Log("Current Animation Clip: " + currentClipName);
        }

        return false;
    }
    protected virtual void SetTimeDurationByAnimationClip(string nameAnimation)
    {
        this._Time_Duration = this.GetAnimationDuration(nameAnimation);

        if (nameAnimation.Contains("Idle_Throw")) this._Time_Duration /= 2f;
    }
}
