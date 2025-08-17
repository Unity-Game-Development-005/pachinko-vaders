
using UnityEngine;


public class PlaneMovement : MonoBehaviour 
{

    public float missileBaseSpeed = 1f; //10f;

    private Vector2 missileBaseDirection;

    private float leftBoundary;

    private float rightBoundary;




    void Start()
    {
        Initialise();
    }


    void Update () 
	{
        GetPlayerInput();

		MoveMissileBase();
	}


    private void GetPlayerInput()
    {
        missileBaseDirection = Vector2.zero;

        if (Input.GetKey(KeyCode.X))
        {
            missileBaseDirection = Vector2.right;
        }


        if (Input.GetKey(KeyCode.Z))
        {
            missileBaseDirection = Vector2.left;
        }
    }


    private void Initialise()
    {
        leftBoundary = -0.745f;

        rightBoundary = 0.745f;
    }


    private void MoveMissileBase()
    {
        Vector2 baseBoundary = transform.position;

        if (transform.position.x > rightBoundary)
        {
            baseBoundary.x = rightBoundary;
        }

        else if (transform.position.x < leftBoundary)
        {
            baseBoundary.x = leftBoundary;
        }

        transform.position = baseBoundary;

        transform.Translate(missileBaseSpeed * Time.deltaTime * missileBaseDirection);
    }



} // end of class





















































