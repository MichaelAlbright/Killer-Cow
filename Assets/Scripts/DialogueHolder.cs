using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueHolder : MonoBehaviour {

	public string dialogue;
	private DialogueManager dMan;

	public string[] dialogueLines;

	public GameObject button;

	private bool inArea;

	// Use this for initialization
	void Start () {
		dMan = FindObjectOfType<DialogueManager> ();

		inArea = false;
	}
	
	// Update is called once per frame
	void Update () {
		if (inArea) {
			if (Input.GetButtonUp ("Jump")) {
				//				dMan.ShowBox (dialogue);

				if (!dMan.dialogueActive) {
					inArea = false;
					dMan.dialogueLines = dialogueLines;
					dMan.currentLine = 0;
					dMan.ShowDialogue ();
				}

				if (transform.parent.GetComponent<VillagerMovement> () != null) {
					transform.parent.GetComponent<VillagerMovement> ().canMove = false;
				}
			}
		}
	}

//	void OnTriggerStay2D (Collider2D other)
//	{
//		if (other.gameObject.name == "Player") {
//			if (Input.GetButtonUp ("Jump")) {
////				dMan.ShowBox (dialogue);
//
//				if (!dMan.dialogueActive) {
//					inArea = false;
//					dMan.dialogueLines = dialogueLines;
//					dMan.currentLine = 0;
//					dMan.ShowDialogue ();
//				}
//
//				if (transform.parent.GetComponent<VillagerMovement> () != null) {
//					transform.parent.GetComponent<VillagerMovement> ().canMove = false;
//				}
//			}
//		}
//	}

	void OnTriggerEnter2D (Collider2D other)
	{
		if (other.gameObject.name == "Player") {
			button.SetActive (true);
			inArea = true;
		}
	}

	void OnTriggerExit2D (Collider2D other)
	{
		if (other.gameObject.name == "Player") {
			button.SetActive (false);
			inArea = false;
		}
	}
}
