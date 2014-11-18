using UnityEngine;
using System.Collections;

public class vCreateMover : MonoBehaviour {

	// Use this for initialization
	void Start () {
		rigidbody.velocity = transform.forward * 2;
	}
	
	// Update is called once per frame
	void Update () {
		rigidbody.velocity = rigidbody.velocity * 1.02f;
	}
}
