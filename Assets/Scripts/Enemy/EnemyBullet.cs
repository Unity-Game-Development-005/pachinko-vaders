
using UnityEngine;


public class EnemyBullet : MonoBehaviour 
{

    private float force;
	


	void Start () 
	{
        Initialise();

		GetComponent<Rigidbody2D> ().linearVelocity = new Vector2 (0, force);	
	}


    private void Initialise()
    {
        force = -0.01f;
    }
	

	void OnTriggerEnter2D(Collider2D target) 
	{

        if (target.CompareTag("Ground"))
        {
            Destroy(gameObject);
        }


        if (target.CompareTag("Missile Base"))
        {
            target.gameObject.SetActive(false);

            GameController.gameController.MissileBaseDestroyed();

            //GameController.gameController.DeactivateMissileSilos();

            Destroy(gameObject);
        }


        if (target.CompareTag("City"))
        {
            GameController.gameController.CityDestroyed();

            target.gameObject.SetActive(false);

            Destroy(gameObject);
        }	
	}


} // end of class
