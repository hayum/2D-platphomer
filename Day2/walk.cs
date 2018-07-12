using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class walk : MonoBehaviour {

	// variable declaration
	float hVelocity;
	float vVelocity;
	public bool jumps;
	public float hSpeed = .05f;
	public float jumpVal = 1.0f;
	Rigidbody2D charRB;
	public bool lookingRight = true;
	public bool onGround;



	// animator reference variable
	Animator anim;

	// Use this for initialization
	void Start () {
		charRB = gameObject.GetComponent<Rigidbody2D> ();
		lookingRight = true;
		anim = gameObject.GetComponent<Animator> ();

		onGround = true;
	}

	// Update is called once per frame
	void Update () {
		getHorizontal ();
		getVertical ();
		move ();
	}

	void getHorizontal(){
		hVelocity = Input.GetAxis ("Horizontal") * hSpeed * Time.deltaTime;
		//	print (hVelocity);
	}

	void getVertical(){
		if (Input.GetKeyDown (KeyCode.UpArrow)) {

			if (onGround) {
				vVelocity = jumpVal;
				jumps = true;
			}
		} else {
			vVelocity = 0;
		}
	}

	void move(){
		if (hVelocity > 0 && !lookingRight) {
			flip ();
		} else if (hVelocity < 0 && lookingRight) {
			flip ();
		}

		// changes horizontal position
		charRB.position = new Vector2 (charRB.transform.position.x + hVelocity, charRB.position.y);

		// changes vertical velocity
		charRB.velocity += (Vector2.up * vVelocity);

		// updates h and v velocities in the Animator with  hVel and vVel variables.
		anim.SetFloat ("hVelocity", Mathf.Abs(hVelocity)*10);
		anim.SetFloat ("vVelocity", charRB.velocity.y);

		// updates onGround 
		anim.SetBool ("onGround", onGround);
	}

	void flip(){
		lookingRight = !lookingRight;
		Vector3 scale = transform.localScale;
		scale.x *= -1;
		transform.localScale = scale;
	}

	void OnTriggerEnter2D(Collider2D coll){
		if (coll.CompareTag ("ground")) {
			onGround = true;
			jumps = false;
		}
	}

	void OnTriggerExit2D(Collider2D coll){
		Debug.Log("Collider");
		if (coll.CompareTag ("ground")) {
			onGround = false;
		}
	}
}
