
using UnityEngine;
using UnityEngine.UI;

//
// Pachinko Vaders v2025.07.04
//
// v2025.08.21
//

public class ShieldController : MonoBehaviour
{

    [HideInInspector] public int currentShieldStrength;

    [HideInInspector] public int maximumShieldStrength;

    [HideInInspector] public int shieldDamage;


    public Image healthBar;





    private void DamageShields(int damage)
    {
        currentShieldStrength -= damage;


        // update the shield's health bar
        healthBar.fillAmount = (float)currentShieldStrength / (float)maximumShieldStrength;
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy Bullet"))
        {
            DamageShields(shieldDamage);

            if (currentShieldStrength <= 0)
            {
                gameObject.SetActive(false);

                Destroy(collision.gameObject);
            }
        }
    }


} // end of class
