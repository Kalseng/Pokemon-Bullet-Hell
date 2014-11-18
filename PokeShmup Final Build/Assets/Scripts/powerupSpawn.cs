using UnityEngine;
using System.Collections;

public class powerupSpawn : MonoBehaviour {

	
	private LogicOfTheGame controller;
	private GameObject gameControllerObject;

	public float powerUpRequirement;

	public GameObject shot;
	public Transform shotSpawn;

	public float fireRate;
	private float nextFire;
	private GameObject bulletsFolder;

	// Use this for initialization
	void Start () {

		//Finds the bulletsFolder object with the name "Bullets".
		//This object is used to store bullets that the powerup
		//spawns will be firing.
		bulletsFolder = GameObject.Find ("Bullets");

		//Finds the LogicOfTheGame, with the name "LogicOfTheGame".
		//This is used to manage the powerUp level of the player, as
		//well as to link up this object to the rest of the game's
		//game logic.
		gameControllerObject = GameObject.FindWithTag ("LogicOfTheGame");
		if (gameControllerObject != null)
		{
			controller = gameControllerObject.GetComponent<LogicOfTheGame>();
		}
		if (controller == null)
		{
			Debug.Log ("Cannot find 'LogicOfTheGame' script");
		}


	}
	
	// Update is called once per frame
	void FixedUpdate () {
	
		//This is used to check if the appropriate powerup level
		//has been reached. IF it has, it displays this object
		//and allows it to read for inputs so that it can fire
		//bullets.
		if (controller.getPowerup () >= powerUpRequirement) {
						this.renderer.enabled = true;
						checkInputs ();
				} else {
			this.renderer.enabled = false;
				}

	}


	void checkInputs(){

		//This checks the input to see if the user is pressing
		//the firing button. If they are, the 
		if (Input.GetButton ("Fire1") && Time.time > nextFire) {
						nextFire = Time.time + fireRate;
						Transform t = ((GameObject)Instantiate (shot, shotSpawn.position, shotSpawn.rotation)).transform;
						t.parent = bulletsFolder.transform;
				}
	}
}
