using UnityEngine;
using System.Collections;

public class flamethrowerMoving : MonoBehaviour {


	private bool isMoving = false;

	// Use this for initialization
	void Start () {
		Invoke ("move", 1.0f);
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void move(){
		this.gameObject.rigidbody.velocity = Vector3.back * 20;
	}
}
