using UnityEngine.UI;
using UnityEngine;
using System.Collections;

public class TextController : MonoBehaviour {

	private enum State {Beginning, Cell, Mirror, Sheets, Door, Corridor, Stairs, Door2, Closet};

	private State gameState = State.Beginning;

	public Text text;
	bool isFirstTimeOnSheets = true;
	bool hasKey = false;
	bool hasDisguise = false;

	// Use this for initializationa
	void Start () {
		text.text = "Welcome, press any key to continue.";
	}
	
	// Update is called once per frame
	void Update () {

		if (gameState == State.Beginning) {
			Beginning ();
		} else if (gameState == State.Cell) {
			Cell ();
		} else if (gameState == State.Door) {
			Door ();
		} else if (gameState == State.Mirror) {
			Mirror ();
		} else if (gameState == State.Sheets) {
			Sheets ();
		} else if (gameState == State.Corridor) {
			Corridor ();
		} else if (gameState == State.Stairs) {
			Stairs ();
		} else if (gameState == State.Closet) {
			Closet ();
		}

	}

	void Closet() {
		text.text = "You find an outfit in the closet, one that would let you blend in pretty well";
		hasDisguise = true;

		if (Input.anyKeyDown) {
			gameState = State.Corridor;
		}
	}

	void Stairs() {

		if (hasDisguise) {
			text.text = "You sneak up the stairs, out the main entrance to a big castle and are on your way to freedom";
		} else {
			text.text = "You are caught and put back into your cell";
		}
		
		if (Input.anyKeyDown && !hasDisguise) {
			gameState = State.Cell;
		}
	}

	void Beginning() {

		if (Input.anyKeyDown) {
			gameState = State.Cell;
		}

	}

	void Sheets() {

		if(isFirstTimeOnSheets == true) {
			text.text = "A rat scurries out from under the sheets";
		} else {
			text.text = "Another rat comes out from under the sheets, how many are in this thing?";
		}

		if (Input.anyKeyDown) {
			gameState = State.Beginning;
			isFirstTimeOnSheets = false;
		}
	}

	void Corridor() {
		text.text = "You are now in a coridor, there are stairs leading up and a closet. \n What would you like to do? \n S: Stairs \n C: Closet \n";

		if (Input.GetKeyDown (KeyCode.S)) {
			gameState = State.Stairs;
		} else if (Input.GetKeyDown (KeyCode.C)) {
			gameState = State.Closet;
		}
	}

	void Door() {

		if(hasKey) {
			text.text = "You insert the key into the door and it opens easily. You escape unharmed!";
			if (Input.anyKeyDown) {
				gameState = State.Corridor;
			}
		} else {
			text.text = "You pull on the door but it stays put";
			if (Input.anyKeyDown) {
				gameState = State.Beginning;
			}
		}
	}

	void Mirror() {

		if (Input.anyKeyDown) {
			gameState = State.Beginning;
		}

		text.text = "You find a key behind the mirror";
		hasKey = true;
	}
		
	void Cell() {

		text.text = "You are in a cell, there is a mirror, some bundled up sheets and a door.\n\n What would you like to do\n\n M: Mirror\nS: Sheets\nD: Door";

		if (Input.GetKeyDown (KeyCode.S)) {
			gameState = State.Sheets;
		} else if (Input.GetKeyDown(KeyCode.D)) {
			gameState = State.Door;
		} else if (Input.GetKeyDown(KeyCode.M)) {
			gameState = State.Mirror;
		}
	}
}
