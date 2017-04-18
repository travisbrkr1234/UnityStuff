using UnityEngine;
using System.Collections;

public class NumberWizard : MonoBehaviour {
	// Use this for initialization
	int max;
	int min;
	int guess;

	string instructions = "Up arrow = higher, down arrow = lower, return = equal";
	
	void Start () {
		StartGame();
	}
	
	void StartGame() {		
		max = 1000;
		min = 0;
		guess = 500;
		
		print ("========================");
		print ("Welcome to Number Wizard");
		print ("Pick a number in your head, but don't tell me!");
		
		print ("The highest number you can pick is " + max);
		print ("The lowest number you can pick is " + min);
		
		print ("Is the number higher or lower than " + guess + " ?");
		print (instructions);
		
		max = max + 1;
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown(KeyCode.UpArrow)) {
			min = guess;
			NextGuess();
		} else if (Input.GetKeyDown(KeyCode.DownArrow)) {
			max = guess;
			NextGuess();
		} else if (Input.GetKeyDown(KeyCode.Return)) {
			print ("I win!");
			StartGame ();
		}
	}
	
	void NextGuess() {
		guess = (max + min) / 2;
		print ("Higher or lower than " + guess);
		print (instructions);
	}
}
