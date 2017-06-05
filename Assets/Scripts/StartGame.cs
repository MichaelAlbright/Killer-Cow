﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StartGame : MonoBehaviour {
	public Button start;

	public string sceneToLoad;

	public GameObject playerStuff;

	public string exitPoint;

	private PlayerController thePlayer;

	private CursorManager theCM;

	private SceneHolder theSH;

	void Start ()
	{
		thePlayer = FindObjectOfType<PlayerController> ();

		theCM = FindObjectOfType<CursorManager> ();

		theSH = FindObjectOfType<SceneHolder> ();

		Button btn = start.GetComponent<Button> ();
		btn.onClick.AddListener (TaskOnClick);
		if (playerStuff == null) {
			playerStuff = GameObject.FindWithTag ("Stuff");
			playerStuff.SetActive (false);
		}
	}

	void TaskOnClick()
	{
		Application.LoadLevel (theSH.preveousScene);

		playerStuff.SetActive (true);

		thePlayer.startPoint = exitPoint;

		theCM.LockSet ();
	}
}
