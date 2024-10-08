using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
public class WeaponCharacterModelSpriteRenderer : WeaponCharacterAbstract
{
    [SerializeField] protected SpriteRenderer _Model_SpriteRenderer;

    protected override void LoadComponents()
    {
        base.LoadComponents();

        this.LoadModelSpriteRenderer();
    }

    protected virtual void LoadModelSpriteRenderer()
    {
        if (this._Model_SpriteRenderer != null) return;

        this._Model_SpriteRenderer = GetComponent<SpriteRenderer>();
    }

    protected override void OnEnable()
    {
        base.OnEnable();

        this._Model_SpriteRenderer.enabled = true;
    }

    protected virtual void Update()
    {
        if (this._Model_SpriteRenderer.enabled != this._WeaponCharacterCtrl.WeaponCharacterImpact.IsImpact_Trigger) return;

        this._Model_SpriteRenderer.enabled = !this._WeaponCharacterCtrl.WeaponCharacterImpact.IsImpact_Trigger;
    }
}
