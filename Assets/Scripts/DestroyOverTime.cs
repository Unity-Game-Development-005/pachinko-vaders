
using UnityEngine;


public class DestroyOverTime : MonoBehaviour 
{

	public float lifetime;



	// Update is called once per frame
	void Update () 
	{
		lifetime -= Time.deltaTime;

		if(lifetime < 0)
		{
			Destroy(gameObject);
		}
	}


} // end of class