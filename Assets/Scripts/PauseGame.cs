using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseGame : MonoBehaviour {

	public Transform canvas;

	private PlayerController move;

	private CursorManager theCM;

	public Transform pauseMenu;
	public Transform soundMenu;
	public Transform videoMenu;
	public Transform controlMenu;

//	private static bool objectExists;

	// Use this for initialization
	void Start () {
		move = FindObjectOfType<PlayerController> ();
		theCM = FindObjectOfType<CursorManager> ();
//		if (!objectExists) {
//			objectExists = true;
//			DontDestroyOnLoad (transform.gameObject);
//		} else {
//			Destroy (gameObject);
//		}
	}

	// Update is called once per frame
	void Update () {
		if (Input.GetButtonDown ("Cancel")) {
			PauseG ();
		}
	}

	public void PauseG()
	{
		if (canvas.gameObject.activeInHierarchy == false) {
			canvas.gameObject.SetActive (true);
			Time.timeScale = 0;
			move.canMove = false;
		} else {
			canvas.gameObject.SetActive (false);
			Time.timeScale = 1;
			move.canMove = true;

			pauseMenu.gameObject.SetActive (true);
			soundMenu.gameObject.SetActive (false);
			videoMenu.gameObject.SetActive (false);
			controlMenu.gameObject.SetActive (false);
		}
		theCM.LockSet ();
	}
}
