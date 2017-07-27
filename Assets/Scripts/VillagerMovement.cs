﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VillagerMovement : MonoBehaviour {

	public float moveSpeed;
	private Vector2 minWalkPoint;
	private Vector2 maxWalkPoint;

	private Rigidbody2D myRigidbody;

	public bool isWalking;

	public float walkTime;
	private float walkCounter;
	public float waitTime;
	private float waitCounter;

	private int walkDirection;

	public Collider2D walkZone;
	private bool hasWalkZone;

	public bool canMove;
	private DialogueManager theDM;

	public bool tutorialNPC;
	private bool tutorialNPCEnd;

	public bool questNPC;
	private bool activateQuestTrigger;

	private QuestManager theQM;

	public int questNumber;

	public bool startQuest;
	public bool endQuest;

	public GameObject questMarker;

	// Use this for initialization
	void Start () {
		myRigidbody = GetComponent<Rigidbody2D> ();
		theDM = FindObjectOfType<DialogueManager> ();

		waitCounter = waitTime;
		walkCounter = walkTime;

		ChooseDirection ();

		if (walkZone != null) {
			minWalkPoint = walkZone.bounds.min;
			maxWalkPoint = walkZone.bounds.max;
			hasWalkZone = true;
		}

		if (tutorialNPC) {
			canMove = false;
			tutorialNPCEnd = false;
		} else {
			canMove = true;
			tutorialNPCEnd = true;
		}
	}
	
	// Update is called once per frame
	void Update () {

		if (!theDM.dialogueActive && !tutorialNPC) {
			canMove = true;
		}

		if (theDM.dialogueActive && tutorialNPC) {
			tutorialNPCEnd = true;
		}

		if (tutorialNPCEnd && tutorialNPC) {
			tutorialNPC = false;
			walkDirection = 0;
		}

		if (!theDM.dialogueActive && questNPC) {
			questMarker.SetActive (true);
		}

		if (theDM.dialogueActive && questNPC) {
			activateQuestTrigger = true;
			StartQuest ();
		}

		if (activateQuestTrigger && questNPC) {
			questNPC = false;
			questMarker.SetActive (false);
		}

		if (!canMove) {
			myRigidbody.velocity = Vector2.zero;
			return;
		}

		if (isWalking) {
			walkCounter -= Time.deltaTime;

			switch (walkDirection) {
			case 0:
				myRigidbody.velocity = new Vector2 (0f, moveSpeed);
				if (hasWalkZone && transform.position.y > maxWalkPoint.y) {
					isWalking = false;
					waitCounter = waitTime;
				}
				break;
			case 1:
				myRigidbody.velocity = new Vector2 (moveSpeed, 0f);
				if (hasWalkZone && transform.position.x > maxWalkPoint.x) {
					isWalking = false;
					waitCounter = waitTime;
				}
				break;
			case 2:
				myRigidbody.velocity = new Vector2 (0f, -moveSpeed);
				if (hasWalkZone && transform.position.y < maxWalkPoint.y) {
					isWalking = false;
					waitCounter = waitTime;
				}
				break;
			case 3:
				myRigidbody.velocity = new Vector2 (-moveSpeed, 0f);
				if (hasWalkZone && transform.position.x < maxWalkPoint.x) {
					isWalking = false;
					waitCounter = waitTime;
				}
				break;
			}

			if (walkCounter <= 0) {
				isWalking = false;
				waitCounter = waitTime;
			}
		} else {
			waitCounter -= Time.deltaTime;

			myRigidbody.velocity = Vector2.zero;

			if (waitCounter <= 0) {
				ChooseDirection ();
			}
		}
	}

	public void ChooseDirection()
	{
		walkDirection = Random.Range (0, 4);
		isWalking = true;
		walkCounter = walkTime;
	}

	public void StartQuest()
	{
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
