using UnityEngine;
using System.Collections;

public class voltorbSpawner : MonoBehaviour {


	public GameObject voltorb;
	public GameObject bellSprout;
	public GameObject pidgey;
	public GameObject victini;

	public Transform VictiniSpawn;

	private Transform t;

	private LogicOfTheGame controller;
	private bool score200, score400, score600, score800, score1000;
	private bool victiniSpawned;
	private GameObject enemyFolder;

	public GUIText win;

	// Use this for initialization
	void Start () {

				enemyFolder = GameObject.Find ("Enemy Folder");

				InvokeRepeating ("spawn", 3.0f, 6f);
				InvokeRepeating ("spawn", 4.0f, 5f);

				GameObject gameControllerObject = GameObject.FindWithTag ("LogicOfTheGame");
				if (gameControllerObject != null) {
						controller = gameControllerObject.GetComponent<LogicOfTheGame> ();
				}
				if (controller == null) {
						Debug.Log ("Cannot find 'LogicOfTheGame' script");
				}
				score200 = false;
				score400 = false;
				score600 = false;
				score800 = false;
				score1000 = false;
				victiniSpawned = false;

		}
	
	// Update is called once per frame
	void Update () {
				if (controller.getScore () >= 200 && controller.getScore () < 400 && !score200) {
						score200 = true;
						InvokeRepeating ("spawn", 2.0f, 6.0f);
				}

				if (controller.getScore () >= 450 && controller.getScore () < 600 && !score400) {
						score400 = true;
						InvokeRepeating ("spawn", 1.0f, 6.0f);
				}

				if (controller.getScore () >= 800 && controller.getScore () < 400 && !score600) {
						score600 = true;
						InvokeRepeating ("spawn", 2.0f, 6.0f);
				}

				if (controller.getScore () >= 1000 && !score1000 && !victiniSpawned) {
						CancelInvoke ();
						if (enemyFolder.transform.childCount == 0) {
								t = ((GameObject)Instantiate (victini, new Vector3 (0, 0, 22), VictiniSpawn.rotation)).transform;
								t.parent = enemyFolder.transform;
								victiniSpawned = true;
						}

				}

				if (victiniSpawned && enemyFolder.transform.childCount == 0) {
						win.text = ("YOU'VE WON!");
				}
		}

	void voltorbSpawn( float offset){
				t = ((GameObject)Instantiate (voltorb, transform.position + new Vector3 (offset, 0, 0), transform.rotation)).transform;
				t.parent = enemyFolder.transform;
		}

	void bellSproutSpawn( float offset){
				t = ((GameObject)Instantiate (bellSprout, transform.position + new Vector3 (offset, 0, 0), transform.rotation)).transform;
				t.parent = enemyFolder.transform;
		}

	void pidgeySpawn( float offset){
				t = ((GameObject)Instantiate (pidgey, transform.position + new Vector3 (offset, 0, 0), transform.rotation)).transform;
				t.parent = enemyFolder.transform;
		}

	void spawn(){
				//When Pidgey is done, change 67 to 100
				int randomNumber = Random.Range (0, 100);
				int offset = Random.Range (0, 110);
				if (randomNumber > 0 && randomNumber < 33)
						voltorbSpawn (offset);
				else if (randomNumber >= 33 && randomNumber < 66)
						bellSproutSpawn (offset);
				else if (randomNumber >= 66 && randomNumber < 100)
						pidgeySpawn (offset);
		}


}