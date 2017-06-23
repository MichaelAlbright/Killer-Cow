using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuButton : MonoBehaviour {

	public Button menuBtn;

	public Transform menuToOpen;
	public Transform menuToClose;

	// Use this for initialization
	void Start () {
		Button btn = menuBtn.GetComponent<Button> ();
		btn.onClick.AddListener (TaskOnClick);
	}
	
	public void TaskOnClick()
	{
		if (menuToOpen.gameObject.activeInHierarchy == false) {
			menuToOpen.gameObject.SetActive (true);
		}
		if (menuToClose.gameObject.activeInHierarchy == true) {
			menuToClose.gameObject.SetActive (false);
		}
	}
}
