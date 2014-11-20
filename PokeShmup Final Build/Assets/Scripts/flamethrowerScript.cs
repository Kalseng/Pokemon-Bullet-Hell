using UnityEngine;
using System.Collections;

public class flamethrowerScript : MonoBehaviour {

	public GameObject flame;

	private Transform bulletsFolder;

	// Use this for initialization
	void Start () {
		bulletsFolder = GameObject.Find ("Bullets").transform;
		InvokeRepeating ("throwflame", 0.0f, 0.075f);
	}
	
	// Update is called once per frame
	void FixedUpdate () {
	}

	void throwflame(){
		Transform t = ((GameObject)Instantiate (flame,
		                                        new Vector3(this.gameObject.transform.position.x, this.gameObject.transform.position.y, (this.transform.transform.position.z + (Random.value * 5 - 2.5f))), 
		                                        this.gameObject.transform.rotation)).transform;
		t.parent = bulletsFolder;
	}
}
