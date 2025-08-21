
using System.Collections;
using UnityEngine;
using TMPro;

//
// Pachinko Vaders v2025.07.04
//
// 2025.08.21
//

public class MissileLauncherController : MonoBehaviour 
{
    [SerializeField] private TMP_Text missileCountLow;

    [SerializeField] private TMP_Text missileCountOut;



    [SerializeField] private GameObject bullet;


    public Transform[] missiles;

    [HideInInspector] public int missileCount;

    private bool outOfMissiles;


	private bool canShoot;


	public bool isBase1;

    public bool isBase2;

    public bool isBase3;


    private const int MINIMUM_MISSILE_COUNT = 3;




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
        if (!GameController.gameController.gameOver)
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
            if (missileCount <= MINIMUM_MISSILE_COUNT)
            {
                missileCountLow.gameObject.SetActive(true);
            }

            missiles[missiles.Length - (missileCount + 1)].gameObject.SetActive(false);
        }

        if (missileCount - 1 < 0)
        {
            outOfMissiles = true;

            missileCountLow.gameObject.SetActive(false);

            missileCountOut.gameObject.SetActive(true);

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
