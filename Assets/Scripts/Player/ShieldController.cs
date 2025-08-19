
using UnityEngine;


public class ShieldController : MonoBehaviour
{

    private int shieldStrength;

    private int shieldDamage;





    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Initialise();
    }





    public void DamageShields(int damage)
    {
        shieldStrength -= 10;
    }



    private void Initialise()
    {
        shieldStrength = 100;

        shieldDamage = 10;
    }



    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy Bullet"))
        {
            shieldStrength -= 10;

            if (shieldStrength <= 0)
            {
                DamageShields(shieldDamage);

                gameObject.SetActive(false);

                Destroy(collision.gameObject);
            }
        }
    }




} // end of class
