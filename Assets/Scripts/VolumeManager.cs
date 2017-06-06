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

	public void ChangeVolume (int newVolume) {

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
	}
}
