using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCheckContactEnviroment : CharacterCheckContactEnviroment
{
    public PlayerCheckForward PlayerCheckForward => this._CharacterCheckForward as PlayerCheckForward;

    [SerializeField] protected PlayerCheckGround _PlayerCheckGround;
    public PlayerCheckGround PlayerCheckGround => _PlayerCheckGround;

    protected override void LoadComponents()
    {
        base.LoadComponents();

        this.LoadPlayerCheckGround();
    }

    protected virtual void LoadPlayerCheckGround()
    {
        if (this._PlayerCheckGround != null) return;

        this._PlayerCheckGround = GetComponentInChildren<PlayerCheckGround>();
    }
}
