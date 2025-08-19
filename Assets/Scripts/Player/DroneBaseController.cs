
using UnityEngine;



public class DroneBaseController : MonoBehaviour
{
    private float droneBaseSpeed;

    private Vector2 droneBaseDirection;

    private float droneLeftBoundary;

    private float droneRightBoundary;


    public bool isDroneBase1;

    public bool isDroneBase3;





    void Start()
    {
        Initialise();
    }


    void Update()
    {
        MoveDroneBase();
    }


    private void Initialise()
    {
        if (isDroneBase1)
        {
            droneBaseSpeed = 0.45f;

            droneLeftBoundary = -9f;

            droneRightBoundary = -7f;

            droneBaseDirection = Vector2.right;
        }
        

        if (isDroneBase3)
        {
            droneBaseSpeed = 0.35f;

            droneLeftBoundary = 7f;

            droneRightBoundary = 9f;

            droneBaseDirection = Vector2.left;
        }
    }


    private void MoveDroneBase()
    {
        if (transform.position.x > droneRightBoundary)
        {
            droneBaseDirection = Vector2.left;
        }

        else if (transform.position.x < droneLeftBoundary)
        {
            droneBaseDirection = Vector2.right;
        }

        transform.Translate(droneBaseSpeed * Time.deltaTime * droneBaseDirection);
    }


} // end of class
