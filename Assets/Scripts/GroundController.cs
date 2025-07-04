
using UnityEngine;



public class GroundController : MonoBehaviour
{
    [SerializeField] private Transform ufoTransform;

    [SerializeField] private Transform ufoMissile;

    private float ufoLauncherPositionY;



    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Initialise();
    }


    private void Initialise()
    {
        ufoLauncherPositionY = 3.25f;
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        // if the ufo missile hits the ground
        if (collision.transform.CompareTag("UfoMissile"))
        {
            // deactivate the missile
            ufoMissile.gameObject.SetActive(false);

            // then return it to its launcher position
            ufoMissile.position = new Vector2(ufoTransform.position.x, ufoLauncherPositionY);
        }
    }


} // end of class
