using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraPosition : MonoBehaviour {
	private float rightBound;
	private float leftBound;
	private float topBound;
	private float bottomBound;
	private Vector3 pos;
	private Transform target;

	private Camera cam;
	private Bounds bounds;


	// Use this for initialization
	void Start()
	{
		target = GameObject.FindWithTag("Player").transform;


		foreach (SpriteRenderer spriteBounds in GameObject.Find("Background").GetComponentsInChildren<SpriteRenderer>())
		{
			bounds.Encapsulate(spriteBounds.bounds);
		}


		cam = this.gameObject.GetComponent<Camera>();
		float camVertExtent = cam.orthographicSize;
		float camHorzExtent = cam.aspect * camVertExtent;

		//Debug.Log(camVertExtent);
		//Debug.Log(camHorzExtent);
		Debug.Log(cam.aspect);
		Debug.Log(cam.orthographicSize);



		leftBound = bounds.min.x + camHorzExtent;
		rightBound = bounds.max.x - camHorzExtent;
		bottomBound = bounds.min.y + camVertExtent;
		topBound = bounds.max.y - camVertExtent;

		Debug.Log("leftBound=" + leftBound);
		Debug.Log("rightBound=" + rightBound);
		Debug.Log("bottomBound=" + bottomBound);
		Debug.Log("topBound=" + topBound);
	}

	// Update is called once per frame
	void Update()
	{


		float camX = Mathf.Clamp(target.transform.position.x, leftBound, rightBound);
		float camY = Mathf.Clamp(target.transform.position.y, bottomBound, topBound);

		//cam.transform.position = new Vector3(camX, camY, cam.transform.position.z);
		cam.transform.position = new Vector3(camX, cam.transform.position.y, cam.transform.position.z);
	}

}