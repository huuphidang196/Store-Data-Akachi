using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SystemController : SurMonoBehaviour
{
    public static int CountScene = 16;

    [SerializeField] protected SystemConfig _SystemConfig;
    public SystemConfig SystemConfig => _SystemConfig;

    protected override void LoadComponents()
    {
        base.LoadComponents();

        this.LoadSystemConfig();
    }

    protected virtual void LoadSystemConfig()
    {
        if (this._SystemConfig != null) return;
        string namePath = "ScriptableObject/SystemConfig/" + this.GetNameGameSubPath();
        Debug.Log(namePath);
        this._SystemConfig = Resources.Load<SystemConfig>(namePath);
    }

    protected virtual string GetNameGameSubPath()
    {
        return this.transform.name + "/" + this.GetNameConfig();
    }

    protected virtual string GetNameConfig()
    {
        return transform.name;
    }
}
