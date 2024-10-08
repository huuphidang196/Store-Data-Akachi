using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjInjuredDamReceiver : ObjDamageReceiver
{

    protected override void ReBorn()
    {
        this._maxHP = this.GetMaxHp();
        base.ReBorn();
    }
    public override void DeductHP(float damage)
    {
        base.DeductHP(damage);
        this.SpawnTextDrop(damage);
    }

    protected virtual void SpawnTextDrop(float damage)
    {
       // string nameText = this.GetNameTextDropDeductHP();
       // this.SpawnTextDropByName(damage, nameText);
    }

    protected virtual void SpawnTextDropByName(float damage, string nameText)
    {
        //Spawn Text Drop
      //  Transform txtDamage = TextDropSpawner.Instance.Spawn(nameText, transform.parent.position, Quaternion.identity);
        //Set Text Damage
       // TextDropRealtimeCtrl textDropRealtime = txtDamage.GetComponent<TextDropRealtimeCtrl>();
      //  textDropRealtime.SetDamageTextDropAndShow(damage);
        //txtDamage.gameObject.SetActive(true);
    }

    //protected abstract string GetNameTextDropDeductHP();


    protected virtual float GetMaxHp()
    {
        return 1;
    }

    protected override void OnDead()
    {
        //OVerride
    }
}
