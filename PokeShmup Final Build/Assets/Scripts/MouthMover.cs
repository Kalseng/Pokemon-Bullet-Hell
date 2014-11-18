using UnityEngine;
using System.Collections;


public class MouthMover : MonoBehaviour {

	public float speed;

	// Use this for initialization
	void Start () {
		//waits ();
		rigidbody.velocity = transform.forward * speed;
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	//IEnumerator waits(){
		//yield return new WaitForSeconds (4.0f);
	//	rigidbody.velocity = transform.forward * speed;
	
	//}
}
