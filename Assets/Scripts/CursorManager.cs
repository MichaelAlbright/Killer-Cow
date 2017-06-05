using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CursorManager : MonoBehaviour {

	CursorLockMode wantedMode;
	private bool unlocked;

	void Start()
	{
		wantedMode = CursorLockMode.None;
		Cursor.visible = true;
		unlocked = true;
		SetCursor ();
	}

	void SetCursor()
	{
		Cursor.lockState = wantedMode;
	}

	public void LockSet()
	{
		if (unlocked) {
			wantedMode = CursorLockMode.Locked;
			Cursor.visible = false;
			unlocked = false;
		} else {
			wantedMode = CursorLockMode.None;
			Cursor.visible = true;
			unlocked = true;
		}
		SetCursor ();
	}
}
