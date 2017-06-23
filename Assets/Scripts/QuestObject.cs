using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestObject : MonoBehaviour {

	public int questNumber;

	public QuestManager theQM;

	public string startText;
	public string endText;

	public bool isItemQuest;
	public string targetItem;

	public bool isEnemyQuest;
	public string targetEnemy;
	public int enemiesToKill;
	private int enemyKillCount;

	private PlayerStats thePS;
	public int exp;

	public int saveQuest;

	// Use this for initialization
	void Start () {
		
		thePS = FindObjectOfType<PlayerStats> ();
		if (PlayerPrefs.HasKey ("SaveQuest" + questNumber)) {
			saveQuest = PlayerPrefs.GetInt ("SaveQuest" + questNumber);
		} else {
			saveQuest = 0;
		}

//		if (saveQuest == 0) {
//			gameObject.SetActive (false);
//		} else if (saveQuest == 1) {
//			gameObject.SetActive (true);
//		} else if (saveQuest == 2) {
//			theQM.questCompleted [questNumber] = true;
//			gameObject.SetActive (false);
//		}

		if (isEnemyQuest) {
			if (PlayerPrefs.HasKey ("Enemy" + questNumber)) {
				enemyKillCount = PlayerPrefs.GetInt ("Enemy" + questNumber);
			} else {
				enemyKillCount = 0;
			}
		}
	}
	
	// Update is called once per frame
	void Update () {
		if (saveQuest == 0) {
			gameObject.SetActive (false);
		} else if (saveQuest == 1) {
			gameObject.SetActive (true);
		} else if (saveQuest == 2) {
			theQM.questCompleted [questNumber] = true;
			gameObject.SetActive (false);
		}

		if (isItemQuest) {
			if (theQM.itemCollected == targetItem) {
				theQM.itemCollected = null;

				EndQuest ();
			}
		}

		if (isEnemyQuest) {
			if (theQM.enemyKilled == targetEnemy) {
				theQM.enemyKilled = null;

				enemyKillCount++;
			}
			if (enemyKillCount >= enemiesToKill) {
				EndQuest ();
			}
		}
	}

	public void StartQuest()
	{
		saveQuest = 1;
		theQM.ShowQuestText (startText);
	}

	public void EndQuest()
	{
		saveQuest = 2;
		theQM.ShowQuestText (endText);
		theQM.questCompleted [questNumber] = true;
		thePS.AddExperience (exp);
		gameObject.SetActive (false);
	}

	public void RestartQuests()
	{
		theQM.questCompleted [questNumber] = false;
		gameObject.SetActive (false);

		saveQuest = 0;

		PlayerPrefs.DeleteKey ("SaveQuest" + questNumber);

		if (isEnemyQuest) {
			PlayerPrefs.DeleteKey ("Enemy" + questNumber);
			enemyKillCount = 0;
		}
		Debug.Log ("quest restart" + questNumber);
		Debug.Log ("enemy kill count for " + questNumber + " " + enemyKillCount);
	}

	public void SaveQuests()
	{
		if (PlayerPrefs.HasKey ("SaveQuest" + questNumber)) {
			PlayerPrefs.GetInt ("SaveQuest" + questNumber);
			PlayerPrefs.SetInt("SaveQuest" + questNumber, saveQuest);
		} else {
			PlayerPrefs.SetInt("SaveQuest" + questNumber, saveQuest);
		}

		Debug.Log ("save" + questNumber + " is " + PlayerPrefs.GetInt ("SaveQuest" + questNumber));
		Debug.Log ("saveQuest" + questNumber + " is " + saveQuest);

		if (isEnemyQuest) {
			if (PlayerPrefs.HasKey ("Enemy" + questNumber)) {
				PlayerPrefs.GetInt ("Enemy" + questNumber);
				PlayerPrefs.SetInt ("Enemy" + questNumber, enemyKillCount);
			} else {
				PlayerPrefs.SetInt ("Enemy" + questNumber, enemyKillCount);
			}
		}
	}
}
