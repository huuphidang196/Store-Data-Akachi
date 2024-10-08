using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAbstract : CharacterAbstract
{
    public EnemyCtrl EnemyCtrl => this._CharacterCtrl as EnemyCtrl;
}
