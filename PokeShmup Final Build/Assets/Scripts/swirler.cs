using UnityEngine;
using System.Collections;

public class swirler : MonoBehaviour {

	public Transform hitbox;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		hitbox.eulerAngles += new Vector3 (0.0f,  0.5f, 0.0f);
	}
}
