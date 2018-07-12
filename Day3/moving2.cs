using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class moving2 : MonoBehaviour {
	float amount;
	public int length;
	// Use this for initialization
	void Start () {
		amount=-0.03f;
	}
	
	// Update is called once per frame
	void Update () {
//		Debug.Log(Time.frameCount);
		if(Time.frameCount%120==0){
			amount=-amount;
			Vector3 scale = transform.localScale;
			scale.x *= -1;
			transform.localScale = scale;
		}
		transform.Translate(amount,0f, 0f);

	}
}
