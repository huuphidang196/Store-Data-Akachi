using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonLoadLevel : BaseButton
{
    protected override void OnClick()
    {
        base.OnClick();

        LevelMenuController.Instance.ClickSelectScenePlayByLevel(transform.parent);

     //   Debug.Log(transform.parent.name);
    }
}
