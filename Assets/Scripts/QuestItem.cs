using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestItem : MonoBehaviour {

	public int questNumber;

	private QuestManager theQM;

	public string itemName;

	// Use this for initialization
	void Start () {
		theQM = FindObjectOfType<QuestManager> ();
//		if (theQM.questCompleted [questNumber]) {
//			gameObject.SetActive (false);
////		}
//		if (theQM.quests [questNumber].saveQuest != 1) {
//			gameObject.SetActive (false);
//		}
	}
	
	// Update is called once per frame
	void Update () {
		if (theQM.quests [questNumber].saveQuest != 1) {
			gameObject.SetActive (false);
		} else {
			gameObject.SetActive (true);
		}
	}

	void OnTriggerEnter2D(Collider2D other)
	{
		if (other.gameObject.name == "Player") {
			if (!theQM.questCompleted [questNumber] && theQM.quests [questNumber].gameObject.activeSelf) {
				theQM.itemCollected = itemName;
				gameObject.SetActive (false);
			}
		}
	}
}
