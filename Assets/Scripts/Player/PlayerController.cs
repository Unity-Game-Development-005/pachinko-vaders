
using UnityEngine;


public class PlayerController : MonoBehaviour 
{
    public static PlayerController player;


    private float playerBaseSpeed;

    private Vector2 playerBaseDirection;

    private float playerLeftBoundary;

    private float playerRightBoundary;




    private void Awake()
    {
        player = this;
    }


    void Start()
    {
        //Initialise();
    }


    void Update () 
	{
        GetPlayerInput();

		MovePlayerBase();
    }


    private void GetPlayerInput()
    {
        playerBaseDirection = Vector2.zero;

        // move left
        if (Input.GetKey(KeyCode.Z))
        {
            playerBaseDirection = Vector2.left;
        }

        // move right
        if (Input.GetKey(KeyCode.X))
        {
            playerBaseDirection = Vector2.right;
        }
    }


    public void Initialise()
    {
        // player
        playerLeftBoundary = -1f;

        playerRightBoundary = 1f;

        playerBaseSpeed = 1f;

        GameController.gameController.ActivateMissileSilos();

        LivesController.livesController.UpdateLives(GameController.gameController.player1Lives);
    }


    private void MovePlayerBase()
    {
        Vector2 baseBoundary = transform.position;

        if (transform.position.x > playerRightBoundary)
        {
            baseBoundary.x = playerRightBoundary;
        }

        else if (transform.position.x < playerLeftBoundary)
        {
            baseBoundary.x = playerLeftBoundary;
        }

        transform.position = baseBoundary;

        transform.Translate(playerBaseSpeed * Time.deltaTime * playerBaseDirection);
    }


} // end of class
