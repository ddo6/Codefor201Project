using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Warp : MonoBehaviour {

	public Transform warpTarget;
	public GameObject player;

	void OnTriggerEnter2D(Collider2D coll) 
	{
		player.transform.position = warpTarget.position;
	}
}
