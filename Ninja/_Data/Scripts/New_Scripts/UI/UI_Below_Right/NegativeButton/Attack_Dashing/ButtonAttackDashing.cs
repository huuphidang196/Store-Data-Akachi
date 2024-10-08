using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonAttackDashing : BaseButton
{
    protected override void OnClick()
    {
        base.OnClick();
       // Debug.Log("Press Dashing");
        InputManager.Instance.PointerAttackDashingDown();

    }


}
