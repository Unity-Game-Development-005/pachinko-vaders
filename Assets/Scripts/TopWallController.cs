
using UnityEngine;



public class TopWallController : MonoBehaviour
{
    [SerializeField] private Transform baseTransform1;

    [SerializeField] private Transform baseTransform2;

    [SerializeField] private Transform baseTransform3;

    [SerializeField] private Transform baseMissile1;

    [SerializeField] private Transform baseMissile2;

    [SerializeField] private Transform baseMissile3;

    private float baseLauncherPositionY;



    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Initialise();
    }


    private void Initialise()
    {
        baseLauncherPositionY = 4.4f;
    }


    private void OnCollisionEnter2D(Collision2D collidingObject)
    {
        // if the ufo missile hits the ground
        if (collidingObject.transform.CompareTag("BaseMissile1"))
        {
            // deactivate the missile
            baseMissile1.gameObject.SetActive(false);

            // then return it to its launcher position
            baseMissile1.position = new Vector2(baseTransform1.position.x, baseLauncherPositionY);

            GameController.gameController.canLaunch1 = true;
        }

        // if the ufo missile hits the ground
        if (collidingObject.transform.CompareTag("BaseMissile2"))
        {
            // deactivate the missile
            baseMissile1.gameObject.SetActive(false);

            // then return it to its launcher position
            baseMissile2.position = new Vector2(baseTransform2.position.x, baseLauncherPositionY);

            GameController.gameController.canLaunch2 = true;
        }

        // if the ufo missile hits the ground
        if (collidingObject.transform.CompareTag("BaseMissile3"))
        {
            // deactivate the missile
            baseMissile3.gameObject.SetActive(false);

            // then return it to its launcher position
            baseMissile3.position = new Vector2(baseTransform3.position.x, baseLauncherPositionY);

            GameController.gameController.canLaunch3 = true;
        }
    }


} // end of class
