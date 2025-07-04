
using UnityEngine;



public class MissileBaseController2 : MonoBehaviour
{
    public Transform missileTransform2;

    public Rigidbody2D missileRigidbody2;

    //[SerializeField] private int missileBaseIndex;

    private int missileIndex;

    private float missileBaseSpeed;

    public Vector2 missileBaseDirection;

    public float missileLaunchForce;

    public float launchPower;

    public float maximumLaunchForce;

    private float leftBoundary;

    private float rightBoundary;



    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Initialise();
    }


    // Update is called once per frame
    void Update()
    {
        GetPlayerInput();

        MoveMissileBase();
    }


    private void FixedUpdate()
    {
        LaunchMissile();
    }


    private void GetPlayerInput()
    {
        GameController.gameController.canLaunch2 = false;

        // middle missile base
        if (Input.GetKeyDown(KeyCode.V))
        {
            missileIndex = 2;

            ActivateMissile(missileIndex);
        }
    }


    private void ActivateMissile(int missileIndex)
    {
        GameController.gameController.canLaunch2 = true;

        missileTransform2.gameObject.SetActive(true);

        missileLaunchForce = launchPower * maximumLaunchForce;
    }


    private void LaunchMissile()
    {
        // if we have not launched the missile
        if (GameController.gameController.canLaunch2)
        {
            // then launch the missile
            missileRigidbody2.AddForce(Vector2.up * missileLaunchForce);

            missileLaunchForce = 0f;

            //canLaunch = false;
        }
    }


    private void Initialise()
    {
        missileBaseSpeed = 0f;

        missileIndex = 0;

        missileBaseDirection = Vector2.right;

        missileLaunchForce = 0f;

        maximumLaunchForce = 90f;

        launchPower = 1.2f;


        leftBoundary = transform.position.x - 1f;

        rightBoundary = transform.position.x + 1f;


        GameController.gameController.canLaunch2 = false;
    }


    private void MoveMissileBase()
    {
        if (transform.position.x > rightBoundary)
        {
            missileBaseDirection = Vector2.left;
        }

        else if (transform.position.x < leftBoundary)
        {
            missileBaseDirection = Vector2.right;
        }

        //transform.Translate(missileBaseSpeed * Time.deltaTime * missileBaseDirection);
    }


} // end of class
