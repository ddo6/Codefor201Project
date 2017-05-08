using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_health_manager : MonoBehaviour {

	public int playerMaxHealth;
	public int playerCurrentHealth;

	// Use this for initialization
	void Start () 
	{
		playerCurrentHealth = playerMaxHealth;

	}
	
	// Update is called once per frame
	void Update () 
	{
		if (playerCurrentHealth <= 0) {
			
			gameObject.SetActive (false);
		}
	}

	public void HurtPlayer(int damageAmount)
	{
		playerCurrentHealth -= damageAmount;
	}

	public void SetMaxHealth()
	{
		playerCurrentHealth = playerMaxHealth;
	}
}
