
using UnityEngine;



public class MissileBaseController3 : MonoBehaviour
{
    public Transform missileTransform3;

    public Rigidbody2D missileRigidbody3;

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
        GameController.gameController.canLaunch3 = false;

        // right missile base
        if (Input.GetKeyDown(KeyCode.M))
        {
            missileIndex = 3;

            ActivateMissile(missileIndex);
        }
    }


    private void ActivateMissile(int missileIndex)
    {
        GameController.gameController.canLaunch3 = true;

        missileTransform3.gameObject.SetActive(true);

        missileLaunchForce = launchPower * maximumLaunchForce;
    }


    private void LaunchMissile()
    {
        // if we have not launched the missile
        if (GameController.gameController.canLaunch3)
        {
            // then launch the missile
            missileRigidbody3.AddForce(Vector2.up * missileLaunchForce);

            missileLaunchForce = 0f;

            //canLaunch = false;
        }
    }


    private void Initialise()
    {
        missileBaseSpeed = 0.45f;

        missileIndex = 0;

        missileBaseDirection = Vector2.left;

        missileLaunchForce = 0f;

        maximumLaunchForce = 90f;

        launchPower = 1.2f;


        leftBoundary = transform.position.x - 1f;

        rightBoundary = transform.position.x + 1f;


        GameController.gameController.canLaunch3 = false;
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

        transform.Translate(missileBaseSpeed * Time.deltaTime * missileBaseDirection);
    }


} // end of class
