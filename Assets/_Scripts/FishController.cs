using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Water2DTool
{
    public class FishController : MonoBehaviour
    {
        [SerializeField] private PlatformerCharacter2D platformerCharacter2D;
        [SerializeField] private HealthBar healthBar;

        [SerializeField] public float health;
        [SerializeField] private float healthAddSpeed;
        [SerializeField] private float healthSubstractSpeed;
        private void Update()
        {
            UpdateHealth();
        }

        private void UpdateHealth()
        {
            if (!platformerCharacter2D.m_Watered && health>0)
            {
               // health -= Time.deltaTime * healthSubstractSpeed;
            }
            else if (platformerCharacter2D.m_Watered && health < 1)
            {
                health += Time.deltaTime * healthAddSpeed;
            }
            healthBar.UpdateBar(health);
        }
    }
}
