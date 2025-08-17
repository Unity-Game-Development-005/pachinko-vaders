
using UnityEngine;



public class DroneController : MonoBehaviour
{
    private float missileBaseSpeed;

    private Vector2 missileBaseDirection;

    private float leftBoundary;

    private float rightBoundary;


    public bool isBase1;

    public bool isBase3;





    void Start()
    {
        Initialise();
    }


    void Update()
    {
        MoveMissileBase();
    }


    private void Initialise()
    {
        if (isBase1)
        {
            missileBaseSpeed = 0.45f;

            leftBoundary = transform.position.x - 0.985f;

            rightBoundary = transform.position.x + 0.75f;
        }
        

        if (isBase3)
        {
            missileBaseSpeed = 0.35f;

            leftBoundary = transform.position.x - 0.75f;

            rightBoundary = transform.position.x + 0.985f;
        }


        missileBaseDirection = Vector2.left;
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
