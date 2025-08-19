
using UnityEngine;


public class EnemyBullet : MonoBehaviour 
{

	private float force = -0.01f; // -20f;
	


	void Start () 
	{
		GetComponent<Rigidbody2D> ().linearVelocity = new Vector2 (0, force);	
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

            Destroy(gameObject);
        }


        if (target.CompareTag("City"))
        {
            target.gameObject.SetActive(false);

            Destroy(gameObject);
        }	
	}


} // end of class
