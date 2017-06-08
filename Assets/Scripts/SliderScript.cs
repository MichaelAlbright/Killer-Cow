using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SliderScript : MonoBehaviour {

	public Slider mainSlider;

	private VolumeManager theVM;

	void Start()
	{
		theVM = FindObjectOfType<VolumeManager> ();

		mainSlider.value = theVM.currentVolumeLevel;

		mainSlider.onValueChanged.AddListener (delegate {
			ValueChangeCheck ();
		});
	}

	public void ValueChangeCheck()
	{
		theVM.ChangeVolume (mainSlider.value);
		Debug.Log (mainSlider.value);
	}
}
