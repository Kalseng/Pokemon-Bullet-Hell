using UnityEngine;
using System.Collections;

public class ShadowBallMover : MonoBehaviour {

	private float startTime;
	public float speed;

	// Use this for initialization
	void Start () {
		startTime = Time.time;
	}
	
	// Update is called once per frame
	void Update () {
	if((Time.time-startTime)>2.0)
		rigidbody.velocity = transform.forward * speed;
	
	}
}
