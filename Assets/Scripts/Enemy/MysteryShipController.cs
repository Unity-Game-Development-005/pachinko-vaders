
using System.Collections;
using UnityEngine;


public class MysteryShipController : MonoBehaviour
{

    [SerializeField] private GameObject bullet;

    [SerializeField] private Transform leftLaunchZone;

    [SerializeField] private Transform rightLaunchZone;

    [SerializeField] private Transform leftSpaceDock;

    [SerializeField] private Transform rightSpaceDock;


    private float mysteryShipSpeed;

    private Vector2 mysteryShipDirection;




    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        InitialiseMysteryShip();

        StartCoroutine(Shoot(Random.Range(2.5f, 3.5f)));
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


    IEnumerator Shoot(float time)
    {
        if (transform.position.x > leftLaunchZone.position.x && transform.position.x < rightLaunchZone.position.x)
        {
            yield return new WaitForSeconds(time);

            Instantiate(bullet, transform.position, Quaternion.identity);
        }

        else
        {
            yield return null;
        }

        StartCoroutine(Shoot(Random.Range(2.5f, 3.5f)));
    }


} // end of class
