using UnityEngine;
using System.Collections;

public class Bonemerang : MonoBehaviour {
	
	public float lifetime;
	public GameObject shot;
	public Transform shotSpawn1;
	public GameObject bulletFolder;
	
	// Use this for initialization
	void Start () {
		bulletFolder = GameObject.Find ("Bullets");
		InvokeRepeating ("BoneSpawn", 0.05f, 1.0f);
		InvokeRepeating ("BoneSpawn", 0.15f, 1.0f);
		InvokeRepeating ("BoneSpawn", 0.25f, 1.0f);
		InvokeRepeating ("BoneSpawn", 0.35f, 1.0f);
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	
	void BoneSpawn(){
		
		
		Transform t = ((GameObject)Instantiate (shot, shotSpawn1.position, shotSpawn1.rotation)).transform;
		t.parent = bulletFolder.transform;

		audio.Play ();
	}
}
