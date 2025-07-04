
using UnityEngine;



public class MissileBaseController1 : MonoBehaviour
{
    public Transform missileTransform1;

    public Rigidbody2D missileRigidbody1;

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
        GameController.gameController.canLaunch1 = false;

        // left missile base
        if (Input.GetKeyDown(KeyCode.Z))
        {
            missileIndex = 1;

            ActivateMissile(missileIndex);
        }
    }


    private void ActivateMissile(int missileIndex)
    {
        GameController.gameController.canLaunch1 = true;

        missileTransform1.gameObject.SetActive(true);

       missileLaunchForce = launchPower * maximumLaunchForce;
    }


    private void LaunchMissile()
    {
        // if we have not launched the missile
        //if (GameController.gameController.canLaunch1)
        //{
            // then launch the missile
            missileRigidbody1.AddForce(Vector2.up * missileLaunchForce);

            missileLaunchForce = 0f;

            //canLaunch = false;
        //}
    }


    private void Initialise()
    {
        missileBaseSpeed = 0.35f;

        missileIndex = 0;

        missileBaseDirection = Vector2.right;

        missileLaunchForce = 0f;

        maximumLaunchForce = 90f;

        launchPower = 4f;


        leftBoundary = transform.position.x - 1f;

        rightBoundary = transform.position.x + 1f;


        GameController.gameController.canLaunch1 = false;
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
