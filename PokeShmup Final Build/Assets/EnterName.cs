using UnityEngine;
using System.Collections;

public class EnterName : MonoBehaviour {
	private string name;
	private LogicOfTheGame controller;

	void Start(){

		name = "";
		GameObject gameControllerObject = GameObject.FindWithTag ("LogicOfTheGame");
		if (gameControllerObject != null)
		{
			controller = gameControllerObject.GetComponent<LogicOfTheGame>();
		}
		if (controller == null)
		{
			Debug.Log ("Cannot find 'LogicOfTheGame' script");
		}
	
	}

	void OnGUI() {
		if (controller.getScore() > controller.getLowScore()) {
						name = GUI.TextField (new Rect (Screen.width / 2.5f, Screen.height / 2, Screen.width / 5, Screen.height / 10), name, 15);

						if (GUI.Button (new Rect (Screen.width / 2.5f, (Screen.height / 2) + 88, Screen.width / 5, Screen.height / 10), "Submit")) {
				controller.addNewHighScore(name);
						}
				}

	}


	
}
