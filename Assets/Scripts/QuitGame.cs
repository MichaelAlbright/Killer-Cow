using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class QuitGame : MonoBehaviour {
	public Button quit;

	void Start ()
	{
		Button btn = quit.GetComponent<Button> ();
		btn.onClick.AddListener (TaskOnClick);
	}

	void TaskOnClick()
	{
		Application.Quit ();
	}
}
