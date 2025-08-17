
using UnityEditor.Experimental.GraphView;
using UnityEngine;


public class MysteryShipController : MonoBehaviour
{

    [SerializeField] private Transform leftSpaceDock;

    [SerializeField] private Transform rightSpaceDock;


    private float mysteryShipSpeed;

    private Vector2 mysteryShipDirection;




    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        InitialiseMysteryShip();
    }


    // Update is called once per frame
    void Update()
    {
        MoveMysteryShip();
    }


    private void InitialiseMysteryShip()
    {
        mysteryShipSpeed = 0.8f;

        mysteryShipDirection = Vector2.right;
    }


    private void MoveMysteryShip()
    {
        if (transform.position.x > rightSpaceDock.position.x)
        {
            mysteryShipDirection = Vector2.left;
        }

        else if (transform.position.x < leftSpaceDock.position.x)
        {
            mysteryShipDirection = Vector2.right;
        }

        transform.Translate(mysteryShipSpeed * Time.deltaTime * mysteryShipDirection);
    }


} // end of class
