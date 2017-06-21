using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NewGame : MonoBehaviour {

	public Button start;

	public string sceneToLoad;

	public GameObject playerStuff;

	public string exitPoint;

	private PlayerController thePlayer;

	private CursorManager theCM;

	private SceneHolder theSH;

	private PlayerStats thePS;

	private QuestObject[] theQO;

	void Start ()
	{
		thePlayer = FindObjectOfType<PlayerController> ();

		theCM = FindObjectOfType<CursorManager> ();

		theSH = FindObjectOfType<SceneHolder> ();

		thePS = FindObjectOfType<PlayerStats> ();

		theQO = FindObjectsOfType<QuestObject> ();

		Button btn = start.GetComponent<Button> ();
		btn.onClick.AddListener (TaskOnClick);
		if (playerStuff == null) {
			playerStuff = GameObject.FindWithTag ("Stuff");
			playerStuff.SetActive (false);
		}
	}

	void TaskOnClick()
	{
		PlayerPrefs.DeleteKey("SaveScene");
		PlayerPrefs.DeleteKey ("CurrentMoney");
		PlayerPrefs.DeleteKey ("PlayerExp");

		thePS.currentExp = 0;
		thePS.currentLevel = 0;

		for (int i = 0; i < theQO.Length; i++) {
			theQO [i].RestartQuests ();
		}

		Application.LoadLevel (sceneToLoad);

		playerStuff.SetActive (true);

		thePlayer.startPoint = exitPoint;

		theCM.LockSet ();
	}
}
