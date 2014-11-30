using UnityEngine;
using System.Collections;

public class EnterName : MonoBehaviour {
	private string name;
	private LogicOfTheGame controller;
	private bool hasBeenPressed;
	public GameObject label;
	public GameObject winLabel;


	void Start(){
		hasBeenPressed = false;
		name = "";
		label.GetComponent<TextMesh>().text= "";
		GameObject gameControllerObject = GameObject.FindWithTag ("LogicOfTheGame");
		if (gameControllerObject != null)
		{
			controller = gameControllerObject.GetComponent<LogicOfTheGame>();
		}
		if (controller == null)
		{
			Debug.Log ("Cannot find 'LogicOfTheGame' script");
		}
	
		if(controller.didYouWin()){
			winLabel.GetComponent<TextMesh>().text= "YOU WON!";
		}
		else{
			winLabel.GetComponent<TextMesh>().text= "GAME OVER!";
		
		}
	}

	void Update(){
				if (controller.didYouWin ()) {
						winLabel.GetComponent<TextMesh> ().text = "YOU WON!";
				} else {
						winLabel.GetComponent<TextMesh> ().text = "GAME OVER!";
			
				}
		}

	void OnGUI() {
		if (controller.getScore() > controller.getLowScore()) {
			if (!hasBeenPressed){
				label.GetComponent<TextMesh>().text="You got a new high score! Enter your name!";
				name = GUI.TextField (new Rect (Screen.width / 2.5f, Screen.height / 2+175, Screen.width / 5, Screen.height / 10), name, 15);
				if (GUI.Button (new Rect (Screen.width / 2.5f, (Screen.height / 2) + 225, Screen.width / 5, Screen.height / 10), "Submit")) {
					controller.addNewHighScore(name);
					hasBeenPressed=true;
				}
		
			} else{
				label.GetComponent<TextMesh>().text="Thanks! Your score has been added!";
			
			
			
			}
		}

	}


	
}
