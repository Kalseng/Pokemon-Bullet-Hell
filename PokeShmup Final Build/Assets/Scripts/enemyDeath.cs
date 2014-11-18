using UnityEngine;
using System.Collections;

public class enemyDeath : MonoBehaviour {


	public int health;
	public GameObject explosion;
	public GameObject bulletExplosion;
	public int pointsWorth;
	public GameObject explosionFolder;
	public GameObject drop1;
	private LogicOfTheGame controller;


	// Use this for initialization
	void Start () {


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
	
	// Update is called once per frame
	void Update () {
		if (controller.clearScreen()) {
			Debug.Log("Clear Screen");

						foreach (Transform child in this.transform) {
								Destroy(child.gameObject);
								Instantiate (explosion, child.transform.position, child.transform.rotation);
						}
			Destroy(this.gameObject);
			Instantiate (explosion, this.transform.position, this.transform.rotation);
				}
	}

	void OnTriggerEnter(Collider collider){
		if (collider.tag == "Player Bullets"){
			Destroy (collider.gameObject);
			Transform t = ((GameObject) Instantiate(bulletExplosion, new Vector3(this.gameObject.transform.position.x, this.gameObject.transform.position.y + 1, this.gameObject.transform.position.z - 5), this.gameObject.transform.rotation)).transform;
			t.parent = explosionFolder.transform;
			health = health-1;
			if(health <= 0){
				Destroy (this.gameObject);
				controller.AddScore(pointsWorth);
				Instantiate (explosion, transform.position, transform.rotation);
				Instantiate (drop1, this.gameObject.transform.position, this.gameObject.transform.rotation);
			}

		}
	}
}