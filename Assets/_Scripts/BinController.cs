using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Water2DTool;
using DG.Tweening;
public class BinController : MonoBehaviour
{
    [SerializeField] private Transform bin;
    [SerializeField] private float binSequenceTime;
    [SerializeField] private AnimationCurve binSequenceCurve;
    [SerializeField] private Vector3 binFinalVector;
    [SerializeField] private bool triggered;
    private Sequence binSequence;
    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<PlatformerCharacter2D>())
        {
            triggered = true;
            binSequence = DOTween.Sequence();
            binSequence.Append(bin.DOLocalRotate(binFinalVector, binSequenceTime).SetEase(binSequenceCurve));
        }
    }
}
