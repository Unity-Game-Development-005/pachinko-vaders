
using UnityEngine;


public class GameController : MonoBehaviour
{
    public static GameController gameController;











    public bool canLaunch1;

    public bool canLaunch2;

    public bool canLaunch3;










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
