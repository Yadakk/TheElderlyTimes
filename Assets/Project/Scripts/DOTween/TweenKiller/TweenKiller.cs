using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TweenKiller
{
    public static void KillAllTweens()
    {
        if (DOTween.TotalActiveTweens() > 0)
        {
            var pausedTweens = DOTween.PausedTweens();
            var playingTweens = DOTween.PlayingTweens();

            KillTweens(pausedTweens);
            KillTweens(playingTweens);
        }
    }

    private static void KillTweens(List<Tween> tweens)
    {
        if (tweens == null) return;
        for (int i = 0; i < tweens.Count; i++)
            tweens[i]?.Kill();
    }
}
