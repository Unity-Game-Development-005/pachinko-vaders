
using UnityEngine;

public class UfoController : MonoBehaviour
{
    public GameObject missilePrefab;


    public Rigidbody2D missileRigidbody;

    [SerializeField] private Transform missileLauncherTransform;


    [SerializeField] private Transform leftLaunchZone;

    [SerializeField] private Transform rightLaunchZone;

    [SerializeField] private Transform leftSpaceDock;

    [SerializeField] private Transform rightSpaceDock;


    private float ufoSpeed; // = 0.8f;

    private Vector2 ufoDirection; // = Vector2.right;


    private float missileLaunchForce;

    private float launchPower;

    private float maximumLaunchForce;

    [SerializeField] private bool canLaunch;

    private bool weaponActive;


    private float randomStartDelay; // = 1.0f;

    private float randomFireInterval; // = 4.0f;



    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Initialise();

        SelectRandomFireRate();
    }


    // Update is called once per frame
    void Update()
    {
        //CheckForMissileLaunch();

        MoveUfo();
    }


    private void CheckForMissileLaunch()
    {/*
        // if the ufo is between the left wand right walls
        if (transform.position.x < leftLaunchZone.position.x || transform.position.x > rightLaunchZone.position.x)
        {
            canLaunch = false;

            //weaponActive = false;

            // deactivate the missile
            //missileTransform.gameObject.SetActive(false);

            return;
        }

        //else
        //{
        //canLaunch = true;

        //missileTransform.gameObject.SetActive(true);

        //missileLaunchForce = launchPower * maximumLaunchForce;


        // }

        if (!weaponActive)
        {
            SelectRandomFireRate();
        }*/
    }


    private void FixedUpdate()
    {/*
        // if we have not launched the missile
        if (canLaunch)
        {
            // then launch the missile
            LaunchMissile();

            missileLaunchForce = 0f;

            canLaunch = false;
        }*/
    }


    private void SelectRandomFireRate()
    {
        Debug.Log("random fire");
        // if the ufo is between the left wand right walls
        if (transform.position.x > leftLaunchZone.position.x && transform.position.x < rightLaunchZone.position.x)
        {
            //return;


            //weaponActive = true;

            //missileTransform.gameObject.SetActive(true);

            // select a random fire time based on the start delay time
            float fireRate = Random.Range(randomStartDelay, randomStartDelay * randomFireInterval);
            Debug.Log("firerate: " + fireRate);

            // launch missile
            Invoke(nameof(SetLaunchPower), fireRate);

            // select another randop fire rate
            Invoke(nameof(SelectRandomFireRate), fireRate);
        }
    }


    private void SetLaunchPower()
    {
        Debug.Log("power");
        // if the ufo is between the left wand right walls
        if (transform.position.x > leftLaunchZone.position.x && transform.position.x < rightLaunchZone.position.x)
        {
            //return;
            //}

            //missileLaunchForce = launchPower * maximumLaunchForce;

            //canLaunch = true;

            // Generate random ball index and random spawn position
            //int randomBall = Random.Range(0, missilePrefab.Length);

            Vector3 missileLaunchPosition = new Vector3(0, 0, 0); // missileLauncherTransform.position.x, missileLauncherTransform.position.y, missileLauncherTransform.position.z); //new Vector3(Random.Range(spawnLimitXLeft, spawnLimitXRight), spawnPosY, 0);

            // instantiate ball at random spawn location
            Debug.Log("bombs away");
            Instantiate(missilePrefab, missileLaunchPosition, missilePrefab.transform.rotation);
        }
    }


    private void LaunchMissile()
    {
        //missileRigidbody.AddForce(Vector3.down * missileLaunchForce, ForceMode2D.Impulse);
    }


    private void Initialise()
    {
        ufoSpeed = 0.8f;

        ufoDirection = Vector2.right;

        missileLaunchForce = 0f;

        maximumLaunchForce = 90f;

        launchPower = 0.1f;

        randomStartDelay = 1.0f;

        randomFireInterval = 4.0f;

        weaponActive = false;

        canLaunch = false;
    }


    private void MoveUfo()
    {
        if (transform.position.x > rightSpaceDock.position.x)
        {
            ufoDirection = Vector2.left;
        }

        else if (transform.position.x < leftSpaceDock.position.x)
        {
            ufoDirection = Vector2.right;
        }

        transform.Translate(ufoSpeed * Time.deltaTime * ufoDirection);
    }


} // end of class
