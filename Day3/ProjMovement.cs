using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjMovement : MonoBehaviour {

	public float hspeed;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		gameObject.transform.position += gameObject.transform.right * hspeed * Time.deltaTime;
		Destroy(this.gameObject, 2f);
	}
}
