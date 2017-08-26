using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealBed : MonoBehaviour {

	public string dialogue;
	private DialogueManager dMan;

	public string[] dialogueLines;

	private Animator anim;

	private PlayerHealthManager thePHM;

	private bool inArea;

	// Use this for initialization
	void Start () {
		inArea = false;

		dMan = FindObjectOfType<DialogueManager> ();

		anim = GetComponent<Animator> ();

		thePHM = FindObjectOfType<PlayerHealthManager> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (inArea) {
			if (Input.GetButtonUp ("Jump")) {
				if (!dMan.dialogueActive) {
					inArea = false;
					dMan.dialogueLines = dialogueLines;
					dMan.currentLine = 0;
					dMan.ShowDialogue ();
					thePHM.SetMaxHealth ();
				}
			}
		}
	}

//	void OnTriggerStay2D (Collider2D other)
//	{
//		if (other.gameObject.name == "Player") {
//			if (Input.GetButtonUp ("Jump")) {
//				if (!dMan.dialogueActive) {
//					dMan.dialogueLines = dialogueLines;
//					dMan.currentLine = 0;
//					dMan.ShowDialogue ();
//					thePHM.SetMaxHealth ();
//				}
//			}
//		}
//	}

	void OnTriggerEnter2D (Collider2D other)
	{
		if (other.gameObject.name == "Player") {
			anim.SetBool ("InArea", true);
			inArea = true;
		}
	}

	void OnTriggerExit2D (Collider2D other)
	{
		if (other.gameObject.name == "Player") {
			anim.SetBool ("InArea", false);
			inArea = false;
		}
	}
}
