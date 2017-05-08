using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC_Movement : MonoBehaviour {

	public float moveSpeed;
	private Rigidbody2D rigi;
	Animator anim;
	public bool isWalking;
	public float walkTime;
	private float walkCounter;
	public float waitTime;
	private float waitCounter;

	private int WalkDirection;

	public Collider2D walkZone;
	private Vector2 minWalkPoint;
	private Vector2 maxWalkPoint;
	private bool hasWalkZone;
	private Vector3 MoveDirection;
	public bool canMove;
	private DialogueManager theDM;


	// Use this for initialization
	void Start () {

		canMove = true;
		theDM = FindObjectOfType<DialogueManager> ();

		rigi = GetComponent <Rigidbody2D>();
		anim = GetComponent<Animator> ();

		waitCounter = waitTime;
		walkCounter = walkTime;

		ChooseDirection ();

		if (walkZone != null) 
		{
			minWalkPoint = walkZone.bounds.min;
			maxWalkPoint = walkZone.bounds.max;
			hasWalkZone = true;
		}
		
	}
	
	// Update is called once per frame
	void Update () {

		if (!theDM.dialogActive) 
		{
			canMove = true;
		}

		if (!canMove) 
		{
			rigi.velocity = Vector2.zero;
			return;
		}

		Vector2 movement_vector = new Vector2 (Input.GetAxisRaw ("Horizontal"), Input.GetAxisRaw ("Vertical"));


		if (isWalking) 
		{
			anim.SetBool ("isWalking", true);
			rigi.velocity = MoveDirection;
			anim.SetFloat ("inputX", movement_vector.x);
			anim.SetFloat ("inputY", movement_vector.y);
			walkCounter -= Time.deltaTime;


			switch (WalkDirection) 
			{
			case 0:
				anim.SetFloat ("inputX", movement_vector.x);
				anim.SetFloat ("inputY", movement_vector.y);	
				rigi.MovePosition (rigi.position + movement_vector * Time.deltaTime * moveSpeed);

				if (hasWalkZone && transform.position.y > maxWalkPoint.y) {
					isWalking = false;
					waitCounter = waitTime;
				}
				break;

			case 1:
				anim.SetFloat ("inputX", movement_vector.x);
				anim.SetFloat ("inputY", movement_vector.y);	
				rigi.MovePosition (rigi.position + movement_vector * Time.deltaTime * moveSpeed);

				if (hasWalkZone && transform.position.x > maxWalkPoint.x) {
					isWalking = false;
					waitCounter = waitTime;
				}
				break;

			case 2:
				anim.SetFloat ("inputX", movement_vector.x);
				anim.SetFloat ("inputY", movement_vector.y);	
				rigi.MovePosition (rigi.position + movement_vector * Time.deltaTime * moveSpeed);


				if (hasWalkZone && transform.position.y < minWalkPoint.y) {
					isWalking = false;
					waitCounter = waitTime;
				}
				break;

			case 3:
				anim.SetFloat ("inputX", movement_vector.x);
				anim.SetFloat ("inputY", movement_vector.y);	
				rigi.MovePosition (rigi.position + movement_vector * Time.deltaTime * moveSpeed);

				if (hasWalkZone && transform.position.x < minWalkPoint.x) {
					isWalking = false;
					waitCounter = waitTime;
				}
				break;
				
			}

			if (walkCounter < 0) 
			{
				isWalking = false;
				waitCounter = waitTime;
			}
		} 
		else 
		{
			anim.SetBool ("isWalking", false);
			waitCounter -= Time.deltaTime;
			rigi.velocity = Vector2.zero;

			if (waitCounter < 0) 
			{
				ChooseDirection ();
			}


		}
	}

	public void ChooseDirection()
	{
		WalkDirection = Random.Range (0, 4);
		isWalking = true;
		walkCounter = walkTime;
	}
}
