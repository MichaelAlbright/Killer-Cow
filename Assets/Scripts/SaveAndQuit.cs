using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SaveAndQuit : MonoBehaviour {

	public Button quit;

	private SaveGame theSG;

	void Start()
	{
		theSG = FindObjectOfType<SaveGame> ();

		Button btn = quit.GetComponent<Button> ();
		btn.onClick.AddListener (TaskOnClick);
	}

	void TaskOnClick()
	{
		theSG.SaveGameSettings (true);
		Application.Quit ();
	}
}
