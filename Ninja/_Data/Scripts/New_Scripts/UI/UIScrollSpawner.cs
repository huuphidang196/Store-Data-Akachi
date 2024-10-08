using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class UIScrollSpawner : Spawner
{
    protected override void LoadHolder()
    {
        if (this._holder != null) return;

        this._holder = this.transform.Find("Scroll View").Find("Viewport").Find("Content");
    }
}
