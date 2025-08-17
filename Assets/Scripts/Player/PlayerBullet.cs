
using UnityEngine;
using static UnityEngine.GraphicsBuffer;


public class PlayerBullet : MonoBehaviour 
{

	private float force = 8f; //20f;
	



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

        if (target.CompareTag("Top Wall"))
        {
            Destroy(gameObject);
        }


        if (target.CompareTag("Enemy"))
        {
            target.gameObject.SetActive(false);

            Destroy(gameObject);
        }
    }


} // end of class
