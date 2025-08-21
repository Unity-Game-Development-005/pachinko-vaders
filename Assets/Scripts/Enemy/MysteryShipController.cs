
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//
// Pachinko Vaders v2025.07.04
//
// v2025.08.21
//

public class MysteryShipController : MonoBehaviour
{

    public Transform[] mysteryShips;

    [SerializeField] private GameObject bullet;

    [SerializeField] private Transform leftLaunchZone;

    [SerializeField] private Transform rightLaunchZone;

    [SerializeField] private Transform leftSpaceDock;

    [SerializeField] private Transform rightSpaceDock;

    [SerializeField] private SpriteRenderer spriteRenderer;


    private float mysteryShipSpeed;

    private Vector2 mysteryShipDirection;

    private float lastSpriteDirection;




    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        StartUp();
    }


    // Update is called once per frame
    void Update()
    {
        MoveMysteryShip();
    }


    private void StartUp()
    {
        InitialiseMysteryShip();

        StartCoroutine(Shoot(Random.Range(2.5f, 3.5f)));
    }


    private void InitialiseMysteryShip()
    {
        ChooseRandomMysteryShip();

        mysteryShipSpeed = 0.8f;

        mysteryShipDirection = Vector2.right;
    }


    private void MoveMysteryShip()
    {
        if (transform.position.x > rightSpaceDock.position.x)
        {
            ChooseRandomMysteryShip();

            mysteryShipDirection = Vector2.left;
        }

        else if (transform.position.x < leftSpaceDock.position.x)
        {
            ChooseRandomMysteryShip();

            mysteryShipDirection = Vector2.right;
        }

        transform.Translate(mysteryShipSpeed * Time.deltaTime * mysteryShipDirection);
    }


    private void ChooseRandomMysteryShip()
    {
        for (int i = 0; i < mysteryShips.Length; i++)
        {
            mysteryShips[i].gameObject.SetActive(false);
        }

        int randomShip = Random.Range(0, mysteryShips.Length);

        mysteryShips[randomShip].gameObject.SetActive(true);

        if (randomShip == 1)
        {
            FlipSprite();
        }
    }


    private void FlipSprite()
    {
        // moving right
        if (mysteryShips[1].position.x > lastSpriteDirection)
        {
            spriteRenderer.flipX = false;
        }

        // moving left
        else if (mysteryShips[1].position.x < lastSpriteDirection)
        {
            spriteRenderer.flipX = true;
        }

        lastSpriteDirection = mysteryShips[1].position.x;
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
