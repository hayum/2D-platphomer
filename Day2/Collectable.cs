using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectable : MonoBehaviour {

		manager mg;

		// Use this for initialization
		void Start () {
			mg = GameObject.Find ("SceneManager").GetComponent<manager> ();
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
