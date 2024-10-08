using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterCtrl : MovableObjCtrl
{
    public CharacterScriptableObject CharacterSO => this._MObjScriptableObject as CharacterScriptableObject;

    [Header("Character Ctrl")]

    [SerializeField] protected CharacterCheckContactEnviroment _CharacterCheckContactEnviroment;
    public CharacterCheckContactEnviroment CharacterCheckContactEnviroment => _CharacterCheckContactEnviroment;

    [SerializeField] protected CharacterAnimation _CharacterAnimation;

    [SerializeField] protected CharacterVFXManager _CharacterVFXManager;
    public CharacterVFXManager CharacterVFXManager => this._CharacterVFXManager;
    protected override void LoadComponents()
    {
        base.LoadComponents();

        this.LoadCharacterCheckContactEnviroment();
        this.LoadCharacterAnimation();
        this.LoadCharacterVFXManager();
    }

    protected virtual void LoadCharacterAnimation()
    {
        if (this._CharacterAnimation != null) return;

        this._CharacterAnimation = GetComponentInChildren<CharacterAnimation>();
    }

    protected virtual void LoadCharacterCheckContactEnviroment()
    {
        if (this._CharacterCheckContactEnviroment != null) return;

        this._CharacterCheckContactEnviroment = GetComponentInChildren<CharacterCheckContactEnviroment>();
    }
    protected virtual void LoadCharacterVFXManager()
    {
        if (this._CharacterVFXManager != null) return;

        this._CharacterVFXManager = GetComponentInChildren<CharacterVFXManager>();
    }

    protected override string GetNameFolderTypeObject()
    {
        return "Character";
    }
}
