using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestTrigger : MonoBehaviour {

	private QuestManager theQM;

	public int questNumber;

	public bool startQuest;
	public bool endQuest;

//	private QuestObject[] theQO;

	// Use this for initialization
	void Start () {
		theQM = FindObjectOfType<QuestManager> ();
//		theQO = FindObjectsOfType<QuestObject> ();
		if (theQM.quests[questNumber].saveQuest == 1 || theQM.quests[questNumber].saveQuest == 2) {
			gameObject.SetActive (false);
		}
//		if (theQO [questNumber].saveQuest == 1 || theQO [questNumber].saveQuest == 2) {
//			gameObject.SetActive (false);
//		}
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerEnter2D (Collider2D other)
	{
		if (other.gameObject.name == "Player") {
			if (!theQM.questCompleted [questNumber]) {
				if (startQuest && !theQM.quests[questNumber].gameObject.activeSelf) {
					theQM.quests [questNumber].gameObject.SetActive (true);
					theQM.quests [questNumber].StartQuest ();
					theQM.quests [questNumber].saveQuest = 1;
				}
				if (endQuest && theQM.quests [questNumber].gameObject.activeSelf) {
					theQM.quests [questNumber].EndQuest ();
					theQM.quests [questNumber].saveQuest = 2;
				}
			}
		}
	}
}
