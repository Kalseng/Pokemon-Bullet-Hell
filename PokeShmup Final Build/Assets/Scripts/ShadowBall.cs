using UnityEngine;
using System.Collections;

public class ShadowBall : MonoBehaviour {
	public float speed;
	private float startTime;

	// Use this for initialization
	void Start () {
		startTime = Time.time;
	}
	
	// Update is called once per frame
	void Update () {
				if ((Time.time - startTime) > 2.0) {
						rigidbody.velocity = transform.forward * speed;
				} else {
						transform.Rotate (0, 180 * Time.deltaTime, 0, Space.World);
	
				}
		}
}
