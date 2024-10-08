using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIButtonLevelSpawner : UIScrollSpawner
{
    private static UIButtonLevelSpawner m_instance;
    public static UIButtonLevelSpawner Instance => m_instance;

    public static string NameButton = "Button_Level";

    protected override void Awake()
    {
        base.Awake();

        if (m_instance != null) Debug.LogError("Allow only UIButtonLevelSpawner has been exist");

        m_instance = this;
    }
}
