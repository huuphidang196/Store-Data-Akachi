using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : Spawner
{
    private static EnemySpawner _instance;
    public static EnemySpawner Instance => _instance;

    public static string Name_Shuriken = "Shuriken_Weapon";

    [Header("EnemySpawner")]
    //Holder to consist all enemy object Active
    [SerializeField] protected Transform _Holder_Enemy_Active_Pool;

    protected override void Awake()
    {
        base.Awake();

        if (_instance != null) Debug.LogError("Only 1 EnemySpawner was allowed exist");

        _instance = this;
    }

    protected override void LoadComponents()
    {
        base.LoadComponents();

        this.LoadHolderDespawnPool();
    }

    protected virtual void LoadHolderDespawnPool()
    {
        if (this._Holder_Enemy_Active_Pool != null) return;

        this._Holder_Enemy_Active_Pool = transform.Find("Holder_Enemy_Active_Pool");
    }
}
