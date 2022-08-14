using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Water2DTool;
public class AwningController : MonoBehaviour
{
    public float jumpForce;

    private void OnTriggerEnter(Collider other)
    {
        if(other.GetComponent<PlatformerCharacter2D>())
        {
            other.GetComponent<PlatformerCharacter2D>().m_Rigidbody.velocity = new Vector3(other.GetComponent<PlatformerCharacter2D>().m_Rigidbody.velocity.x, jumpForce, 0);
        }
    }
}
