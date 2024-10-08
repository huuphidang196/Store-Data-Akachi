using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class WeaponCharacterCtrl : MovableObjCtrl
{
    public WeaponSO WeaponSO => this._MObjScriptableObject as WeaponSO;

    public WeaponCharacterDamReceiver WeaponCharacterDamReceiver => this._ObjDamageReceiver as WeaponCharacterDamReceiver;
    public WeaponCharacterImpact WeaponCharacterImpact => this._ObjImpact as WeaponCharacterImpact;

    public WeaponCharacterMovement WeaponCharacterMovement => this._MovableObj_Movement as WeaponCharacterMovement;

    [Header("WeaponCharacterCtrl")]

    [SerializeField] protected Transform _Model;
    public Transform Model => this._Model;

    protected override void LoadComponents()
    {
        base.LoadComponents();

        this.LoadModel();
    }

    protected virtual void LoadModel()
    {
        if (this._Model != null) return;

        this._Model = transform.Find("Model");
    }

    protected override string GetNameFolderTypeObject()
    {
        return "Weapon";
    }
}
