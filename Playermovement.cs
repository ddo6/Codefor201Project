using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Playermovement : MonoBehaviour {

	Rigidbody2D rbody;
	Animator anim;
	public float movespeed = 100;

	private bool attacking;
	public float attackTime;
	private float attackTimeCounter;

	// Use this for initialization
	void Start () {

		rbody = GetComponent<Rigidbody2D> ();
		anim = GetComponent<Animator> ();

	}
	
	// Update is called once per frame
	void Update () {


		Vector2 movement_vector = new Vector2 (Input.GetAxisRaw ("Horizontal"), Input.GetAxisRaw ("Vertical"));

		if (!attacking) {

		

			if (movement_vector != Vector2.zero) {
				anim.SetBool ("is_walking", true);
				anim.SetFloat ("input_x", movement_vector.x);
				anim.SetFloat ("input_y", movement_vector.y);	
			} else {
				anim.SetBool ("is_walking", false);
			}

			rbody.MovePosition (rbody.position + movement_vector * Time.deltaTime * movespeed);

			if (Input.GetKeyDown (KeyCode.X)) {
				
				attackTimeCounter = attackTime;
				attacking = true;
				rbody.velocity = Vector2.zero;
				anim.SetBool ("attack", true);
			}

		}
		if (attackTimeCounter > 0) 
		{
			attackTimeCounter -= Time.deltaTime;
		}

		if (attackTimeCounter <= 0) 
		{
			attacking = false;
			anim.SetBool ("attack", false);
		}
	}


}
