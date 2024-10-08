using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjDamSenderInfinity : ObjDamageSender
{
    protected override float GetDamageObjectToSend()
    {
        return 9999f;
    }
}
