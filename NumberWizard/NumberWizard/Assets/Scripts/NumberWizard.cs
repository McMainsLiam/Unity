using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class NumberWizard : MonoBehaviour {

	public Text text;

	int min = 1;
	int max = 1000;
	int guess = 0;
	int counter = 0;
	int numGuesses = 7;

	// Use this for initialization
	void Start () {
		StartGame ();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void StartGame() {

		guess = Random.Range(min, max);
		min = 1;
		max = 1000;
		counter = 0;

		text.text = "I guess your number is " + guess;

	}

	public void guessLower() {
		if (counter > numGuesses) {
			Application.LoadLevel ("Lose");
		} else {
			max = guess;
			guess = Random.Range(min, max);
			text.text = "I guess your number is " + guess;
		}

		counter++;

	}

	public void guessHigher() {
		if (counter > numGuesses) {
			Application.LoadLevel ("Lose");
		} else {
			min = guess;
			guess = Random.Range(min, max);
			text.text = "I guess your number is " + guess;
		}

		counter++;

	}

	public void correctGuess() {
		Application.LoadLevel ("Win");
	}
}
