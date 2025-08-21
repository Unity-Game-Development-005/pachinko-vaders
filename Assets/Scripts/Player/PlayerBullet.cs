
using UnityEngine;

//
// Pachinko Vaders v2025.07.04
//
// 2025.08.20
//

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


        if (target.CompareTag("Mystery Ship"))
        {
            GameController.gameController.MysteryShipPoints();

            target.gameObject.SetActive(false);

            Destroy(gameObject);
        }

        if (target.CompareTag("UFO"))
        {
            GameController.gameController.MysteryShipPoints();

            target.gameObject.SetActive(false);

            Destroy(gameObject);
        }

        if (target.CompareTag("Plane"))
        {
            GameController.gameController.MysteryShipPoints();

            target.gameObject.SetActive(false);

            Destroy(gameObject);
        }


        if (target.CompareTag("Enemy 1"))
        {
            GameController.gameController.UpdatePlayer1Score(GameController.gameController.enemy1Points);

            target.gameObject.SetActive(false);

            Destroy(gameObject);
        }


        if (target.CompareTag("Enemy 2"))
        {
            GameController.gameController.UpdatePlayer1Score(GameController.gameController.enemy2Points);

            target.gameObject.SetActive(false);

            Destroy(gameObject);
        }


        if (target.CompareTag("Enemy 3"))
        {
            GameController.gameController.UpdatePlayer1Score(GameController.gameController.enemy3Points);

            target.gameObject.SetActive(false);

            Destroy(gameObject);
        }
    }


} // end of class
