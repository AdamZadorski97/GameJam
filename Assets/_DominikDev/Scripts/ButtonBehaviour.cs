using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using DG.Tweening;

public class ButtonBehaviour : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{

    private Sequence enterSequence;
    private Sequence exitSequence;

    public void OnPointerEnter(PointerEventData eventData)
    {
        enterSequence = DOTween.Sequence();
        exitSequence.Kill();
        enterSequence.Append( transform.DOScale(2, 2).SetLoops(-1, LoopType.Yoyo).SetEase(Ease.Linear));
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        enterSequence.Kill();
        exitSequence.Append(transform.DOScale(1, 0.5f));
    }
}
