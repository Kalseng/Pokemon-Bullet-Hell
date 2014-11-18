using UnityEngine;
using System.Collections;

public class FlameMover : MonoBehaviour {

	public float speed;
	private Vector3 frwd;
	// Use this for initialization
	void Start () {

		//rigidbody.velocity = transform.forward * speed;

	
	}
	
	// Update is called once per frame
	void Update () {
		transform.Rotate(0, 180* Time.deltaTime, 0, Space.World);
		//rigidbody.velocity = frwd * speed;
	}
}
