
using UnityEngine;
using System.Collections;


public class EnemyPlaneShoot : MonoBehaviour 
{

	[SerializeField] private GameObject bullet;

    [SerializeField] private Transform leftLaunchZone;

    [SerializeField] private Transform rightLaunchZone;




    void Start () 
	{
		StartCoroutine (Shoot (Random.Range(2.5f, 3.5f)));
	}


	IEnumerator Shoot(float time)
	{
		if (transform.position.x > leftLaunchZone.position.x && transform.position.x < rightLaunchZone.position.x)
		{
			yield return new WaitForSeconds(time);

			Instantiate(bullet, transform.position, Quaternion.identity);
		}

		else
		{
			yield return null;
		}

		StartCoroutine(Shoot(Random.Range(2.5f, 3.5f)));
	}


} // end of class
