using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VolumeManager : MonoBehaviour {

	public VolumeController[] vcObjects;

	public float maxVolume = 1.0f;
	public float currentVolumeLevel;

	// Use this for initialization
	void Start () {
		vcObjects = FindObjectsOfType<VolumeController> ();

		if (PlayerPrefs.HasKey ("Volume")) {
			currentVolumeLevel = PlayerPrefs.GetFloat("Volume");
		}

		if (currentVolumeLevel > maxVolume) {
			currentVolumeLevel = maxVolume;
		}

		if (currentVolumeLevel < 0) {
			currentVolumeLevel = 0;
		}

		for (int i = 0; i < vcObjects.Length; i++) {
			vcObjects [i].SetAudioLevel (currentVolumeLevel);
		}
	}

	public void ChangeVolume (float newVolume) {

		currentVolumeLevel = newVolume;

		if (currentVolumeLevel > maxVolume) {
			currentVolumeLevel = maxVolume;
		}

		if (currentVolumeLevel < 0) {
			currentVolumeLevel = 0;
		}

		for (int i = 0; i < vcObjects.Length; i++) {
			vcObjects [i].SetAudioLevel (currentVolumeLevel);
		}

		if (PlayerPrefs.HasKey ("Volume")) {
			PlayerPrefs.GetFloat("Volume");
			PlayerPrefs.SetFloat("Volume", currentVolumeLevel);
		} else {
			PlayerPrefs.SetFloat("Volume", currentVolumeLevel);
		}
	}
}
