using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollowTarget : FollowPlayerTarget
{
    private static CameraFollowTarget _instance;
    public static CameraFollowTarget Instance => _instance;

    protected override void Awake()
    {
        base.Awake();

        if (_instance != null) Debug.LogError("Only CameraFollowTarget was allowed existed");

        _instance = this;
    }
}
