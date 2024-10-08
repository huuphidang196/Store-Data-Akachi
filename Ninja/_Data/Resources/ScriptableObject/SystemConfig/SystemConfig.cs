using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "SystemConfig", menuName = "ScriptableObject/Configuration/SystemConfig", order = 0)]
public class SystemConfig : ScriptableObject
{
    public int Level_Unlock;
    public int Current_Level;
    public int Total_Gold;
    public int Total_Diamond;
}

[CreateAssetMenu(fileName = "GameConfigController", menuName = "ScriptableObject/Configuration/GameConfigController", order = 1)]
public class GameConfigController : SystemConfig
{
    public float Distance_Active_Enemies;
}
