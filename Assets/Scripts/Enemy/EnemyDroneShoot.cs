
using UnityEngine;
using System.Collections;


public class EnemyDroneShoot : MonoBehaviour
{

    [SerializeField] private GameObject bullet;




    void Start()
    {
        StartCoroutine(Shoot(Random.Range(5.5f, 6.5f)));
    }


    IEnumerator Shoot(float time)
    {
        yield return new WaitForSeconds(time);

        Instantiate(bullet, transform.position, Quaternion.identity);

        StartCoroutine(Shoot(Random.Range(5.5f, 6.5f)));
    }


} // end of class
