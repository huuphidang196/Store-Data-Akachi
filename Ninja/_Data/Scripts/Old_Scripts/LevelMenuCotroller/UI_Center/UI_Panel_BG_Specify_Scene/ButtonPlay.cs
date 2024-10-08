using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonPlay : BaseButton
{
    protected override void OnClick()
    {
        base.OnClick();

        LevelMenuController levelMenuController = LevelMenuController.Instance as LevelMenuController;

        string nameScene = levelMenuController.GetNameSceneCurrent();

        SceneManager.LoadScene(nameScene);
    }
}
