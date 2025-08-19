
using UnityEngine;
using System.Collections;


public class MissileLauncherController : MonoBehaviour 
{

	[SerializeField] private GameObject bullet;


    public Transform[] missiles;

    [HideInInspector] public int missileCount;

    private bool outOfMissiles;


	private bool canShoot;


	public bool isBase1;

    public bool isBase2;

    public bool isBase3;




    void Start() 
	{
        Initialise();
	}


	void Update () 
	{
		GetPlayerInput();
	}


    private void Initialise()
    {
        missileCount = 10;

        ReloadMissiles(true);

        outOfMissiles = false;

        canShoot = true;
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
        if (!outOfMissiles)
        {
            canShoot = false;

            Vector3 temp = transform.position;

            temp.y += 0.5f;

            LaunchMissile();

            Instantiate(bullet, temp, Quaternion.identity);

            yield return new WaitForSeconds(.4f);

            canShoot = true;
        }
	}


    public void LaunchMissile()
    {
        missileCount -= 1;

        if (missileCount >= 0)
        {
            missiles[missiles.Length - (missileCount + 1)].gameObject.SetActive(false);
        }

        if (missileCount - 1 < 0)
        {
            outOfMissiles = true;

            return;
        }
    }


    public void ReloadMissiles(bool reload)
    {
        for (int i = 0; i < missiles.Length; i++)
        {
            missiles[i].gameObject.SetActive(reload);
        }
    }


} // end of class
