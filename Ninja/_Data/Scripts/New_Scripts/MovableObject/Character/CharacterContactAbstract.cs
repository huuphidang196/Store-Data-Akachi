using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterContactAbstract : SurMonoBehaviour
{
    [SerializeField] protected CharacterCheckContactEnviroment _CharacterCheckContactEnviroment;
    public CharacterCheckContactEnviroment CharacterCheckContactEnviroment => _CharacterCheckContactEnviroment;

    protected override void LoadComponents()
    {
        base.LoadComponents();

        this.LoadCharacterCheckContactEnviroment();
    }

    protected virtual void LoadCharacterCheckContactEnviroment()
    {
        if (this._CharacterCheckContactEnviroment != null) return;

        this._CharacterCheckContactEnviroment = transform.parent.GetComponent<CharacterCheckContactEnviroment>();
    }
}
