using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour {

	public Slider healthBar;
	public Text HPText;
	public PlayerHealthManager playerHealth;

	public Slider levelBar;
	public Text levelText;

	private PlayerStats thePS;
	public int currentLvl;
	public int preveousLvl;

//	private static bool UIExists;

	// Use this for initialization
	void Start () {
//		if (!UIExists) {
//			UIExists = true;
//			DontDestroyOnLoad (transform.gameObject);
//		} else {
//			Destroy (gameObject);
//		}
		thePS = GetComponent<PlayerStats> ();
	}
	
	// Update is called once per frame
	void Update () {
		currentLvl = thePS.currentLevel;
		if (currentLvl > 1) {
			preveousLvl = currentLvl - 1;
		} else {
			preveousLvl = 0;
		}
		healthBar.maxValue = playerHealth.playerMaxHealth;
		healthBar.value = playerHealth.playerCurrentHealth;
		HPText.text = "HP: " + healthBar.value + "/" + healthBar.maxValue;
		levelText.text = "Lvl: " + thePS.currentLevel + " - " + (thePS.currentExp - thePS.toLevelUp [preveousLvl]) + "/" + (thePS.toLevelUp[currentLvl] - thePS.toLevelUp [preveousLvl]);
		levelBar.maxValue = thePS.toLevelUp[currentLvl];
		if (currentLvl > 1) {
			levelBar.minValue = thePS.toLevelUp [preveousLvl];
		} else {
			levelBar.minValue = 0;
		}
		levelBar.value = thePS.currentExp;
	}
}
