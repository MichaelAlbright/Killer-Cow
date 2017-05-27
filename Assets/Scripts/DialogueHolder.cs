using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueHolder : MonoBehaviour {

	public string dialogue;
	private DialogueManager dMan;

	public string[] dialogueLines;

	public GameObject button;

	// Use this for initialization
	void Start () {
		dMan = FindObjectOfType<DialogueManager> ();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerStay2D (Collider2D other)
	{
		if (other.gameObject.name == "Player") {
			if (Input.GetButtonUp ("Jump")) {
//				dMan.ShowBox (dialogue);

				if (!dMan.dialogueActive) {
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

	void OnTriggerEnter2D (Collider2D other)
	{
		if (other.gameObject.name == "Player") {
			button.SetActive (true);
		}
	}

	void OnTriggerExit2D (Collider2D other)
	{
		if (other.gameObject.name == "Player") {
			button.SetActive (false);
		}
	}
}
