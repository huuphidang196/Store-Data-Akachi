using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ButtonAttackThrow : BaseButton
{
    protected override void OnClick()
    {
        base.OnClick();
        InputManager.Instance.PointerAttackThrowDown();

        PlayerCtrl.Instance.PlayerAttack.PerformAttackThrowShuriken();
    }


}
