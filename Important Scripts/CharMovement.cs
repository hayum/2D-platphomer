using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharMovement : MonoBehaviour {

	// variable declaration
	float hVelocity;
	float vVelocity;
	public int jumps = 0;
	public float hSpeed = .05f;
	public float jumpVal = 1.0f;
	Rigidbody2D charRB;
	public bool lookingRight = true;
	public bool onGround;

	// projectile variable declarations
	public GameObject projectilePrefab;
	GameObject projectileInstance;
	public float posOffset;

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
		//getShoot ();
		move ();
	}

	void getHorizontal(){
		hVelocity = Input.GetAxis ("Horizontal") * hSpeed * Time.deltaTime;
//	print (hVelocity);
	}

	void getVertical(){
		if (Input.GetKeyDown (KeyCode.UpArrow)) {
			// triple jump
			if (jumps == 2) {
				vVelocity = jumpVal / 2f;
				jumps++;
			}
			// for double jump
			if (jumps == 1) {
				vVelocity = jumpVal;
				jumps++;
			}
			// for regular jump
			if (onGround) {
				vVelocity = jumpVal;
				jumps++;
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
			jumps = 0;
		}
	}

	void OnTriggerExit2D(Collider2D coll){
		Debug.Log("Collider");
		if (coll.CompareTag ("ground")) {
			onGround = false;
		}
	}

	void getShoot(){
		if(Input.GetKeyDown(KeyCode.V)){
			if (lookingRight) {
				Vector3 projPosition = new Vector3(gameObject.transform.position.x + posOffset, gameObject.transform.position.y, gameObject.transform.position.z);
				projectileInstance = Instantiate (projectilePrefab, projPosition, Quaternion.identity) as GameObject;
			} else {
				Vector3 projPosition = new Vector3(gameObject.transform.position.x - posOffset, gameObject.transform.position.y, gameObject.transform.position.z);
				projectileInstance = Instantiate (projectilePrefab, projPosition, Quaternion.Euler(Vector3.down * 180f))  as GameObject;
			}
		}
	}

		


}

