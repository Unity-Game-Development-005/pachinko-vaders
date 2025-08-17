
using UnityEngine;
using System.Collections;


public class PlaneShoot : MonoBehaviour 
{

	[SerializeField] private GameObject bullet;

	private bool canShoot;


	public bool isBase1;

    public bool isBase2;

    public bool isBase3;



    void Start() 
	{
		canShoot = true;
	}


	void Update () 
	{
		GetPlayerInput();
	}


	private void GetPlayerInput()
	{
		if (isBase1)
		{
            if (Input.GetKeyDown(KeyCode.B))
            {
                if (canShoot)
                {
                    StartCoroutine(Shoot());
                }
            }
        }


        if (isBase2)
		{
            if (Input.GetKeyDown(KeyCode.N))
            {
                if (canShoot)
                {
                    StartCoroutine(Shoot());
                }
            }
        }


        if (isBase3)
		{
            if (Input.GetKeyDown(KeyCode.M))
            {
                if (canShoot)
                {
                    StartCoroutine(Shoot());
                }
            }
        }
    }


    IEnumerator Shoot() 
	{
		canShoot = false;

		Vector3 temp = transform.position;

		temp.y += 0.5f;

		Instantiate(bullet, temp, Quaternion.identity);

		yield return new WaitForSeconds(.4f);

		canShoot = true;
	}


} // end of class









































