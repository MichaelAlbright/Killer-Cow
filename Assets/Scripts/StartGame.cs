using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StartGame : MonoBehaviour {
	public Button start;

	public string sceneToLoad;

	void Start ()
	{
		Button btn = start.GetComponent<Button> ();
		btn.onClick.AddListener (TaskOnClick);
	}

	void TaskOnClick()
	{
		Application.LoadLevel (sceneToLoad);
	}
}
