using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : SystemController
{
    private static GameController m_instance;
    public static GameController Instance => m_instance;

    public GameConfigController GameConfigController => this._SystemConfig as GameConfigController;

    [Header("GameController")]

    [SerializeField] protected bool _PauseGame;
    public bool PauseGame => _PauseGame;

    [SerializeField] protected float _Distance_Active_Enemies;
    public float Distance_Active_Enemies => this._Distance_Active_Enemies;

    protected override void Awake()
    {
        base.Awake();

        if (m_instance != null) Debug.LogError("Allow only GameController has been exist");

        m_instance = this;
    }

    protected override void ResetValue()
    {
        base.ResetValue();

        this._Distance_Active_Enemies = this.GameConfigController.Distance_Active_Enemies;
    }

    protected override string GetNameConfig()
    {
        return "GameConfigController";
    }
}
