using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StartGame : MonoBehaviour {
	public Button start;

	public string sceneToLoad;

	public GameObject playerStuff;

	public string exitPoint;

	private PlayerController thePlayer;

	void Start ()
	{
		thePlayer = FindObjectOfType<PlayerController> ();

		Button btn = start.GetComponent<Button> ();
		btn.onClick.AddListener (TaskOnClick);
		if (playerStuff == null) {
			playerStuff = GameObject.FindWithTag ("Stuff");
			playerStuff.SetActive (false);
		}
	}

	void TaskOnClick()
	{
		Application.LoadLevel (sceneToLoad);

		playerStuff.SetActive (true);

		thePlayer.startPoint = exitPoint;
	}
}
