using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LockedDoor : MonoBehaviour {

	private Animator anim;

	public bool unlocked;
	private bool open;
	public GameObject enter;

	// Use this for initialization
	void Start () {
		anim = GetComponent<Animator> ();
		open = false;
	}
	
	// Update is called once per frame
	void Update () {
		anim.SetBool ("Unlocked", unlocked);

		if (!unlocked) {
			enter.SetActive (false);
		}
		if (unlocked) {
			enter.SetActive (true);
		}
	}

	void OnTriggerEnter2D (Collider2D other)
	{
		if (other.gameObject.name == "Player" && unlocked) {
			open = true;
			anim.SetBool ("Open", open);
		}
	}

	void OnTriggerExit2D (Collider2D other)
	{
		if (other.gameObject.name == "Player" && unlocked) {
			open = false;
			anim.SetBool ("Open", open);
		}
	}
}
