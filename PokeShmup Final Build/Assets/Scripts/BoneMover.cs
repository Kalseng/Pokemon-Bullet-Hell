using UnityEngine;
using System.Collections;

public class BoneMover : MonoBehaviour {
	
	public float radius = 1.0f;
	float startX, startZ;
	
	void Start ()
	{
		startX = transform.position.x+radius;
		startZ = transform.position.z+radius;
		//rigidbody.velocity = new Vector3(Mathf.Sin(transform.forward.x)*speed, transform.forward.y, transform.forward.z);
	}
	
	void Update() {


		rigidbody.velocity = new Vector3(startX+(Mathf.Sin(Time.time)*250), transform.forward.y, startZ+(Mathf.Cos(Time.time))*250);
		
	}
	
}
