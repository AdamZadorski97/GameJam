using UnityEngine;
using Water2DTool;
using DG.Tweening;

public class DoorController : MonoBehaviour
{
    [SerializeField] private Transform door;
    [SerializeField] private float doorSequenceTime;
    [SerializeField] private AnimationCurve doorSequenceCurve;
    [SerializeField] private Vector3 doorStartVector;
    [SerializeField] private Vector3 doorFinalVector;
    [SerializeField] private float waitTime;
   private Sequence doorSequence;



    private void Start()
    {
        doorSequence = DOTween.Sequence();
        doorSequence.Append(door.DOLocalRotate(doorFinalVector, doorSequenceTime).SetEase(doorSequenceCurve));
        doorSequence.AppendInterval(waitTime);
        doorSequence.Append(door.DOLocalRotate(doorStartVector, doorSequenceTime).SetEase(doorSequenceCurve));
        doorSequence.AppendInterval(waitTime);
        doorSequence.SetLoops(-1);
    }
}
