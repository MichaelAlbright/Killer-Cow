using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ResolutionDropdown : MonoBehaviour {

	private bool isFullscreen;
	private int binaryFullscreen;

	public Dropdown drop;
	public Toggle tfs;

	// Use this for initialization
	void Start () {
		int startRes;
		if (PlayerPrefs.HasKey ("Resolution")) {
			startRes = PlayerPrefs.GetInt("Resolution");
		} else {
			startRes = 0;
		}

		if (PlayerPrefs.HasKey ("Fullscreen")) {
			binaryFullscreen = PlayerPrefs.GetInt("Fullscreen");
		} else {
			binaryFullscreen = 1;
		}

		if (binaryFullscreen == 1) {
			isFullscreen = true;
		} else {
			isFullscreen = false;
		}
			
		drop.value = startRes;
		tfs.isOn = isFullscreen;

		DropdownInput (startRes);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void DropdownInput(int input)
	{
		
		if (input == 0) {
			Screen.SetResolution (1200, 900, isFullscreen);
			Debug.Log ("option is " + input);
		}
		if (input == 1) {
			Screen.SetResolution (1500, 1200, isFullscreen);
			Debug.Log ("option is " + input);
		}
		if (input == 2) {
			Screen.SetResolution (1600, 1000, isFullscreen);
			Debug.Log ("option is " + input);
		}
		if (input == 3) {
			Screen.SetResolution (1600, 900, isFullscreen);
			Debug.Log ("option is " + input);
		}
		if (PlayerPrefs.HasKey ("Resolution")) {
			PlayerPrefs.GetInt("Resolution");
			PlayerPrefs.SetInt("Resolution", input);
		} else {
			PlayerPrefs.SetInt("Resolution", input);
		}
	}

	public void ToggleFullscreen(bool full)
	{
		if (full) {
			isFullscreen = true;
			binaryFullscreen = 1;
		} else {
			isFullscreen = false;
			binaryFullscreen = 0;
		}

		if (PlayerPrefs.HasKey ("Fullscreen")) {
			PlayerPrefs.GetInt("Fullscreen");
			PlayerPrefs.SetInt("Fullscreen", binaryFullscreen);
		} else {
			PlayerPrefs.SetInt("Fullscreen", binaryFullscreen);
		}

		Screen.SetResolution (Screen.width, Screen.height, isFullscreen);
		Debug.Log ("fullscreen is " + full);
	}
}
