
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

//
// Pachinko Vaders v2025.07.04
//
// v2025.08.21
//

public class GameController : MonoBehaviour
{
    public static GameController gameController;


    public TMP_Text livesText;

    public TMP_Text playerScoreValue;

    public TMP_Text highScoreValue;


    public Transform startScreen;

    public Transform gameOverScreen;

    public Transform readyPlayerOneScreen;


    public List<GameObject> missiles;


    public GameObject[] missileBases;

    public GameObject[] missileBaseShields;

    public GameObject[] missileSilos;

    public GameObject[] cities;

    public GameObject[] cityShields;


    public GameObject[] enemies;


    [HideInInspector] public int playerLives;

    [HideInInspector] public int playerCities;

    [HideInInspector] public int remainingMissilePoints;

    [HideInInspector] public int remainingCitiesPoints;

    private int playerScore;

    private int highScore;


    [HideInInspector] public int mysteryShipPoints;

    [HideInInspector] public int enemyUfoPoints;

    [HideInInspector] public int enemyPlanePoints;

    [HideInInspector] public int enemyMissilePoints;

    [HideInInspector] public int enemy1Points;

    [HideInInspector] public int enemy2Points;

    [HideInInspector] public int enemy3Points;

    [HideInInspector] public int totalEnemy;



    [HideInInspector] public bool canPlay;

    [HideInInspector] public bool gameOver;


    private const int MISSILE_BASE_1 = 0;

    private const int MISSILE_BASE_2 = 1;

    private const int MISSILE_BASE_3 = 2;




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



    private void Start()
    {
        CabinetStartUp();
    }


    // cabinet startup
    private void CabinetStartUp()
    {
        canPlay = false;

        gameOver = true;

        highScore = 0;

        highScoreValue.text = "0000";

        GameReset();

        gameOverScreen.gameObject.SetActive(false);

        readyPlayerOneScreen.gameObject.SetActive(false);

        startScreen.gameObject.SetActive(true);

        Time.timeScale = 0;
    }


    private void GameReset()
    {
        playerScore = 0;

        playerLives = 0;

        playerCities = 0;

        remainingMissilePoints = 0;

        remainingCitiesPoints = 0;

        mysteryShipPoints = 0;

        enemyUfoPoints = 0;

        enemyPlanePoints = 0;

        enemy1Points = 0;

        enemy2Points = 0;

        enemy3Points = 0;

        totalEnemy = 0;

        playerScoreValue.text = "0000";
    }


    private void Initialise()
    {
        playerScore = 0;

        playerLives = 3;

        playerCities = 6;

        remainingMissilePoints = 5;

        remainingCitiesPoints = 100;


        enemyMissilePoints = 25;

        enemyUfoPoints = 100;

        enemyPlanePoints = 100;

        enemy1Points = 50;

        enemy2Points = 30;

        enemy3Points = 10;

        totalEnemy = 27;


        ActivateMissileBases();

        ActivateCities();


        playerScoreValue.text = playerScore.ToString("0000");

        PlayerController.player.Initialise();


        ActivateEnemies();


        startScreen.gameObject.SetActive(false);

        gameOverScreen.gameObject.SetActive(false);

        StartCoroutine(StartDelay());
    }


    private void ActivateEnemies()
    {
        for (int enemy = 0; enemy < totalEnemy; enemy++)
        {
            enemies[enemy].SetActive(true);
        }
    }


    private void ActivateMissileBases()
    {
        for (int missileBase = 0; missileBase < playerLives; missileBase++)
        {
            missileBases[missileBase].SetActive(true);

            missileBaseShields[missileBase].SetActive(true);

            missileBaseShields[missileBase].GetComponent<ShieldController>().currentShieldStrength = 100;

            missileBaseShields[missileBase].GetComponent<ShieldController>().maximumShieldStrength = 100;

            missileBaseShields[missileBase].GetComponent<ShieldController>().shieldDamage = 10;

            missileBaseShields[missileBase].GetComponent<ShieldController>().healthBar.fillAmount =
                (float)missileBaseShields[missileBase].GetComponent<ShieldController>().currentShieldStrength /
                (float)missileBaseShields[missileBase].GetComponent<ShieldController>().maximumShieldStrength;

        }
    }


    private void ActivateCities()
    {
        for (int city = 0; city < playerCities; city++)
        {
            cities[city].SetActive(true);

            cityShields[city].SetActive(true);

            cityShields[city].GetComponent<ShieldController>().currentShieldStrength = 100;

            cityShields[city].GetComponent<ShieldController>().maximumShieldStrength = 100;

            cityShields[city].GetComponent<ShieldController>().shieldDamage = 10;

            cityShields[city].GetComponent<ShieldController>().healthBar.fillAmount = 
                (float)cityShields[city].GetComponent<ShieldController>().currentShieldStrength / 
                (float)cityShields[city].GetComponent<ShieldController>().maximumShieldStrength;
        }
    }


    private IEnumerator StartDelay()
    {
        readyPlayerOneScreen.gameObject.SetActive(true);

        Time.timeScale = 1;

        yield return new WaitForSeconds(3f);

        gameOver = false;

        canPlay = true;

        readyPlayerOneScreen.gameObject.SetActive(false);
    }


    public void StartOnePlayer()
    {
        GameReset();

        Initialise();
    }


    private void GameOver()
    {
        Time.timeScale = 0;

        canPlay = false;

        gameOver = true;

        gameOverScreen.gameObject.SetActive(true);
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


    public void UfoPoints()
    {
        UpdatePlayer1Score(enemyUfoPoints);
    }


    public void PlanePoints()
    {
        UpdatePlayer1Score(enemyPlanePoints);
    }


    public void ActivateMissileSilos()
    {
        missileSilos[MISSILE_BASE_1].SetActive(true);

        missileSilos[MISSILE_BASE_2].SetActive(true);

        missileSilos[MISSILE_BASE_3].SetActive(true);

        // detach the missile silos from their parant game object
        missileSilos[MISSILE_BASE_1].transform.SetParent(null);

        missileSilos[MISSILE_BASE_2].transform.SetParent(null);

        missileSilos[MISSILE_BASE_3].transform.SetParent(null);
    }


    public void MissileBaseDestroyed()
    {
        if (!missileBases[MISSILE_BASE_1].activeInHierarchy)
        {
            missileSilos[MISSILE_BASE_1].SetActive(false);
        }

        if (!missileBases[MISSILE_BASE_2].activeInHierarchy)
        {
            missileSilos[MISSILE_BASE_2].SetActive(false);
        }

        if (!missileBases[MISSILE_BASE_3].activeInHierarchy)
        {
            missileSilos[MISSILE_BASE_3].SetActive(false);
        }

        UpdatePlayer1Lives();
    }


    private void UpdatePlayer1Lives()
    {
        playerLives -= 1;

        LivesController.livesController.UpdateLives(playerLives);

        if (playerLives == 0)
        {
            UpdateHighScore();

            GameOver();
        }
    }


    public void CityDestroyed()
    {
        playerCities -= 1;

        if (playerCities == 0)
        {
            UpdateHighScore();

            GameOver();
        }
    }


    public void UpdatePlayer1Score(int points)
    {
        playerScore += points;

        playerScoreValue.text = playerScore.ToString("0000");
    }


    private void UpdateHighScore()
    {
        if (playerScore > highScore)
        {
            highScore = playerScore;
        }

        highScoreValue.text = highScore.ToString("0000");
    }


} // end of class
