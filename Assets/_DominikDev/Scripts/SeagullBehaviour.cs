using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using Water2DTool;
public class SeagullBehaviour : MonoBehaviour
{
    [SerializeField] Transform seagull;
    //[SerializeField] Vector3 player;
    [SerializeField] Transform player;
    [SerializeField] Vector3 startPosition = new Vector3(0, 0, 0);
    private Sequence flySequence;
    private Sequence catchSequence;
    bool isFishVisible;
    RaycastHit raycast;

    private void Start()
    {
        flySequence = DOTween.Sequence();
        catchSequence = DOTween.Sequence();
        flySequence.Append(seagull.DOMoveX(-10, 3)).SetRelative().SetEase(Ease.Linear).SetLoops(-1, LoopType.Yoyo);
        //sequence.Join(seagull.DOLookAt(player, 3));
        flySequence.Insert(0.5f, seagull.DOMoveY(-1, 1).SetRelative());
        flySequence.Insert(2.5f, seagull.DOMoveY(1, 1).SetRelative());
        StartCoroutine(WaitForFishInWater());
    }

    IEnumerator WaitForFishInWater()
    {
        yield return flySequence.WaitForElapsedLoops(4);
        flySequence.Kill();
    }

    private void Update()
    {
        if(!isFishVisible)
        {
            if (Physics.Raycast(seagull.position, Vector3.down, out raycast))
            {
                if (raycast.transform.gameObject.GetComponent<PlatformerCharacter2D>())
                {
                    flySequence.Kill();
                    seagull.DOMove(player.position, 1);
                    isFishVisible = true;
                }
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.GetComponent<PlatformerCharacter2D>())
        {
            player.SetParent(seagull);
            player.GetComponent<Rigidbody>().gameObject.SetActive(false);
            catchSequence.Append(seagull.DOLocalMove(startPosition, 3));
        }
    }

    void ReleaseFish()
    {
        player.GetComponent<Rigidbody>().gameObject.SetActive(true);
    }
}
