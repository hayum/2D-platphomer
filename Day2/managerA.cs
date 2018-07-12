using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class managerA : MonoBehaviour {

	public int keysNum;
	public int reqKeys;
	public int levelNum;
	float timeLeft=20.0f;

	string time;
	public bool onDoor;

	// Use this for initialization
	void Start () {
		keysNum = 0;

		onDoor = false;
	}

	// Update is called once per frame
	void Update () {


		if (onDoor == true && keysNum == reqKeys && levelNum == 1) {
			SceneManager.LoadScene ("Game Win");
		}


	}

	public void incrementKeys() {
		keysNum++;
	}

	public void toggleDoorTrue() {
		Debug.Log("OnDoor");
		onDoor = true;
	}

	public void toggleDoorFalse() {
		onDoor = false;


	}
}
