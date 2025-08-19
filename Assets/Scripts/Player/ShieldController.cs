
using UnityEngine;
using UnityEngine.UI;


public class ShieldController : MonoBehaviour
{

    private int currentShieldStrength;

    private int maximumShieldStrength;

    private int shieldDamage;


    public Image healthBar;





    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Initialise();
    }


    private void Initialise()
    {
        currentShieldStrength = 100;

        maximumShieldStrength = 100;

        shieldDamage = 10;
    }


    public void DamageShields(int damage)
    {
        currentShieldStrength -= 10;


        // update the shield's health bar
        healthBar.fillAmount = (float)currentShieldStrength / (float)maximumShieldStrength;
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy Bullet"))
        {
            //shieldStrength -= 10;
            DamageShields(shieldDamage);

            if (currentShieldStrength <= 0)
            {
                gameObject.SetActive(false);

                Destroy(collision.gameObject);
            }
        }
    }




} // end of class
