using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Water2DTool;
public class HotTrigger : MonoBehaviour
{
    public float hotHealthSubstractMultipler;
    private void OnTriggerStay(Collider other)
    {

     if(other.GetComponent<FishController>())
        {
            other.GetComponent<FishController>().health -= Time.deltaTime * hotHealthSubstractMultipler;
        }
    }
}
