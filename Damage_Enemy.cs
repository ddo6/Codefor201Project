using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Damage_Enemy : MonoBehaviour {

	public int damageToGive;
	//public GameObject damageBurst;
	public GameObject damageNumber;
	public Transform hitPoint;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerEnter2D(Collider2D coll)
	{
		
		if (coll.gameObject.tag == "Enemy") 
		{

			//Destroy (coll.gameObject);
			coll.gameObject.GetComponent<Enemy_Health_Manager>().HurtEnemy(damageToGive);
			//Instantiate (damageBurst, transform.position, transform.rotation);
			var clone = (GameObject) Instantiate(damageNumber, hitPoint.position, Quaternion.Euler (Vector3.zero));
			clone.GetComponent<FloatingNumbers> ().damageNumber = damageToGive;

		}
	}
}
