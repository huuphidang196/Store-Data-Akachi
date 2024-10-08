using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCheckForward : CharacterCheckForward
{

    protected override void LoadLayerMaskForward()
    {
        if (this._ObjForwardLayer.Length > 0) return;
        //this._ObjForwardLayer = new LayerMask[1];
        //this._ObjForwardLayer[0] = 1 << LayerMask.NameToLayer("Ground");
        this._ObjForwardLayer = new string[1];
        this._ObjForwardLayer[0] = "Ground";
    }

}
