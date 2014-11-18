using UnityEngine;
using System.Collections;

public class GemThrow : MonoBehaviour {
	
	public Transform spawn1, spawn2, spawn3;
	public GameObject bullet;
	public GameObject bulletFolder;
	
	// Use this for initialization
	void Start () {
		InvokeRepeating ("GemSpawn", 0.1f, 2.0f);
		InvokeRepeating ("GemSpawn", 0.5f, 2.0f);
		bulletFolder = GameObject.Find ("Bullets");
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	
	void GemSpawn(){

		Transform t = ((GameObject)Instantiate (bullet, spawn1.position, spawn1.rotation)).transform;
		t.parent = bulletFolder.transform;
		t = ((GameObject)Instantiate (bullet, spawn2.position, spawn2.rotation)).transform;
		t.parent = bulletFolder.transform;
		t = ((GameObject)Instantiate (bullet, spawn3.position, spawn3.rotation)).transform;
		t.parent = bulletFolder.transform;
	}
}

