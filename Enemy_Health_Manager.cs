using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Health_Manager : MonoBehaviour {

	public int MaxHealth;
	public int CurrentHealth;
	public GameObject damageBurst;
	public GameObject damageNumber;
	public Transform hitPoint;
	public int damageToGive;

	// Use this for initialization
	void Start () 
	{
		CurrentHealth = MaxHealth;

	}

	// Update is called once per frame
	void Update () 
	{
		if (CurrentHealth <= 0) {

			Destroy (gameObject);
		}
	}

	public void HurtEnemy(int damageAmount)
	{
		CurrentHealth -= damageAmount;

		//Display damage burst
		Instantiate (damageBurst, transform.position, transform.rotation);

		//Display Number when damage done
		var clone = (GameObject) Instantiate(damageNumber, hitPoint.position, Quaternion.Euler (Vector3.zero));
		clone.GetComponent<FloatingNumbers> ().damageNumber = damageToGive;
	}

	public void SetMaxHealth()
	{
		CurrentHealth = MaxHealth;
	}
}
