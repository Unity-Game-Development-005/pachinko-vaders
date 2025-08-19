
using UnityEngine;


//
// Pachinko Vaders v2025.07.04
//
// 2025.08.19
//

public class LivesController : MonoBehaviour
{
    public static LivesController livesController;

    public Transform[] lives;


    private void Awake()
    {
        livesController = this;
    }


    public void UpdateLives(int livesRemaining)
    {
        for (int i = 0; i < lives.Length; i++)
        {
            lives[i].gameObject.SetActive(false);
        }

        for (int i = 0; i < lives.Length; i++)
        {
            //if (i + 1 == livesRemaining - 1)
            if (i + 1 == livesRemaining)
            {
                lives[i].gameObject.SetActive(true);
            }
        }
    }


} // end of class
