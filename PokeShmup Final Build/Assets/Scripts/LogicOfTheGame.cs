using UnityEngine;
using System.Collections;
using System.Text;
using System.IO;
using System;  

public class LogicOfTheGame : MonoBehaviour {


	public GUIText scoreText;
	public GUIText livesText;
	public GUIText powerupText;
	public GameObject EnemySpawner;

	public static int score;
	public static int lives;
	public static float powerUp;
	private static int lowestHS;
	private static bool gameWon;
	private static bool gameOver, level1Over;

	private GameObject bullets;

	//Marcus: These are variables used for fading in
	//and out upon achieving a Game Over. Not sure 
	//where to put this.
	public GameObject fader, fader2;
	public float speed;
	private Color faderColor, faderColor2;
	private string[] highscores;
	private int[] hsNumbers;
	private string[] names;
	private string hs, namesString;
	private int count;


	// Use this for initialization


	void Start () {
		Load ("highscores.txt");
		count = 0;

		//Load ("highscores.txt");

		if (Application.loadedLevelName == "Level 1") {
						powerUp = 0.0f;
						lowestHS=0;
						score = 0;
						lives=10;
						gameWon=false;
				}
		bullets = GameObject.Find ("Bullets");
				if (lives == 0) {
						lives = 10;
				}gameOver = false;
		level1Over = false;    
				scoreText.text = "Score: " + score;
				livesText.text = "Lives: " + lives;
		
				//Marcus: Sorry, don't know where to put this,
				//but this is for the fade in and fade out effects
				//upon achieving a Game Over.

				faderColor = fader.renderer.material.color;
				faderColor2 = fader2.renderer.material.color;
	}
	
	// Update is called once per frame
	void Update () {

				//Marcus: SORRY SAMANTHA I DON'T KNOW WHERE TO 
				//PUT THIS CODE PLS FORGIVE ME.

				
			
			if (Application.loadedLevelName == "Level 1") {
			
						if (gameOver && faderColor.a + speed >= 0 && faderColor.a + speed <= 255) {
								faderColor.a += speed;
								fader.renderer.material.SetColor ("_Color", faderColor);}
						if (level1Over && faderColor2.a + speed >= 0 && faderColor2.a + speed <= 255) {
								faderColor2.a += speed;
								fader2.renderer.material.SetColor ("_Color", faderColor2);}
			
						if ((fader.renderer.material.GetColor ("_Color").a + speed) >= 1.0f) {
								Application.LoadLevel ("GameOver");
			}
						if ((fader2.renderer.material.GetColor ("_Color").a + speed) >= 2.0f) {
								Application.LoadLevel ("Level 2");
						}
				}

		
				if (Application.loadedLevelName == "GameOver") {
						if (fader.renderer.material.GetColor ("_Color").a >= 0.0f) {
								faderColor.a -= speed;
								fader.renderer.material.SetColor ("_Color", faderColor);
						}
						if (fader.renderer.material.GetColor ("_Color").a <= 0.0f) {
				
								if (Input.GetKeyDown (KeyCode.JoystickButton9) 
										|| Input.GetKeyDown (KeyCode.JoystickButton8) 
										|| Input.GetKeyDown ("r")) {
										Application.LoadLevel ("MainMenu");
								}
						}
				}	

			if (Application.loadedLevelName == "Level 2") {
			
				if (gameOver && faderColor.a + speed >= 0 && faderColor.a + speed <= 255) {
					faderColor.a += speed;
					fader.renderer.material.SetColor ("_Color", faderColor);}
			
				if ((fader.renderer.material.GetColor ("_Color").a + speed) >= 1.0f) {
					Application.LoadLevel ("GameOver");
				}
				
		}
				
				//Marcus: THAT'S ALL OF IT. IDK YOU COULD PROBABLY
				//OPTIMIZE IT BETTER BUT THAT'S WHAT I HAD.
		UpdatePowerup ();
	}


	public void AddScore (int newScoreValue)
	{
		score += newScoreValue;
		UpdateScore ();
	}

	public void UpdatePowerup(){
		
		powerupText.text = "Power: " + getPowerup ().ToString ();

		powerupText.text =string.Format ( "Power: {0:f1}", getPowerup());
		}

	public void UpdateScore ()
	{
		scoreText.text = "Score: " + score;
	}

	public void UpdateLives ()
	{
		livesText.text = "Lives: " + lives;
	}

	public bool LoseLife(){
		Debug.LogError ("Lives equals: " + lives);
				if (getPowerup () > 1.0f) {
						changePowerup (-1.0f);
						Debug.Log ("PowerUp lost");
						ClearBullets (bullets.transform);
				} else if (lives > 0 && getPowerup () < 1.0f) {
						lives--;
						Debug.Log ("Life lost.");
						ClearBullets (bullets.transform);
				} else if (lives == 0 && getPowerup () < 1.0f) {
						UpdateLives ();
						gameOver = true;
						//EnemySpawner.SetActive(false);
						foreach (Transform child in EnemySpawner.transform)
								child.gameObject.SetActive (false);
						EnemySpawner.SetActive (false);
						return true;

				}
				UpdateLives ();
				return false;

	
		}

	public Transform ClearBullets(Transform transform){
		foreach (Transform child in transform) {
			GameObject.Destroy (child.gameObject);
		}
		return transform;
		}

	public bool clearScreen(){
				return gameOver;
		}
	public int getScore(){
		return score;
		}

	public void setPowerup(float value){
		powerUp = value;
	}

	public float getPowerup(){
		float returnValue = powerUp;
		return returnValue;
	}

	public void setLevel1Over(){
		level1Over=true;
	
	}

	public void changePowerup(float change){
		if ((powerUp + change <= 4.0f) && (powerUp + change >= 0.0f)){
		powerUp += change;
		}
	}

	private bool Load(string fileName)
	{
		// Handle any problems that might arise when reading the text
		try
		{
			string line;

			// Create a new StreamReader, tell it which file to read and what encoding the file
			// was saved as
			StreamReader theReader = new StreamReader(fileName, true);

			
			// Immediately clean up the reader after this block of code is done.
			// You generally use the "using" statement for potentially memory-intensive objects
			// instead of relying on garbage collection.
			// (Do not confuse this with the using directive for namespace at the 
			// beginning of a class!)
			using (theReader)
			{
				// While there's lines left in the text file, do this:
				do
				{
					line = theReader.ReadLine();
					//Debug.LogError(line);
					if (line != null)
					{
						// Do whatever you need to do with the text line, it's a string now
						// In this example, I split it into arguments based on comma
						// deliniators, then send that array to DoStuff()
						if(count<1){
							highscores = line.Split(',');
							hsNumbers=new int[highscores.Length];

							count=count+1;
							//Debug.LogError("Count is: "+count);
						}
						else{
							names=line.Split(',');
							
						}
					}
				}
				while (line != null);
				//Debug.LogError("The array length is: "+highscores.Length);
				for(int i=0; i<highscores.Length; i++){
					//Debug.LogError("In the while loop. i= "+highscores[i]);
					hsNumbers[i]=int.Parse(highscores[i]);
					if(lowestHS==0 || lowestHS>hsNumbers[i]){
						lowestHS=hsNumbers[4];

					}
					hs=hs+highscores[i]+"\n";
					//Debug.LogError("In the while loop. hs= "+hs);
					namesString=namesString+names[i]+"\n";
					
				}
				Debug.LogError("LowestScore is: "+lowestHS);
				// Done reading, close the reader and return true to broadcast success    
				theReader.Close();

				return true;
			}
		}
		
		// If anything broke in the try block, we throw an exception with information
		// on what didn't work
		catch (Exception e)
		{
			
			Console.WriteLine("{0}\n", e.Message);
			return false;
		}
		
	}


	public int getLowScore(){
		return lowestHS;

	}


	public bool addNewHighScore(String name){
		string[] lines=new string[2];
		string nums = "";
		string people = "";
		bool added = false;
		int total = 0;
		Debug.LogError ("Adding person's HS: " + name);
		for (int i=0; i<5; i=i+1) {
			Debug.LogError("Number in array is: "+hsNumbers[i]);
			if(score>hsNumbers[i] && !added) {
				nums=nums+score;
				people=people+name;
				i--;
				added=true;
				total++;
			}
			else{
				nums=nums+hsNumbers[i];
				people=people+names[i];
				total++;
	
			}

			if(!(i+1==5)){
				nums=nums+",";
				people=people+",";
			}
			if(total==5)
				i=5;
//			if(i<hsNumbers.Length && hsNumbers[i]>score){
//				nums=nums+hsNumbers[i]+",";
//				people=people+names[i]+",";
//			}
//
//			if(i<hsNumbers.Length-2 && hsNumbers[i]<score && !added) {
//				nums=nums+score+",";
//				people=people+name+",";
//				nums=nums+hsNumbers[i]+",";
//				people=people+names[i]+",";
//				added=true;
//			}
//			if(i==hsNumbers.Length-2 && hsNumbers[i]<score && !added) {
//				nums=nums+score+",";
//				people=people+name+",";
//				nums=nums+hsNumbers[i]+",";
//				people=people+names[i]+",";
//				added=true;
//			}
//
//
//
//			if(i==hsNumbers.Length-1 && hsNumbers[i]<score && !added) {
//				nums=nums+score;
//				people=people+name;
//				added=true;
//			}
//				
//
//				Debug.LogError(nums+" "+people);
//	
			
	}
		lines [0] = nums;
		lines [1] = people;
		System.IO.File.WriteAllLines("highscores.txt", lines);
		Load ("highscores.txt");
		return true;
	
	}


	public void setWin(){
		gameWon = true;
		gameOver = true;
	}

	public bool didYouWin(){
		return gameWon;
	}
}