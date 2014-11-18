using UnityEngine;
using System.Collections;

public class LeafMover : MonoBehaviour {
	
	public float speed;
	
	void Start ()
	{
		rigidbody.velocity = new Vector3(Mathf.Sin(transform.forward.x)*speed, transform.forward.y, transform.forward.z);
	}

	void Update() {
		rigidbody.velocity = new Vector3(transform.forward.x*speed, transform.forward.y, (transform.forward.z+Mathf.Sin(8*Time.time))*speed);
	
	}
	
}
