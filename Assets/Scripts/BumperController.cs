
using UnityEngine;

public class BumperController : MonoBehaviour
{
    private float bumperMovementSpeed;

    private Vector2 bumperDirection;

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
        MoveBumpers();
    }


    private void Initialise()
    {
        bumperMovementSpeed = 0.25f;

        bumperDirection = Vector2.right;

        leftBoundary = -1f;

        rightBoundary = 1f;
    }


    private void MoveBumpers()
    {
        if (transform.position.x > rightBoundary)
        {
            bumperDirection = Vector2.left;
        }

        else if (transform.position.x < leftBoundary)
        {
            bumperDirection = Vector2.right;
        }

        transform.Translate(bumperMovementSpeed * Time.deltaTime * bumperDirection);
    }


} // end of class
