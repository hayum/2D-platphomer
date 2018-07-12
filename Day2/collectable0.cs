using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class collectable0 : MonoBehaviour {

	managerA mg;

	// Use this for initialization
	void Start () {
		mg = GameObject.Find ("SceneManager").GetComponent<managerA> ();
	}

	// Update is called once per frame
	void Update () {

	}

	void OnTriggerEnter2D(Collider2D coll) {
		if (coll.CompareTag ("Player")) {
			Destroy (gameObject);
			mg.incrementKeys ();
		}
	}
}
