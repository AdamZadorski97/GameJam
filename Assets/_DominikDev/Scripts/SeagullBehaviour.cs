using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using Water2DTool;
public class SeagullBehaviour : MonoBehaviour
{
    [SerializeField] Transform seagull;
    [SerializeField] Transform player;
    [SerializeField] Vector3 startPosition = new Vector3(0, 0, 0);
    [SerializeField] Animator animator;
    [SerializeField] int timeToMoveToStart = 5;
    private Sequence flySequence;
    private Sequence catchSequence;
    private Sequence flyAwaySequence;
    bool isFishVisible;
    bool isFishActive = false;
    bool isFishCatched = false;
    RaycastHit raycast;
    int completedLoops;
    int rotator;

    private void Start()
    {
        flySequence = DOTween.Sequence();
        catchSequence = DOTween.Sequence();
        flyAwaySequence = DOTween.Sequence();
        flySequence.Append(seagull.DOMoveX(-10, 3)).SetRelative().SetEase(Ease.Linear).SetLoops(-1, LoopType.Yoyo).OnStepComplete(Flip);
        //flySequence.Insert(0.5f, seagull.DOMoveY(-1, 1).SetRelative());
        //flySequence.Insert(2.5f, seagull.DOMoveY(1, 1).SetRelative());
        //StartCoroutine(WaitForFishInWater());
    }

    //IEnumerator WaitForFishInWater()
    //{
    //    yield return flySequence.WaitForElapsedLoops(4);
    //    flySequence.Kill();
    //}

    private void Update()
    {
        if (!isFishVisible)
        {
            if (Physics.Raycast(seagull.position, Vector3.down, out raycast))
            {
                if (raycast.transform.gameObject.GetComponent<PlatformerCharacter2D>())
                {
                    //flySequence.Kill();
                    flySequence.Pause();
                    seagull.DOMove(player.position, 1);
                    animator.SetTrigger("HountingStart");
                    //catchSequence = DOTween.Sequence();
                    //catchSequence.Append(seagull.DOMove(player.position, 1));
                    if (!isFishCatched)
                    {
                        flySequence.Play();
                        animator.SetTrigger("HountingStop");
                    }
                    isFishVisible = true;
                }
            }
        }
    }

    void Flip()
    {
        completedLoops++;
        if (completedLoops % 2 == 1) rotator = 1;
        else rotator = -1;
        seagull.DOScaleZ(-1 * rotator, 0.5f);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.GetComponent<PlatformerCharacter2D>())
        {
            isFishCatched = true;
            catchSequence = DOTween.Sequence();
            animator.SetTrigger("HountingStop");
            if (!isFishActive)
            {
                isFishActive = true;
                player.SetParent(seagull);
                player.GetComponent<Rigidbody>().useGravity = false;
                catchSequence.Append(seagull.DOMove(startPosition, timeToMoveToStart));
                catchSequence.AppendCallback(() => { player.SetParent(null); player.GetComponent<Rigidbody>().useGravity = true;  flyAwaySequence.Append(seagull.DOLocalMove(new Vector3(10, 10, 0), 3)); });
                //catchSequence.AppendInterval(3);
                //DOTween.KillAll();
            }
            //catchSequence.AppendCallback(() => { player.SetParent(null); player.GetComponent<Rigidbody>().gameObject.SetActive(true); flyAwaySequence.Append(seagull.DOLocalMove(new Vector3(10, 10, 0), 3)); });
        }
    }

    void ReleaseFish()
    {
        player.SetParent(player);
        player.GetComponent<Rigidbody>().gameObject.SetActive(true);
        flyAwaySequence.Append(seagull.DOLocalMove(new Vector3(10, 10, 0), 3));
    }
}
