using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BaseImage : SurMonoBehaviour
{
    [SerializeField] protected Image _BaseImage;

    protected override void LoadComponents()
    {
        base.LoadComponents();

        this.LoadBaseImage();
    }

    protected virtual void LoadBaseImage()
    {
        if (this._BaseImage != null) return;

        this._BaseImage = GetComponent<Image>();
    }


}
