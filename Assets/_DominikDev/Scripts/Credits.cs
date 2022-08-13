using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;

public class Credits : MonoBehaviour
{
    [SerializeField] Text programming;
    [SerializeField] Text graphics;
    private void Start()
    {
        programming.DOText("Programming:", 2, true, ScrambleMode.All).SetEase(Ease.Linear).SetAutoKill(false).Pause();
        graphics.DOText("Graphics:", 2, true, ScrambleMode.All).SetEase(Ease.Linear).SetAutoKill(false).Pause();
        DOTween.PlayAll();
    }
}
