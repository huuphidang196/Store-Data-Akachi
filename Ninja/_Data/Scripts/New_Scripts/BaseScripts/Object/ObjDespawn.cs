using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ObjDespawn : ObjectAbstract
{
    protected virtual void FixedUpdate()
    {
        this.Despawning();
    }

    protected virtual void Despawning()
    {
        if (!this.CanDespawn()) return;
        this.DespawnObject();
    }

    public virtual void DespawnObject()
    {
       // Destroy(transform.parent);
    }    
 
    //Tùy theo despawn by distance or time, nên chắc chắc candespawn sẽ bị ghi đè, 2 concept khác nhau nên để abstract
    protected abstract bool CanDespawn();

     
}
