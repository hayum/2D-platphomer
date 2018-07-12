using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorCollide : MonoBehaviour {

	manager mg;

	// Use this for initialization
	void Start () {
		mg = GameObject.Find ("SceneManager").GetComponent<manager> ();
	}

	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerEnter2D(Collider2D other) {
		Debug.Log("Here");
		if(other.gameObject.tag=="Player"){
		mg.toggleDoorTrue();
		}
	}

//	void OnTriggerExit2D(Collider2D other) {
//		if(other.gameObject.tag=="Player"){
//		mg.toggleDoorFalse ();
//		}
//	}
}
