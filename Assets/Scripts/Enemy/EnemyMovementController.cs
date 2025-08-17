
using UnityEngine;

public class EnemyMovementController : MonoBehaviour
{
    [SerializeField] private GameObject bullet;

    private float enemyMoveSpeed;

    private Vector3 enemyDirection;

    public int amountKilled;

    public int totalEnemy;

    public float percentKilled;

    public int amountAlive;

    public float missileAttackRate;



    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Initialise();

        InvokeRepeating(nameof(MissileAttack), missileAttackRate, missileAttackRate);
    }


    // Update is called once per frame
    void Update()
    {
        MoveEnemy();

        amountAlive = GetEnemyAlive();
    }


    private void Initialise()
    {
        enemyMoveSpeed = 0.25f;

        enemyDirection = Vector2.right;

        totalEnemy = 25;

        missileAttackRate = 1f;
    }


    private void MoveEnemy()
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


    private void MissileAttack()
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

                break;
            }

        }
    }


    private void EnemyKilled()
    {
        amountKilled++;
    }


    private int GetEnemyAlive()
    {
        return totalEnemy - amountKilled;
    }


    private float GetEnemyPercentageKilled()
    {
        return (float)amountKilled / (float)totalEnemy;
    }


} // end of class
