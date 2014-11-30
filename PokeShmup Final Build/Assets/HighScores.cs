using UnityEngine;
using System.Collections;
using System.IO;
using System;
using System.Text;

 

public class HighScores : MonoBehaviour {
	public GUIText scores;
	private int[] highscores;
	private string[] names;
	private string hs;
	private bool name;

	void Start() {
		name = false;
		Load ("highscores.txt");
		scores.text = hs;
	
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
						if(!name){
						highscores = line.Split(',');
							names=true;
						}
						else{
							names=line.Split(',');
						
						}
					}
				}
				while (line != null);
				int i=0;
				while(highscores[i]!=null){
					Convert.ToInt32(highscores[i]);
					hs=hs+highscores[i]+"\n";
					i++;
				}
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
}
