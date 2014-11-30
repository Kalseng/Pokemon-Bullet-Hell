using UnityEngine;
using System.Collections;
using System.IO;
using System;
using System.Text;

 

public class HighScores : MonoBehaviour {
	public GUIText scores;
	public GUIText nameList;
	private string[] highscores;
	private int[] hsNumbers;
	private string[] names;
	private string hs, namesString;
	private int count;

	void Start() {
		count = 0;
		hsNumbers = new int[5];
		Load ("highscores.txt");
		scores.text = hs;
		nameList.text = namesString;
	
	}
	void OnGUI() {
				if (GUI.Button (new Rect (Screen.width / 2.5f, Screen.height -100, Screen.width / 5, Screen.height / 10), "Main Menu")) {
						Application.LoadLevel (0);
				}
		}

	private bool Load(string fileName)
	{
		// Handle any problems that might arise when reading the text
		try
		{
			string line;
			Debug.LogError("Got to the load");
			// Create a new StreamReader, tell it which file to read and what encoding the file
			// was saved as
			StreamReader theReader = new StreamReader(fileName, true);
			Debug.LogError("Loaded the stuff");
			
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
					Debug.LogError(line);
					if (line != null)
					{
						// Do whatever you need to do with the text line, it's a string now
						// In this example, I split it into arguments based on comma
						// deliniators, then send that array to DoStuff()
						if(count<1){
						highscores = line.Split(',');
							foreach(var item in highscores)
							{
								Debug.LogError(item.ToString());
							}
							count=count+1;
							Debug.LogError("Count is: "+count);
						}
						else{
							names=line.Split(',');
						
						}
					}
				}
				while (line != null);
				Debug.LogError("The array length is: "+highscores.Length);
				for(int i=0; i<highscores.Length; i++){
					Debug.LogError("In the while loop. i= "+highscores[i]);
					hsNumbers[i]=int.Parse(highscores[i]);
					hs=hs+highscores[i]+"\n";
					Debug.LogError("In the while loop. hs= "+hs);
					namesString=namesString+names[i]+"\n";

				}
				// Done reading, close the reader and return true to broadcast success    
				theReader.Close();
				foreach(var item in hsNumbers)
				{
					Debug.LogError(item.ToString());
				}
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
}
