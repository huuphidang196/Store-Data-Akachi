using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class HolderEnemyActivePool : SurMonoBehaviour
{
    protected override void ResetValue()
    {
        base.ResetValue();

        this.SortAllEnemyByPositionX();
    }

    protected virtual void SortAllEnemyByPositionX()
    {
        if (this.transform.childCount == 0) return;

        // Lấy danh sách các đối tượng con của holder
        var children = this.transform.Cast<Transform>().ToList();

        // Sắp xếp danh sách theo vị trí x
        children = children.OrderBy(child => child.position.x).ToList();

        // Cập nhật lại SiblingIndex cho các đối tượng
        for (int i = 0; i < children.Count; i++)
        {
            children[i].SetSiblingIndex(i);
            children[i].gameObject.SetActive(false);
        }
    }

    protected virtual void FixedUpdate()
    {
        if (GameController.Instance.PauseGame) return;

        if (this.transform.childCount == 0) return;

        this.ActiveAllEnemiesWithinTheScopeOfPlayer();
    }

    protected virtual void ActiveAllEnemiesWithinTheScopeOfPlayer()
    {
        foreach (Transform enemy in this.transform)
        {
            bool withinScope = this.CheckEnemyWithinScopePlayer(enemy);

            if (!withinScope) break;

            enemy.gameObject.SetActive(withinScope);
        }
    }

    protected virtual bool CheckEnemyWithinScopePlayer(Transform enemy)
    {
        float distanceX = Mathf.Abs(enemy.position.x - PlayerCtrl.Instance.transform.position.x);

        return distanceX <= GameController.Instance.Distance_Active_Enemies;
    }
}
