using UnityEngine;
using System.Collections;

public class GameController : MonoBehaviour
{
	public GameObject hazard;
	public GameObject hazard2;
	public GameObject hazard3;
	public GameObject hazard4;
	public GameObject enemyShip;
	public GameObject powerup;
	public Vector3 spawnValues;
	public int hazardCount;
	public float spawnWait;
	public float startWait;
	public float waveWait;
	
	public GUIText scoreText;
	public GUIText restartText;
	public GUIText gameOverText;
	public GUIText lifeText;
	
	private bool gameOver;
	private bool restart;
	private int score;
	private int lives=3;
	
	void Start ()
	{
		gameOver = false;
		restart = false;
		restartText.text = "";
		gameOverText.text = "";
		lifeText.text = "Lives: 3";
		score = 0;
		UpdateScore ();
		StartCoroutine (SpawnWaves ());
	}
	
	void Update ()
	{
		if (restart)
		{
			if (Input.GetKeyDown (KeyCode.R))
			{
				Application.LoadLevel (Application.loadedLevel);
			}
		}
	}
	
	IEnumerator SpawnWaves ()
	{
		yield return new WaitForSeconds (startWait);
		while (true)
		{
			for (int i = 0; i < hazardCount; i++)
			{
				Vector3 spawnPosition = new Vector3 (Random.Range (-spawnValues.x, spawnValues.x), spawnValues.y, spawnValues.z-2);
				Quaternion spawnRotation = Quaternion.identity;
				int rand = Random.Range(0, 8);
				switch(rand)
				{
				case 0:
				case 1:
					Instantiate (hazard4, spawnPosition, new Quaternion(0,180,0,0));
					break;
				case 2:
					break;
				case 3:
					Instantiate (hazard4, spawnPosition, new Quaternion(0,180,0,0));
					break;
				case 4:
				case 5:

					break;
				case 6:
					Instantiate (enemyShip, spawnPosition, spawnRotation);
					break;
				default:
					Instantiate (powerup, spawnPosition, spawnRotation);
					break;
				}
				yield return new WaitForSeconds (spawnWait);
			}
			yield return new WaitForSeconds (waveWait);
			
			if (gameOver)
			{
				restartText.text = "Press 'R' for Restart";
				restart = true;
				break;

			}
		}
	}
	
	public void AddScore (int newScoreValue)
	{
		score += newScoreValue;
		UpdateScore ();
	}
	
	void UpdateScore ()
	{
		scoreText.text = "Score: " + score;
	}

	public bool LoseLife() 
	{
		if (lives != 0) {

			lives = lives - 1;
			lifeText.text = "Lives: " + lives;

				if (lives == 0) {

					GameOver ();
					return true;
					}
			return false;
		}
		return true;
	}
	
	public void GameOver ()
	{
		gameOverText.text = "Game Over!";
		gameOver = true;
	}
}