using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyImpact : CharacterImpactTrigger
{
    public EnemyCtrl EnemyCtrl => this._ObjectCtrl as EnemyCtrl;

    protected override string GetNameLayerImpactTrigger()
    {
        return "BoxChangeDir";
    }

    protected override void ProcessImpactTrigger()
    {
        
    }
}
