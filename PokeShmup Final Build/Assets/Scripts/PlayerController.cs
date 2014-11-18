using UnityEngine;
using System.Collections;

[System.Serializable]
public class Boundary
{
	public float xMin, xMax, zMin, zMax;
}

public class PlayerController : MonoBehaviour
{
	public float speed;
	public float slowSpeed;
	public float tilt;
	public Boundary boundary;

	public AudioSource intro;
	public AudioSource outro;
	public AudioSource loop;

	public GameObject bulletsFolder;
	public GameObject shot;
	public Transform shotSpawn;
	public float fireRate;
	public GameObject explosion;
	private float nextFire;
	private LogicOfTheGame controller;

	void Start(){

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
	
	void Update ()
	{

	}
	
	void FixedUpdate ()
	{
				float moveHorizontal = Input.GetAxis ("Horizontal");
				float moveVertical = Input.GetAxis ("Vertical");
		
				Vector3 movement = new Vector3 (moveHorizontal, 0.0f, moveVertical);
		if(Input.GetButton ("Fire3")){
			GameObject.Find ("hitbox").renderer.enabled = true;
			rigidbody.velocity = movement * slowSpeed;
		}
		else{
			
			GameObject.Find ("hitbox").renderer.enabled = false;
				rigidbody.velocity = movement * speed;
		}
				rigidbody.position = new Vector3 
			(
				Mathf.Clamp (rigidbody.position.x, boundary.xMin, boundary.xMax), 
				0.0f, 
				Mathf.Clamp (rigidbody.position.z, boundary.zMin, boundary.zMax)
				);
		
				rigidbody.rotation = Quaternion.Euler (0.0f, 0.0f, rigidbody.velocity.x * -tilt);
	
				if (Input.GetButtonDown ("Fire1")) {
			
						intro.Play ();
			
			
				} else if (Input.GetButton ("Fire1") && Time.time > nextFire) {
						nextFire = Time.time + fireRate;
						Transform t = ((GameObject)Instantiate (shot, shotSpawn.position, shotSpawn.rotation)).transform;
						t.parent = bulletsFolder.transform;
						if (!(intro.isPlaying) && !(loop.isPlaying) && !(outro.isPlaying)) {
								loop.Play ();
			}
			
				} else if (Input.GetButtonUp ("Fire1")) {
						loop.Stop ();
						outro.Play ();
				}


	
	
	
	}






	IEnumerator OnTriggerEnter(Collider collider){
				if (collider.tag == "Enemy Bullets") {

						if (controller.LoseLife ()) {
								Destroy (gameObject);
								GameObject[] respawns = GameObject.FindGameObjectsWithTag ("Enemy Bullets");
								Debug.Log (respawns.Length);
								foreach (GameObject respawn in respawns) {
								
										Destroy (respawn);
										Instantiate (explosion, respawn.transform.position, respawn.transform.rotation);
									
								}
								
						} else {
								this.collider.enabled = false;
								foreach (Transform child in this.transform) {	
										child.gameObject.SetActive (false);
								}

								yield return new WaitForSeconds (0.2f);
								foreach (Transform child in this.transform) {	
										child.gameObject.SetActive (true);
								}

								yield return new WaitForSeconds (0.2f);
								foreach (Transform child in this.transform) {	
										child.gameObject.SetActive (false);
								}

								yield return new WaitForSeconds (0.2f);
								foreach (Transform child in this.transform) {	
										child.gameObject.SetActive (true);
								}
								yield return new WaitForSeconds (0.2f);
								foreach (Transform child in this.transform) {	
										child.gameObject.SetActive (false);
								}
				
								yield return new WaitForSeconds (0.2f);
								foreach (Transform child in this.transform) {	
										child.gameObject.SetActive (true);
								}
								yield return new WaitForSeconds (0.2f);
								foreach (Transform child in this.transform) {	
										child.gameObject.SetActive (false);
								}
				
								yield return new WaitForSeconds (0.2f);
								foreach (Transform child in this.transform) {	
										child.gameObject.SetActive (true);
								}
								yield return new WaitForSeconds (1.0f);
								this.collider.enabled = true;

						}
				}
		}		

}