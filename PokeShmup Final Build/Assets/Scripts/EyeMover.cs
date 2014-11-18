using UnityEngine;
using System.Collections;


public class EyeMover : MonoBehaviour {
	
	public float speed;
	public float posOrNeg;
	
	// Use this for initialization
	void Start () {
		//transform.forward = new Vector3 (posOrNeg, 0.0f, 0.0f);
		rigidbody.velocity = transform.forward * speed;
		//waits ();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	//IEnumerator waits(){
		//yield return new WaitForSeconds (4.0f);
	//	rigidbody.velocity = transform.forward * speed;
		
	//}
}
