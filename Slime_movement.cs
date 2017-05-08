using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Slime_movement : MonoBehaviour {

	public float moveSpeed;

	private Rigidbody2D myRigidbody;

	private bool moving;

	public float timeBetweenMove;
	private float timebetweenMoveCounter;
	public float timeToMove;
	private float timeToMoveCounter;

	private Vector3 movedirection;

	public float waitToReload;
	private bool reloading;
	private GameObject player;

	// Use this for initialization
	void Start () {
		myRigidbody = GetComponent<Rigidbody2D> ();

		//timebetweenMoveCounter = timeBetweenMove;
		//timeToMoveCounter = timeToMove;
		timebetweenMoveCounter = Random.Range (timeBetweenMove * 0.75f, timeBetweenMove * 1.25f);
		timeToMoveCounter = Random.Range (timeToMove * 0.75f, timeBetweenMove * 1.25f);
		reloading = false;

	} 

	// Update is called once per frame
	void Update () {

		if (moving) 
		{
			timeToMoveCounter -= Time.deltaTime;
			myRigidbody.velocity = movedirection;

			if (timeToMoveCounter < 0f) 
			{
				moving = false;
				//timebetweenMoveCounter = timeBetweenMove; 
				timebetweenMoveCounter = Random.Range (timeBetweenMove * 0.75f, timeBetweenMove * 1.25f);
			}


		} else {
			timebetweenMoveCounter -= Time.deltaTime;
			myRigidbody.velocity = Vector2.zero;

			if (timebetweenMoveCounter < 0f) 

			moving = true;
			//timeToMoveCounter = timeToMove;
			timeToMoveCounter = Random.Range (timeToMove * 0.75f, timeBetweenMove * 1.25f);

			movedirection = new Vector3(Random.Range (-1f, 1f) * moveSpeed, Random.Range (-1f, 1f) * moveSpeed, 0f);
		}

		if (reloading) {
			print ("reloading why?");
			waitToReload -= Time.deltaTime;
			if (waitToReload < 0) 
			{
				SceneManager.LoadScene (SceneManager.GetActiveScene ().buildIndex);
				player.SetActive (true);

			}
		}

	}





}