using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneHolder : MonoBehaviour {

	public string newScene;
	public string currentScene;
	public string preveousScene;

	// Use this for initialization
	void Start () {
		Scene scene = SceneManager.GetActiveScene ();
		newScene = scene.name;
		if (PlayerPrefs.HasKey ("SaveScene")) {
			preveousScene = PlayerPrefs.GetString ("SaveScene");
		} else {
			preveousScene = "Tutorial Barn";
		}
		currentScene = newScene;
		Debug.Log ("Save Scene is " + PlayerPrefs.GetString ("SaveScene"));
	}

	// Update is called once per frame
	void Update () {
		Scene scene = SceneManager.GetActiveScene ();
		newScene = scene.name;
		if (currentScene != newScene) {
			preveousScene = currentScene;
			currentScene = newScene;
		}
		if (preveousScene == "New Game") {
			if (PlayerPrefs.HasKey ("SaveScene")) {
				preveousScene = PlayerPrefs.GetString ("SaveScene");
			} else {
				preveousScene = "Tutorial Barn";
			}
		}
	}
}
