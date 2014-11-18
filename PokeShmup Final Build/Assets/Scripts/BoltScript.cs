using UnityEngine;
using System.Collections;

public class BoltScript : MonoBehaviour {

	private GameController gameController;
	public GameObject playerExplosion;

	void Start ()
	{
		GameObject gameControllerObject = GameObject.FindWithTag ("GameController");
		if (gameControllerObject != null)
		{
			gameController = gameControllerObject.GetComponent <GameController>();
		}
		if (gameController == null)
		{
			Debug.Log ("Cannot find 'GameController' script");
		}
	}

	void OnTriggerEnter(Collider other) 
	{
		if (other.tag == "Player")
		{
			Instantiate(playerExplosion, other.transform.position, other.transform.rotation);

			if(gameController.LoseLife())
			Destroy(other.gameObject);
			Destroy(gameObject);
		}

	}
}
