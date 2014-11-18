using UnityEngine;
using System.Collections;


public class MouthMover : MonoBehaviour {

	public float speed;
	private bool spinning;
	private float startTime;
	// Use this for initialization
	void Start () {
		waits ();
		startTime = Time.time;
		rigidbody.velocity = transform.forward * speed;

	}
	
	// Update is called once per frame
	void Update () {
		if((Time.time-startTime)>1.0)
			transform.Rotate(0, 180* Time.deltaTime, 0, Space.World);
	
	}
	IEnumerator waits(){
		yield return new WaitForSeconds (4.0f);
	
	}
}
