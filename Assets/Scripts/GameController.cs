
using System.Collections;
using UnityEngine;
using TMPro;

//
// Pachinko Vaders v2025.07.04
//
// 2025.08.18
//

public class GameController : MonoBehaviour
{
    public static GameController gameController;


    public TMP_Text player1ScoreValue;

    public TMP_Text highScoreValue;





    [HideInInspector] public int player1Lives;

    [HideInInspector] public int player1Cities;

    private int player1Score;

    private int highScore;


    [HideInInspector] public int mysteryShipPoints;

    [HideInInspector] public int enemy1Points;

    [HideInInspector] public int enemy2Points;

    [HideInInspector] public int enemy3Points;

    [HideInInspector] public bool canPlay;

    [HideInInspector] public bool gameOver;







    private void Awake()
    {
        if (gameController == null)
        {
            gameController = this;
        }

        else if (gameController != this)
        {
            Destroy(this);
        }
    }


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        StartUp();

        Initialise();
    }


    // Update is called once per frame
    void Update()
    {
        GameLoop();
    }


    private void StartUp()
    {
        canPlay = false;

        gameOver = true;

        ///Player1Controller.player1.periscopeReticle.gameObject.SetActive(false);

        ///Player1Controller.player1.ReloadAmmo(false);

        player1Score = 0;

        player1Lives = 0;

        player1Cities = 0;

        highScore = 0;

        mysteryShipPoints = 0;

        enemy1Points = 0;

        enemy2Points = 0;

        enemy3Points = 0;

        ///ScoreController.scoreController.InitialiseScores();

        ///gameOverText.gameObject.SetActive(true);
    }





    private void Initialise()
    {
        player1Score = 0;

        player1Lives = 3;

        player1Cities = 6;

        enemy1Points = 50;

        enemy2Points = 30;

        enemy3Points = 10;

        ///ScoreController.scoreController.InitialiseScores();

        ///Player1Controller.player1.Initialise();

        ///gameOverText.gameObject.SetActive(false);

        StartCoroutine(StartDelay());
    }


    private IEnumerator StartDelay()
    {
        yield return new WaitForSeconds(1f);

        gameOver = false;

        canPlay = true;
    }


    private void GameLoop()
    {
        if (gameOver)
        {
                ///canPlay = false;

                ///gameOver = true;

                ///gameOverText.gameObject.SetActive(true);
        ///}

        ///else
        ///{
            ///UpdateHighScore();

            KeyboardController();
        }
    }


    private void KeyboardController()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            StartOnePlayer();
        }
    }


    private void StartOnePlayer()
    {
        Initialise();
    }


    public void PlayerDestroyed()
    {
        ///PlayerController.player.playerShip.gameObject.SetActive(false);

        ///UpdatePlayer1Lives();
    }


    public void MysteryShipPoints()
    {
        float mysteryPointsChoice = Random.Range(1f, 4f);

        switch ((int)mysteryPointsChoice)
        {
            case 1:

                mysteryShipPoints = 300;

                break;

            case 2:

                mysteryShipPoints = 150;

                break;

            case 3:

                mysteryShipPoints = 100;

                break;

            case 4:

                mysteryShipPoints = 50;

                break;
        }

        UpdatePlayer1Score(mysteryShipPoints);
    }


    public void UpdatePlayer1Score(int points)
    {
        player1Score += points;

        ///ScoreController.scoreController.UpdateScoreDisplay(player1Score, ScoreController.PLAYER_1);

        player1ScoreValue.text = player1Score.ToString("0000");
    }


    private void UpdatePlayer1Lives()
    {
        player1Lives -= 1;

        if (player1Lives == 0)
        {
            canPlay = false;

            gameOver = true;

            ///gameOverText.gameObject.SetActive(true);

            UpdateHighScore();
        }

        else
        {
            ///LivesController.livesController.UpdateLives(player1Lives);

            ///StartCoroutine(PlayerRespawnDelay());
        }
    }


    private void UpdatePlayer1Cities()
    {
        player1Cities -= 1;

        if (player1Cities == 0)
        {
            canPlay = false;

            gameOver = true;

            ///gameOverText.gameObject.SetActive(true);

            ///UpdateHighScore();
        }
    }


    private void UpdateHighScore()
    {
        if (player1Score > highScore)
        {
            highScore = player1Score;
        }

        ///ScoreController.scoreController.UpdateScoreDisplay(highScore, ScoreController.HIGH_SCORE);

        highScoreValue.text = highScore.ToString("0000");
    }


} // end of class
