using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class MovableObjCtrl : ObjectCtrl
{
    [Header("MovableObjCtrl")]

    [SerializeField] protected MObjScriptableObject _MObjScriptableObject;
    public MObjScriptableObject MObjScriptableObject => _MObjScriptableObject;

    [SerializeField] protected MovableObjectMovement _MovableObj_Movement;
    public MovableObjectMovement MovableObj_Movement => _MovableObj_Movement;

    protected override void LoadComponents()
    {
        base.LoadComponents();

        this.LoadMObjScriptableObject();
        this.LoadMovableObjectMovement();
    }
  
    protected virtual void LoadMObjScriptableObject()
    {
        if (this._MObjScriptableObject != null) return;

        string nameofS_Obj = this.GetNameFolderTypeObject() +"/" + this.GetNameFolderTypeObjectUsing() + transform.name.Split('_', StringSplitOptions.RemoveEmptyEntries)[0] +"/" + transform.name + "SO";

        string path = "ScriptableObject/MovableObjScriptableObject/" + nameofS_Obj;
        Debug.Log(path);
        this._MObjScriptableObject = Resources.Load<MObjScriptableObject>(path);

    }

    protected virtual string GetNameFolderTypeObjectUsing()
    {
        return "";
    }

    protected abstract string GetNameFolderTypeObject();

    protected virtual void LoadMovableObjectMovement()
    {
        if (this._MovableObj_Movement != null) return;

        this._MovableObj_Movement = GetComponentInChildren<MovableObjectMovement>();
    }

}
