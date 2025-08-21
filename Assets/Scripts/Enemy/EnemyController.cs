
using UnityEngine;

//
// Pachinko Vaders v2025.07.04
//
// v2025.08.21
//

public class EnemyController : MonoBehaviour
{
    [SerializeField] private GameObject bullet;

    private float enemyMoveSpeed;

    private Vector3 enemyDirection;

    public int amountKilled;

    public float percentKilled;

    public int amountAlive;

    public float missileAttackRate;



    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        StartUp();
    }


    // Update is called once per frame
    void Update()
    {
        MoveEnemy();

        amountAlive = GetEnemyAlive();
    }


    private void StartUp()
    {
        Initialise();

        InvokeRepeating(nameof(MissileAttack), missileAttackRate, missileAttackRate);
    }


    private void Initialise()
    {
        enemyMoveSpeed = 0.25f;

        enemyDirection = Vector2.right;

        missileAttackRate = 1f;
    }


    private void MoveEnemy()
    {
        if (!GameController.gameController.gameOver)
        {
            transform.position += enemyDirection * enemyMoveSpeed * Time.deltaTime;

            Vector3 leftEdge = Camera.main.ViewportToWorldPoint(Vector3.zero);

            Vector3 rightEdge = Camera.main.ViewportToWorldPoint(Vector3.right);


            foreach (Transform invader in transform)
            {
                if (!invader.gameObject.activeInHierarchy)
                {
                    continue;
                }

                if (enemyDirection == Vector3.right && invader.position.x >= rightEdge.x - 1f)
                {
                    enemyDirection.x *= -1f;
                }

                else if (enemyDirection == Vector3.left && invader.position.x <= leftEdge.x + 1f)
                {
                    enemyDirection.x *= -1f;
                }
            }
        }
    }


    private void MissileAttack()
    {
        if (!GameController.gameController.gameOver)
        {
            foreach (Transform invader in transform)
            {
                if (!invader.gameObject.activeInHierarchy)
                {
                    continue;
                }

                if (Random.value < (1f / (float)amountAlive))
                {
                    Instantiate(bullet, invader.position, Quaternion.identity);

                    GameController.gameController.missiles.Add(bullet);

                    break;
                }
            }
        }
    }


    private void EnemyKilled()
    {
        amountKilled++;
    }


    private int GetEnemyAlive()
    {
        return GameController.gameController.totalEnemy - amountKilled;
    }


    private float GetEnemyPercentageKilled()
    {
        return (float)amountKilled / (float)GameController.gameController.totalEnemy;
    }


} // end of class
