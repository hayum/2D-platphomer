using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwapCharacter : MonoBehaviour {

	// character switching
	public GameObject characterOne;
	public GameObject characterTwo;
	GameObject target;

	// character position
	Vector3 pos;


	// Use this for initialization
	void Start () {
		// set character one as start
		target = characterOne;
		pos = target.transform.position;
		characterOne.SetActive (true);
		characterTwo.SetActive (false);
	}
	
	// Update is called once per frame
	void Update () {
		// input to swap characters
		if(Input.GetKeyDown(KeyCode.DownArrow)) {
			swapCharacters();
		}
	}

	// swaps between two characters
	void swapCharacters() {
		pos = target.transform.position;

		//if (characterOne == target) {
			characterOne.SetActive (false);
			characterTwo.SetActive (true);
			target = characterTwo;
			characterTwo.transform.position = pos;
//		} else {
//			characterOne.SetActive (true);
//			characterTwo.SetActive (false);
//			target = characterOne;
//			characterOne.transform.position = pos;
//		}
	}
}
