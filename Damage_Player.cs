using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Damage_Player : MonoBehaviour {


	public int damageTaken;
	public GameObject damageNumber;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnCollisionEnter2D (Collision2D coll)
	{
		if(coll.gameObject.tag == "Player")
		{
			coll.gameObject.GetComponent<Player_health_manager> ().HurtPlayer (damageTaken);

			var clone = (GameObject) Instantiate(damageNumber, coll.transform.position, Quaternion.Euler (Vector3.zero));
			clone.GetComponent<FloatingNumbers> ().damageNumber = damageTaken;

		}
	}
}
