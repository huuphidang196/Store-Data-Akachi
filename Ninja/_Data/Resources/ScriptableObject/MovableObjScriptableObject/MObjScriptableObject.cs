using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "MObjScriptableObject", menuName = "ScriptableObject/MovableObjScriptableObject")]
public class MObjScriptableObject : ScriptableObject
{
    [Header("MObjScriptableObject")]
    public float Speed_Move_Horizontal;
    public float Max_HP = 1f;
}

[CreateAssetMenu(fileName = "CharacterScriptableObject", menuName = "ScriptableObject/MovableObjScriptableObject/CharacterScriptableObject")]
public class CharacterScriptableObject : MObjScriptableObject
{
    [Header("CharacterScriptableObject")]

    public float Length_Ray_Forward_Limit;
    public float Speed_Dash_Horizontal;
}

[CreateAssetMenu(fileName = "PlayerSO", menuName = "ScriptableObject/MovableObjScriptableObject/CharacterScriptableObject/PlayerSO")]
public class PlayerSO : CharacterScriptableObject
{
    [Header("PlayerSO")]

    public float Time_Delay_Hiden = 5f;
    public float JumpingPower = 17f;
    public float WallSlidingSpeed = 3f;
    public float WallJumpingTime = 0.2f;
    public float WallJumpingDuration = 0.4f;
    public float DashingPower = 35f;
    public float DashingTime = 0.3f;
    public float Speed_Hiding_Horizontal = 1.5f;
    public float Radius_Check = 0.1f;

}

[CreateAssetMenu(fileName = "EnemySO", menuName = "ScriptableObject/MovableObjScriptableObject/CharacterScriptableObject/EnemySO")]
public class EnemySO : CharacterScriptableObject
{
    [Header("EnemySO")]

    public float Time_Delay_Attack = 1.5f;
    public float Distance_Change_Dir_Enemy = 0.5f;
    public float Distance_Attack_Player = 0.3f;
    public float DetectionRange = 5f;
    public float FieldOfViewAngle = 180f;
}

[CreateAssetMenu(fileName = "WeaponSO", menuName = "ScriptableObject/MovableObjScriptableObject/WeaponSO")]
public class WeaponSO : MObjScriptableObject
{
    [Header("WeaponSO")]

    public float Time_Delay_Disable = 0.5f;
    public float Damage_Send = 9999f;
}
