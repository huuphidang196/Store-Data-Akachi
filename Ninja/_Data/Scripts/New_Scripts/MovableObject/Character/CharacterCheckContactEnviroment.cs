using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterCheckContactEnviroment : CharacterAbstract
{
    [SerializeField] protected CharacterCheckForward _CharacterCheckForward;
    public CharacterCheckForward CharacterCheckForward => _CharacterCheckForward;

    protected override void LoadComponents()
    {
        base.LoadComponents();

        this.LoadCharacterCheckForward();
    }

    protected virtual void LoadCharacterCheckForward()
    {
        if (this._CharacterCheckForward != null) return;

        this._CharacterCheckForward = GetComponentInChildren<CharacterCheckForward>();
    }
}
