using UnityEngine;
using System.Collections;


public class SpinningFlames : MonoBehaviour {
	
	public float lifetime;
	public GameObject shot;
	public Transform shotSpawn1;
	public GameObject bulletFolder;
	
	// Use this for initialization
	void Start () {
		bulletFolder = GameObject.Find ("Bullets");
		InvokeRepeating ("SpinningFlamesSpawn", 0.2f, 2.2f);
		InvokeRepeating ("SpinningFlamesSpawn", 0.7f, 2.2f);
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	
	void SpinningFlamesSpawn(){
		
		
		Transform t = ((GameObject)Instantiate (shot, shotSpawn1.position, shotSpawn1.rotation)).transform;
		t.parent = bulletFolder.transform;
		audio.Play ();
	}
}
