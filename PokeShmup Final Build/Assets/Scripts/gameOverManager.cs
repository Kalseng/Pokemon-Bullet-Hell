using UnityEngine;
using System.Collections;

public class gameOverManager : MonoBehaviour {
	
	public GameObject fader;
	public float speed;

	private Color faderColor;
	private LogicOfTheGame gameController;

	// Use this for initialization
	void Start () {
		faderColor  = fader.renderer.material.color;

		GameObject gameControllerObject = GameObject.FindGameObjectWithTag ("LogicOfTheGame");
		if (gameControllerObject != null)
		{
			gameController = gameControllerObject.GetComponent <LogicOfTheGame>();
		}
		if (gameController == null)
		{
			Debug.Log ("Cannot find 'GameController' script");
		}
	}
	
	// Update is called once per frame
	void Update () {
		
		if (faderColor.a + speed >= 0 && faderColor.a + speed <= 255 && Application.loadedLevelName == "GameOver") {
			faderColor.a += speed;
			fader.renderer.material.SetColor ("_Color", faderColor);
		}
		if (Application.loadedLevelName == "Prototype") {
			
			if (faderColor.a + speed >= 0 && faderColor.a + speed <= 255) {
				faderColor.a += speed;
				fader.renderer.material.SetColor ("_Color", faderColor);
			}
			
			if(faderColor.a + speed >= 255){
				Application.LoadLevel("GameOver");
			}
		}
		
		if (Input.GetKeyDown ("r") && Application.loadedLevelName == "GameOver") {
			Application.LoadLevel ("Prototype");
		}
		
	}
}
