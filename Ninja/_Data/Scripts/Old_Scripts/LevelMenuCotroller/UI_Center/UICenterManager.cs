using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UICenterManager : SurMonoBehaviour
{
     
    protected override void Start()
    {
        base.Start();

        this.SpawnAllButtonLevel();
    }

    protected virtual void SpawnAllButtonLevel()
    {
        int maxCount = SystemController.CountScene;

        for (int i = 0; i < maxCount; i++)
        {
            Transform btnLevel = UIButtonLevelSpawner.Instance.Spawn(UIButtonLevelSpawner.NameButton, Vector3.zero, Quaternion.identity);

            btnLevel.name = UIButtonLevelSpawner.NameButton + "_" + (i + 1).ToString("D2");

            btnLevel.localScale = Vector3.one;

            btnLevel.gameObject.SetActive(true);

        }
    }
}
