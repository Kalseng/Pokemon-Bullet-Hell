using UnityEngine;
using System.Collections;

public class Powerup : MonoBehaviour {

	private LogicOfTheGame controller;
	private GameObject player;
	private Vector3 pos, rot;
	private Transform thisTransform;
	private bool triggered = false;

	public float smoothTime = 0.7f;
	public float distance = 5.0f;
	void Start ()
	{
		thisTransform = this.transform;
				player = GameObject.FindGameObjectWithTag ("Player");
				if (player == null) {
						Debug.Log ("Can't find Player!");
				}

				GameObject gameControllerObject = GameObject.FindWithTag ("LogicOfTheGame");
				if (gameControllerObject != null) {
						controller = gameControllerObject.GetComponent<LogicOfTheGame> ();
				}
				if (controller == null) {
						Debug.Log ("Cannot find 'LogicOfTheGame' script");
				}
		}

	void LateUpdate(){
				{
			if (
				Mathf.Abs(thisTransform.position.x - player.transform.position.x) <= distance 
				&& 
				Mathf.Abs(thisTransform.position.z - player.transform.position.z) <= distance) {

								pos.x = Mathf.Lerp (thisTransform.position.x, player.transform.position.x, Time.deltaTime * smoothTime);
								pos.z = Mathf.Lerp (thisTransform.position.z, player.transform.position.z, Time.deltaTime * smoothTime);
								pos.y = 0;
			
								Vector3 flatVectorToplayer = player.transform.position - thisTransform.position;
								flatVectorToplayer.y = 0;
								var newRotation = Quaternion.LookRotation (flatVectorToplayer, Vector3.up);
								thisTransform.rotation = Quaternion.Lerp (thisTransform.rotation, newRotation, Time.deltaTime * 5);
			
			
								thisTransform.position = pos;
						}
				}
		}

	void OnTriggerEnter(Collider col){

		if (col.tag == "Player" && !triggered) {
			GameObject.Destroy (this.gameObject);
			controller.changePowerup(0.1f);
			triggered = true;
				}
	}
}
