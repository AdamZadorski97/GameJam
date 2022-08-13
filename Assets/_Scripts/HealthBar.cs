using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    [SerializeField] private Image waterFill;
    [SerializeField] private Image BubblesFill;


    private void UpdateBar(float fillAmount)
    {
        waterFill.fillAmount = fillAmount;
        BubblesFill.fillAmount = fillAmount;
    }
}
