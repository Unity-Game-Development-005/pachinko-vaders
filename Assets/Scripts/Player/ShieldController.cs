
using UnityEngine;


public class ShieldController : MonoBehaviour
{

    private int shieldStrength;





    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Initialise();
    }





    public void DamageShields(string shield)
    {
        shieldStrength -= 10;
    }



    private void Initialise()
    {
        shieldStrength = 100;
    }



    private void OnCollisionEnter2D(Collision2D collision)
    {
        shieldStrength -= 10;

        if (shieldStrength <= 0)
        {
            collision.gameObject.SetActive(false);

            Destroy(gameObject);
        }
    }




} // end of class
