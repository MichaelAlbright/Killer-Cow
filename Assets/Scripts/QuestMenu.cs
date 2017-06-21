using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class QuestMenu : MonoBehaviour {

	private QuestManager theQM;
	private int y;
	public GameObject[] buttons;
	private bool isOpen;

	// Use this for initialization
	void Start () {
		isOpen = true;
		y = 0;
		theQM = FindObjectOfType<QuestManager> ();
		for (int i = 0; i < buttons.Length; i++) {
			buttons [i].SetActive (false);
		}
	}
	
	// Update is called once per frame
	void Update () {
		if (isOpen) {
			Open ();
			isOpen = false;
		}
	}

	public void Reset()
	{
		y = 0;
		for (int i = 0; i < buttons.Length; i++) {
			buttons [i].SetActive (false);
		}
	}

	// 228 315 0

	public void Open()
	{
		y = 0;
		for (int i = 0; i < theQM.quests.Length; i++) {
			if (theQM.quests [i].gameObject.activeInHierarchy) {
				y++;
				int yDir = 345 - (y * 30);
				buttons [i].SetActive (true);
				buttons [i].transform.position = new Vector3 (228, yDir , 0);
			} else {
				buttons [i].SetActive (false);
			}

			Debug.Log ("x" + buttons[i].transform.position.x + " y" + buttons[i].transform.position.y + " z" + buttons[i].transform.position.z + " for " + buttons[i]);
		}
	}

	public void BtnOpen()
	{
		isOpen = true;
	}
}
