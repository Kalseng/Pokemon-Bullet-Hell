using UnityEngine;
using System.Collections;

public class VineWhip : MonoBehaviour {

	public float lifetime;
	public GameObject shot;
	public Transform shotSpawn1, shotSpawn2, shotSpawn3, shotSpawn4;
	public GameObject bulletFolder;

	// Use this for initialization
	void Start () {
		bulletFolder = GameObject.Find ("Bullets");
		InvokeRepeating ("VineWhipSpawn", 0.1f, 0.2f);

	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void VineWhipSpawn(){
		

		Transform t = ((GameObject)Instantiate (shot, shotSpawn1.position, shotSpawn1.rotation)).transform;
		t.parent = bulletFolder.transform;
		t = ((GameObject)Instantiate (shot, shotSpawn2.position, shotSpawn2.rotation)).transform;
		t.parent = bulletFolder.transform;
		t = ((GameObject)Instantiate (shot, shotSpawn3.position, shotSpawn3.rotation)).transform;
		t.parent = bulletFolder.transform;
		t = ((GameObject)Instantiate (shot, shotSpawn4.position, shotSpawn4.rotation)).transform;
		t.parent = bulletFolder.transform;
		     audio.Play ();
	}
}
