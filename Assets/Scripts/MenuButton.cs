using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuButton : MonoBehaviour {

	public Button menuBtn;

	public GameObject menuToOpen;
	public GameObject menuToClose;

	// Use this for initialization
	void Start () {
		Button btn = menuBtn.GetComponent<Button> ();
		btn.onClick.AddListener (TaskOnClick);
	}
	
	void TaskOnClick()
	{
		if (!menuToOpen.activeSelf) {
			menuToOpen.SetActive (true);
		}
		if (menuToClose.activeSelf) {
			menuToClose.SetActive (false);
		}
	}
}
