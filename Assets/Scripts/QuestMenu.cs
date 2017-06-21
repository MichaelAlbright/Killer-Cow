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
			Open ();
			isOpen = false;
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
			buttons [i].SetActive (false);
			buttons [i].transform.position = new Vector3 (startX, startY, startZ);
		}
	}

	public void Open()
	{
		y = 0;
		int f = 0;
		for (int i = 0; i < theQM.quests.Length; i++) {
			if (theQM.quests [i].gameObject.activeInHierarchy) {
				y++;
				float yDir = buttons[f].transform.position.y - 30;
				f = i;
				buttons [i].SetActive (true);
				if (y > 1) {
					buttons [i].transform.position = new Vector3 (startX, yDir, startZ);
				}
			} else {
				buttons [i].SetActive (false);
				buttons [i].transform.position = new Vector3 (startX, startY, startZ);
			}

			Debug.Log ("x" + buttons[i].transform.position.x + " y" + buttons[i].transform.position.y + " z" + buttons[i].transform.position.z + " for " + buttons[i]);
		}
	}

	public void BtnOpen()
	{
		isOpen = true;
	}
}
