using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChangeScene : MonoBehaviour {

	public Button start;

	public string sceneToLoad;

	public GameObject playerStuff;

	public string exitPoint;

	private PlayerController thePlayer;

	private SceneHolder theSH;

	void Start ()
	{
		thePlayer = FindObjectOfType<PlayerController> ();

		theSH = FindObjectOfType<SceneHolder> ();

		Button btn = start.GetComponent<Button> ();
		btn.onClick.AddListener (TaskOnClick);

		if (playerStuff == null) {
			playerStuff = GameObject.FindWithTag ("Stuff");
		}
	}

	void TaskOnClick()
	{
		Application.LoadLevel (sceneToLoad);

		thePlayer.startPoint = exitPoint;

		if (!playerStuff.activeInHierarchy) {
			playerStuff.SetActive (true);
		}
	}
}
