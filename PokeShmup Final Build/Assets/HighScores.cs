using UnityEngine;
using System.Collections;

public class HighScores : MonoBehaviour {

	void OnGUI() {
				if (GUI.Button (new Rect (Screen.width / 2.5f, Screen.height -100, Screen.width / 5, Screen.height / 10), "Main Menu")) {
						Application.LoadLevel (0);
				}
		}
}
