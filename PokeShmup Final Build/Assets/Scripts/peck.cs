using UnityEngine;
using System.Collections;

public class peck : MonoBehaviour {

	public Transform spawn1, spawn2, spawn3, spawn4, spawn5, spawn6;
	public GameObject bullet;
	public GameObject bulletFolder;

	// Use this for initialization
	void Start () {
		InvokeRepeating ("PeckSpawn", 0.1f, 2.0f);
		bulletFolder = GameObject.Find ("Bullets");
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void PeckSpawn(){
//		Transform t1=((GameObject)Instantiate (bullet, spawn1.position, spawn1.rotation)).transform;
//
//		Transform t2=((GameObject)Instantiate (bullet, spawn2.position, spawn2.rotation)).transform;
//
//		Transform t3=((GameObject)Instantiate (bullet, spawn3.position, spawn3.rotation)).transform;
//
//		Transform t4=((GameObject)Instantiate (bullet, spawn4.position, spawn4.rotation)).transform;
//
//		Transform t5=((GameObject)Instantiate (bullet, spawn5.position, spawn5.rotation)).transform;
//
//		Transform t6=((GameObject)Instantiate (bullet, spawn6.position, spawn6.rotation)).transform;
//
//		t1.parent = bulletFolder.transform;
//		t2.parent = bulletFolder.transform;
//		t3.parent = bulletFolder.transform;
//		t4.parent = bulletFolder.transform;
//		t5.parent = bulletFolder.transform;
//		t6.parent = bulletFolder.transform;
				Transform t = ((GameObject)Instantiate (bullet, spawn1.position, spawn1.rotation)).transform;
				t.parent = bulletFolder.transform;
				t = ((GameObject)Instantiate (bullet, spawn2.position, spawn2.rotation)).transform;
				t.parent = bulletFolder.transform;
				t = ((GameObject)Instantiate (bullet, spawn3.position, spawn3.rotation)).transform;
				t.parent = bulletFolder.transform;
				t = ((GameObject)Instantiate (bullet, spawn4.position, spawn4.rotation)).transform;
				t.parent = bulletFolder.transform;
				t = ((GameObject)Instantiate (bullet, spawn5.position, spawn5.rotation)).transform;
				t.parent = bulletFolder.transform;
				t = ((GameObject)Instantiate (bullet, spawn6.position, spawn6.rotation)).transform;
				t.parent = bulletFolder.transform;

		}
}
