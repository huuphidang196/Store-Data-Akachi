using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class CharacterObjMovement : MovableObjectMovement
{
    [Header("CharacterObjMovement")]

    [SerializeField] protected float _Speed_Dash_Horizontal;

    protected override void OnEnable()
    {
        base.OnEnable();

        this.Reborn();
    }

    protected virtual void Reborn()
    {
        
    }

    protected abstract void UpdateBoolByInputManager();

}
