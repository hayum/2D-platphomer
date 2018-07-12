using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class manager : MonoBehaviour {

	public int keysNum;
	public int reqKeys;
	public int levelNum;
	float timeLeft=20.0f;
	public Text timeDisplay;
	string time;
	public bool onDoor;

	// Use this for initialization
	void Start () {
		keysNum = 0;

		onDoor = false;
	}
	
	// Update is called once per frame
	void Update () {
		if(timeLeft>0){ 
		timeLeft -= Time.deltaTime;
		time=timeLeft.ToString("f1");
		timeDisplay.text=time;

		if (onDoor == true && keysNum == reqKeys && levelNum == 1) {
			SceneManager.LoadScene ("Demo2");
		}
		if (onDoor == true && keysNum == reqKeys && levelNum == 2) {
			SceneManager.LoadScene ("Game Win");
		}
		}
		else{
			SceneManager.LoadScene ("Game Over");
		}
	}

	public void incrementKeys() {
		keysNum++;
	}

	public void toggleDoorTrue() {
		onDoor = true;
	}

	public void toggleDoorFalse() {
		onDoor = false;


	}
}
