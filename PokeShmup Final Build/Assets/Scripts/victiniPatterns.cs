using UnityEngine;
using System.Collections;

public class victiniPatterns : MonoBehaviour {

	private GameObject searingShotScript;

	public GameObject searingShotBullet1, searingShotBullet2;
	public GameObject searingShotSpawn1, searingShotSpawn2;
	public GameObject explosion, bulletExplosion;
	public GameObject vCreateSpawns, vCreateBullet;
	public GameObject flamethrowerObject, flamethrowerSpawn1, flamethrowerSpawn2;


	public int pointsWorth;

	private bool objectDestroyed = false;
	private LogicOfTheGame controller;

	private GameObject bulletFolder, explosionFolder, vCreateFolder;
	private int health = 1000;

	//For searingShot
	private float currentTime;
	private bool part1active, part2active;

	//for vCreate
	private bool vCreatePart1Active, vCreatePart2Active;
	private int timesInvoked;

	//for flamethrower
	private bool flamethrowerPart1Active;
	private Transform thisTransform;

	// Use this for initialization
	void Start () {
		thisTransform = this.transform;

		currentTime = Time.time;

		vCreateFolder = GameObject.Find ("vCreate Folder");
		bulletFolder = GameObject.Find ("Bullets");
		explosionFolder = GameObject.Find ("Explosion Effects");

		GameObject gameControllerObject = GameObject.FindWithTag ("LogicOfTheGame");
		if (gameControllerObject != null)
		{
			controller = gameControllerObject.GetComponent<LogicOfTheGame>();
		}
		if (controller == null)
		{
			Debug.Log ("Cannot find 'LogicOfTheGame' script");
		}

	}

	/*
	 * 
			Debug.Log ("Condition 1 activated");
						searingShot ();
	 * 
	 * 
	 * 
	 * Debug.Log ("Condition 2 activated");
						part2active = false;
						if (vCreatePart1Active == false) {
								controller.ClearBullets (bulletFolder.transform);
								CancelInvoke ();
								vCreate ();
	 */
	
	// Update is called once per frame
	void Update () {

				if (health >= 667) {
						Debug.Log ("Condition 1 activated");
						if (vCreatePart1Active == false) {
								controller.ClearBullets (bulletFolder.transform);
								CancelInvoke ();
								vCreate ();
						}
				}
				if (health <= 666 && health >= 334) {
						Debug.Log ("Condition 2 activated");

						searingShot ();
				}
				if (health <= 333) {
						Debug.Log ("Condition 3 activated");
						part2active = false;
						if (flamethrowerPart1Active == false) {
								CancelInvoke ();
								controller.ClearBullets (bulletFolder.transform);
								flamethrower ();
						}
				}
		}


	void searingShot(){

				if (part1active == false && part2active == false) {
						currentTime = Time.time;
						CancelInvoke ();
						part1active = true;
						InvokeRepeating ("searingShotPart1", 0.0f, 0.08f);
						Debug.Log ("I'm being called");
				}

				if (Time.time - currentTime >= 3 && part1active) {
						CancelInvoke ();
						part2active = true;
				}
				if (part2active && part1active) {
						part1active = false;
						CancelInvoke ();
						InvokeRepeating ("searingShotPart2", 0.5f, 0.2f);
				}
		}

	void searingShotPart1(){
		float yPosition = (Random.value * 30) - 15;
		Transform t = ((GameObject)Instantiate (searingShotBullet1, searingShotSpawn1.transform.position, searingShotSpawn1.transform.rotation)).transform;
		t.eulerAngles = new Vector3 (searingShotSpawn1.transform.position.x, yPosition, searingShotSpawn1.transform.position.z);
		t.parent = bulletFolder.transform;
	}

	void searingShotPart2(){
		Transform t = ((GameObject)Instantiate (searingShotBullet2, new Vector3 (((Random.value * 126) - 63), 0, searingShotSpawn2.transform.position.z), searingShotSpawn2.transform.rotation)).transform;
		t.parent = bulletFolder.transform;
		t = ((GameObject)Instantiate (searingShotBullet2, new Vector3 (((Random.value * 126) - 63), 0, searingShotSpawn2.transform.position.z), searingShotSpawn2.transform.rotation)).transform;
		t.parent = bulletFolder.transform;
		t = ((GameObject)Instantiate (searingShotBullet2, new Vector3 (((Random.value * 126) - 63), 0, searingShotSpawn2.transform.position.z), searingShotSpawn2.transform.rotation)).transform;
		t.parent = bulletFolder.transform;
		//t = ((GameObject)Instantiate (searingShotBullet2, new Vector3 (((Random.value * 126) - 63), 0, searingShotSpawn2.transform.position.z), searingShotSpawn2.transform.rotation)).transform;
		//t.parent = bulletFolder.transform;
	}

	void vCreate(){
		if (vCreatePart1Active == false) {
			Debug.Log ("vCreate called");
			timesInvoked = 0;
			InvokeRepeating ("CreateV", 0.5f, 5.0f);
			vCreatePart1Active = true;
		}

	}

	void CreateV(){
		Debug.Log ("CreateV called");
		//if (vCreatePart2Active == false) {
		Transform babyt;
		Transform t = ((GameObject)Instantiate (vCreateSpawns, new Vector3 (0, 0, -20), Quaternion.Euler (new Vector3 (0, 0, 0)))).transform;
		t.parent = vCreateFolder.transform;
		foreach (Transform child in t) {
			babyt = ((GameObject)Instantiate (vCreateBullet, child.position, Quaternion.Euler (new Vector3 (child.rotation.x, 180, child.rotation.z)))).transform;
			babyt.parent = child;
		}
		t = ((GameObject)Instantiate (vCreateSpawns, new Vector3 (45, 0, -20), Quaternion.Euler (new Vector3 (0, 0, 0)))).transform;
		t.parent = vCreateFolder.transform;
		foreach (Transform child in t) {
			babyt = ((GameObject)Instantiate (vCreateBullet, child.position, Quaternion.Euler (new Vector3 (child.rotation.x, 180, child.rotation.z)))).transform;
			babyt.parent = child;
		}
		t = ((GameObject)Instantiate (vCreateSpawns, new Vector3 (-45, 0, -20), Quaternion.Euler (new Vector3 (0, 0, 0)))).transform;
		t.parent = vCreateFolder.transform;
		foreach (Transform child in t) {
			babyt = ((GameObject)Instantiate (vCreateBullet, child.position, Quaternion.Euler (new Vector3 (child.rotation.x, 180, child.rotation.z)))).transform;
			babyt.parent = child;
		}
		timesInvoked += 1;
		Debug.Log ("Times Invoked: " + timesInvoked);
		//}

	}

	
	void flamethrower(){

		InvokeRepeating ("spawnFlame", 0.0f, 6.0f);
		InvokeRepeating ("spawnFlame2", 2.0f, 6.0f);
		flamethrowerPart1Active = true;

		}

	void spawnFlame(){

				Transform t = ((GameObject)(Instantiate (flamethrowerObject, flamethrowerSpawn1.transform.position, flamethrowerSpawn1.transform.rotation))).transform;
				t.parent = bulletFolder.transform;
		}



	void spawnFlame2(){
		
		Transform t = ((GameObject)(Instantiate (flamethrowerObject, flamethrowerSpawn2.transform.position, flamethrowerSpawn2.transform.rotation))).transform;
				t.parent = bulletFolder.transform;
		}

	void OnTriggerEnter(Collider collider){
				if (collider.gameObject.tag == "Player Bullets") {
						Destroy (collider.gameObject);
						Transform t = ((GameObject)Instantiate (bulletExplosion, new Vector3 (this.gameObject.transform.position.x, this.gameObject.transform.position.y + 1, this.gameObject.transform.position.z - 5), this.gameObject.transform.rotation)).transform;
						t.parent = explosionFolder.transform;
						health--;
						if (health <= 0) {
								if (!objectDestroyed) {
										controller.AddScore (pointsWorth);
										Instantiate (explosion, transform.position, transform.rotation);
										objectDestroyed = true;
										controller.setLevel1Over();
										//Application.LoadLevel ("Level 2");
								}
						}
				}
		}
			}
