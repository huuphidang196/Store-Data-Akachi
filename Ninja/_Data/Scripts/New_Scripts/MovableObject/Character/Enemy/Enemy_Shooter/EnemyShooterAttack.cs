using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShooterAttack : EnemyAttack
{
    [SerializeField] protected bool canSpawn = false;

    protected override void Update()
    {
        base.Update();

        if (!this.isSlash) return;

        ParticleSystem ps = this.EnemyCtrl.EnemyAttackActionVFXManager.VFX_Attack.GetComponent<ParticleSystem>();
        if (this.canSpawn == ps.isPlaying) return;

        this.canSpawn = ps.isPlaying;

        if (!this.canSpawn) return;

        this.EnemyAttackShoot();

        //this.ResetAllFigure();
    }

    protected virtual void EnemyAttackShoot()
    {
        // Spawn bullet
        Transform bullet = WeaponCharacterSpawner.Instance.Spawn(WeaponCharacterSpawner.Name_Bullet_Enemy_Shooter, this.transform.position, Quaternion.identity);

        //Set Direction fly
        BulletEnemyShooterCtrl bulletEnemyShooterCtrl = bullet.GetComponent<BulletEnemyShooterCtrl>();
        bulletEnemyShooterCtrl.WeaponCharacterMovement.SetDirectionFly(this._CharacterCtrl.transform);

        bullet.localScale = Vector3.one;
        bulletEnemyShooterCtrl.name = WeaponCharacterSpawner.Name_Bullet_Enemy_Shooter;
        bulletEnemyShooterCtrl.gameObject.SetActive(true);
        //Debug.Log("Shoot");
    }
}
