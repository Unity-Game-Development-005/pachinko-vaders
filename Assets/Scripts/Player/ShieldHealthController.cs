
using UnityEngine;
using UnityEngine.UI;


public class ShieldHealthController : MonoBehaviour
{
    //public Transform shield;

    public int shieldCurrentHealth;

    private int shieldMaximumHealth;


    private int shieldDamage;


    public Image healthBar;



    private void Start()
    {
        Initialise();
    }


    private void Initialise()
    {
        shieldCurrentHealth = 100;

        shieldMaximumHealth = 100;

        shieldDamage = 10;
    }



    // damage the shield
    public void DamageShield(int damageAmount)
    {
        // decrease the shield's strength by the 'damage' amount
        shieldCurrentHealth -= damageAmount;

        // update the shield's health bar
        healthBar.fillAmount = (float)shieldCurrentHealth / (float)shieldMaximumHealth;
    }



    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy Bullet"))
        {
            Debug.Log("shield hit");
            DamageShield(shieldDamage);

            // if the shield's strength is less than or equal to zero
            if (shieldCurrentHealth <= 0)
            {
                // deactivate the shield
                //gameObject.SetActive(false);
            }

            //Destroy(collision.gameObject);
        }
    }


} // end of class
