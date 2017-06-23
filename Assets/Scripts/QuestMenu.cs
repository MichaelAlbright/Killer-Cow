using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class QuestMenu : MonoBehaviour {

	private QuestManager theQM;
	private int y;
	public GameObject[] buttons;
	public PauseGame thePG;
	private bool isOpen;
	public float startX;
	public float startY;
	public float startZ;
	public GameObject[] questText;

	public bool closed;

	// Use this for initialization
	void Start () {
		isOpen = true;
		y = 0;
		theQM = FindObjectOfType<QuestManager> ();
		thePG = FindObjectOfType<PauseGame> ();
		for (int i = 0; i < buttons.Length; i++) {
			buttons [i].SetActive (false);
		}
		startX = buttons [0].transform.position.x;
		startY = buttons [0].transform.position.y;
		startZ = buttons [0].transform.position.z;
	}
	
	// Update is called once per frame
	void Update () {
		if (isOpen) {
			Reset ();
			Open ();
			isOpen = false;
			Debug.Log ("open " + startX + " " + startY + " " + startZ);
		}
		if (thePG.closed) {
			Reset ();
			thePG.closed = false;

		}
	}

	public void Reset()
	{
		y = 0;
		for (int i = 0; i < buttons.Length; i++) {
			buttons [i].SetActive (true);
			buttons [i].transform.position = new Vector3 (startX, startY, startZ);
			buttons [i].SetActive (false);
		}
		for (int i = 0; i < questText.Length; i++) {
			questText [i].SetActive (false);
		}
		Debug.Log ("close " + startX  + " " + startY + " " + startZ);
	}

	public void Open()
	{
		for (int i = 0; i < questText.Length; i++) {
			questText [i].SetActive (false);
		}
		y = 0;
		int f = 0;
		for (int i = 0; i < theQM.quests.Length; i++) {
			if (theQM.quests [i].saveQuest == 1) {
				y++;
				float yDir = buttons[f].transform.position.y - 30;
				f = i;
				buttons [i].SetActive (true);
				if (y == 1) {
					startX = buttons [i].transform.position.x;
					startY = buttons [i].transform.position.y;
					startZ = buttons [i].transform.position.z;
				}
				if (y > 1) {
					buttons [i].transform.position = new Vector3 (startX, yDir, startZ);
				}
			} else {
				buttons [i].transform.position = new Vector3 (startX, startY, startZ);
				buttons [i].SetActive (false);
			}

//			Debug.Log ("x" + buttons[i].transform.position.x + " y" + buttons[i].transform.position.y + " z" + buttons[i].transform.position.z + " for " + buttons[i]);
		}
	}

	public void BtnOpen()
	{
		isOpen = true;
	}
}
