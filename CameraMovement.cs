using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour {

	public Transform target;
	Camera myCam;
	public float mspeed = 0.1f;

	// Use this for initialization
	void Start () {
		myCam = GetComponent<Camera> ();

	}
	
	// Update is called once per frame
	void Update () {
		
		if (target) {
			transform.position = Vector3.Lerp (transform.position, target.position, mspeed)+new Vector3(0, 0, -10f);
		}
		
	}
}
