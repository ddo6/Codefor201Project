using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestTrigger : MonoBehaviour {

	private QuestManager theQM;
	public int QuestNumber;
	public bool startQuest;
	public bool endQuest;


	// Use this for initialization
	void Start () {
		theQM = FindObjectOfType<QuestManager> ();

		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerEnter2D(Collider2D other)
	{
		if (other.gameObject.name == "Player") 
		{
			if (!theQM.questCompleted [QuestNumber]) 
			{
				if (startQuest && !theQM.quests [QuestNumber].gameObject.activeSelf)
				{
					theQM.quests [QuestNumber].gameObject.SetActive (true);
					theQM.quests [QuestNumber].StartQuest ();
				}

				if (endQuest && theQM.quests [QuestNumber].gameObject.activeSelf)
				{
					theQM.quests [QuestNumber].EndQuest ();

				}
			}
		}
	}
}
