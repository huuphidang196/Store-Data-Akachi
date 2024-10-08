using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class CharacterImpactTrigger : ObjImpactTrigger
{
    protected override bool CheckConditionOverallAllowImpact()
    {
        string nameLayerTurn = this.GetNameLayerImpactTrigger();
        return this.CheckParentObjectImpactWithAnyLayer(nameLayerTurn);
    }

    protected virtual string GetNameLayerImpactTrigger()
    {
        return "";
    }
}
