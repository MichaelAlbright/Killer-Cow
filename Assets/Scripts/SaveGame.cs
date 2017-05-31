using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SaveGame : MonoBehaviour {

	public Transform player;
	public GameObject playerStuff;

	void Awake()
	{

	}

	public void SaveGameSettings(bool Quit)
	{
//		PlayerPrefs.Save;
		if (Quit) {
			
			SceneManager.LoadScene ("Menu");
		}
	}
}
