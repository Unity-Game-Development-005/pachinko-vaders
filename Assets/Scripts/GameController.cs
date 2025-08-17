
using UnityEngine;


public class GameController : MonoBehaviour
{
    public static GameController gameController;














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
        Initialise();
    }


    // Update is called once per frame
    void Update()
    {
        
    }




    private void Initialise()
    {

    }


} // end of class
