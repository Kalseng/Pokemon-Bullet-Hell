using UnityEngine;
using System.Collections;

public class gengarPatterns : MonoBehaviour {
	
	private GameObject searingShotScript;
	public GameObject eyes1, eyes2, mouths;
	public Transform eyeSpawn1, eyeSpawn2, mouthSpawn;
	public GameObject explosion, bulletExplosion;
	
	
	public int pointsWorth;
	
	private bool objectDestroyed = false;
	private LogicOfTheGame controller;
	
	private GameObject bulletFolder, explosionFolder;
	private int health = 1500;
	
	//For searingShot
	
	private float currentTime;
	private bool part1active, part2active;
	
	
	
	// Use this for initialization
	void Start () {
		currentTime = Time.time;
		bulletFolder = GameObject.Find ("Bullets");
		explosionFolder = GameObject.Find ("Explosion Effects");
		gengarAttacks ();
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
	
	// Update is called once per frame
	void Update () {
		
		if (health > 750) {
			//gengarAttacks ();
		}
		if (health <= 750 && health >= 500){
			part2active = false;
		}
		
	}
	
	
	void gengarAttacks(){
		InvokeRepeating ("scareyFace", 2.5f, 5.0f);
				

	}
	
	void dreamEater(){

	}
	
	void scareyFace(){

		Transform eye1 = ((GameObject)Instantiate (eyes1, eyeSpawn1.position, eyeSpawn1.rotation)).transform;
		eye1.parent = bulletFolder.transform;
		Transform eye2 = ((GameObject)Instantiate (eyes2, eyeSpawn2.position, eyeSpawn2.rotation)).transform;
		eye2.parent = bulletFolder.transform;
		Transform mouth = ((GameObject)Instantiate (mouths, mouthSpawn.position, mouthSpawn.rotation)).transform;
		mouth.parent = bulletFolder.transform;

	}
	
	void OnTriggerEnter(Collider collider){
		Debug.Log ("what");
		if (collider.tag == "Player Bullets") {
			Destroy (collider.gameObject);
			Transform t = ((GameObject)Instantiate (bulletExplosion, new Vector3 (this.gameObject.transform.position.x, this.gameObject.transform.position.y + 1, this.gameObject.transform.position.z - 5), this.gameObject.transform.rotation)).transform;
			t.parent = explosionFolder.transform;
			health--;
			Debug.Log ("health decreased to: " + health);
			if (health <= 0) {
				Destroy (this.gameObject);
				if (!objectDestroyed) {
					controller.AddScore (pointsWorth);
					Instantiate (explosion, transform.position, transform.rotation);
					objectDestroyed = true;
				}
			}
			
		}
	}
	
	
}
