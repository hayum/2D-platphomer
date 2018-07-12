using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyCollide : MonoBehaviour {

	manager mg;
	//public GameObject keyBlock;

	// Use this for initialization
	void Start () {
		mg = GameObject.Find ("SceneManager").GetComponent<manager> ();
	}

	// Update is called once per frame
	void Update () {

	}

	void OnTriggerEnter2D(Collider2D coll) {
		Debug.Log("Hit");
		if (coll.CompareTag ("projectile")) {
			Destroy (gameObject);
			Destroy (coll.gameObject);
			//Destroy (keyBlock);
		}
	}
}
