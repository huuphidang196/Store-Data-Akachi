using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ScrollAutoRun : SurMonoBehaviour
{
    [SerializeField] protected ScrollRect _ScrollRect;

    protected override void LoadComponents()
    {
        base.LoadComponents();

        this.LoadScrollRect();
    }

    protected virtual void LoadScrollRect()
    {
        if (this._ScrollRect != null) return;

        this._ScrollRect = GetComponent<ScrollRect>();
    }

    protected override void Start()
    {
        base.Start();

        this.RunAutoToMaxButtonLevel();
    }

    protected virtual void RunAutoToMaxButtonLevel()
    {
        int maxUnlockedLevel = GameController.Instance.SystemConfig.Level_Unlock;

        float currentLevelPos = (float)maxUnlockedLevel / 16;

        StartCoroutine(this.AutoScroll(0, currentLevelPos, 1f));
    }

    protected IEnumerator AutoScroll(float startPosition, float endPosition, float duration)
    {
        yield return new WaitForSeconds(0.5f);
        float t0 = 0.0f;
        while (t0 < 1.0f)
        {
            if (t0 <= 0.8f)
            {
                t0 += Time.deltaTime / duration;
            }
            else
            {
                t0 += Time.deltaTime / (3.5f * duration);
            }

            this._ScrollRect.horizontalNormalizedPosition = Mathf.Lerp(startPosition, endPosition, t0);
            this._ScrollRect.verticalNormalizedPosition = Mathf.Lerp(startPosition, endPosition, t0);
            yield return null;
        }

    }
}
