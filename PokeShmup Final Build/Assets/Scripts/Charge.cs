using UnityEngine;
using System.Collections;

public class Charge : MonoBehaviour
{
	public float lifetime;
	public GameObject shot;
	public Transform shotSpawn1, shotSpawn2,shotSpawn3,shotSpawn4,shotSpawn5, shotSpawn6, shotSpawn7, shotSpawn8;
	public GameObject explosion;
	private GameObject bulletFolder;

	void Start ()
	{
		bulletFolder = GameObject.Find ("Bullets");
		InvokeRepeating ("ChargeShot", 1.0f, 1.5f);
		InvokeRepeating ("ChargeShot", 1.25f, 1.5f);
		InvokeRepeating ("ChargeShot", 1.5f, 1.5f);
	}

	void ChargeShot(){
				Transform t = ((GameObject)Instantiate (explosion, transform.position, transform.rotation)).transform;
				t.parent = bulletFolder.transform;
				t = ((GameObject)Instantiate (shot, shotSpawn1.position, shotSpawn1.rotation)).transform;
				t.parent = bulletFolder.transform;
				t = ((GameObject)Instantiate (shot, shotSpawn2.position, shotSpawn2.rotation)).transform;
				t.parent = bulletFolder.transform;
				t = ((GameObject)Instantiate (shot, shotSpawn3.position, shotSpawn3.rotation)).transform;
				t.parent = bulletFolder.transform;
				t = ((GameObject)Instantiate (shot, shotSpawn4.position, shotSpawn4.rotation)).transform;
				t.parent = bulletFolder.transform;
				t = ((GameObject)Instantiate (shot, shotSpawn5.position, shotSpawn5.rotation)).transform;
				t.parent = bulletFolder.transform;
				t = ((GameObject)Instantiate (shot, shotSpawn6.position, shotSpawn6.rotation)).transform;
				t.parent = bulletFolder.transform;
				t = ((GameObject)Instantiate (shot, shotSpawn7.position, shotSpawn7.rotation)).transform;
				t.parent = bulletFolder.transform;
				t = ((GameObject)Instantiate (shot, shotSpawn8.position, shotSpawn8.rotation)).transform;
				t.parent = bulletFolder.transform;
				audio.Play ();
		}

	void Update ()
	{
	}


}
