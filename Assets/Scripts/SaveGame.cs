using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SaveGame : MonoBehaviour {

	public Transform player;
	public GameObject playerStuff;
	private string loadLevel;
	private int playerLvl;
	private int playerExp;

	private CursorManager theCM;
	private SceneHolder theSH;

	private PlayerStats thePS;

	void Awake()
	{

	}

	void Start()
	{
		theCM = FindObjectOfType<CursorManager> ();
		theSH = FindObjectOfType<SceneHolder> ();
		thePS = FindObjectOfType<PlayerStats> ();
	}

	public void SaveGameSettings(bool Quit)
	{
//		PlayerPrefs.Save;
		if (Quit) {
			if (PlayerPrefs.HasKey ("SaveScene")) {
				PlayerPrefs.GetString ("SaveScene");
				loadLevel = theSH.currentScene;
				PlayerPrefs.SetString("SaveScene", loadLevel);
			} else {
				loadLevel = theSH.currentScene;
				PlayerPrefs.SetString("SaveScene", loadLevel);
			}

			if (PlayerPrefs.HasKey ("PlayerExp")) {
				PlayerPrefs.GetInt ("PlayerExp");
				playerExp = thePS.currentExp;
				PlayerPrefs.SetInt("PlayerExp", playerExp);
			} else {
				playerExp = thePS.currentExp;
				PlayerPrefs.SetInt("PlayerExp", playerExp);
			}

			theCM.LockSet ();
			SceneManager.LoadScene ("Menu");
		}
	}
}
