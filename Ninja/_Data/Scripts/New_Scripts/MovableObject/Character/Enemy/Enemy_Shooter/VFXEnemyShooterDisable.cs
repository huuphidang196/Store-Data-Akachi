using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VFXEnemyShooterDisable : SurMonoBehaviour
{
    [SerializeField] protected EnemyAttackActionVFXManager _EnemyAttackActionVFXManager;

    protected override void LoadComponents()
    {
        base.LoadComponents();

        this.LoadEnemyShooterAttackActionVFXManager();
    }

    protected virtual void LoadEnemyShooterAttackActionVFXManager()
    {
        if (this._EnemyAttackActionVFXManager != null) return;

        this._EnemyAttackActionVFXManager = GetComponentInParent<EnemyAttackActionVFXManager>();
    }

    protected override void OnEnable()
    {
        StartCoroutine(this.CheckIfAlive());
    }

    protected IEnumerator CheckIfAlive()
    {
        ParticleSystem ps = this.GetComponent<ParticleSystem>();
        if (ps != null) ps.Stop();

        float timeWait = 1.5f;
        yield return new WaitForSeconds(timeWait);

        if (ps != null)
        {
            ps.Clear();
            ps.Play();
        }
        timeWait = this._EnemyAttackActionVFXManager.EnemyCtrl.EnemyAnimations.Time_Delay_Attack - timeWait - 1f;
        yield return new WaitForSeconds(timeWait);
        
        this.gameObject.SetActive(false);

        //float timeDelay = this._EnemyShooterAttackActionVFXManager.EnemyCtrl.EnemyAnimations.Time_Delay_Attack;
        //yield return new WaitForSeconds(timeDelay - timeWait - timeWait);


    }
}
