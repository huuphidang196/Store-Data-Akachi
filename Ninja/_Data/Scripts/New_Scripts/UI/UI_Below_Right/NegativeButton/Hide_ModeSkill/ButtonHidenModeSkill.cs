using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonHidenModeSkill : BaseButton
{
    protected override void OnClick()
    {
        base.OnClick();
        InputManager.Instance.PointerHidenModeSkillDown();
    }
}
