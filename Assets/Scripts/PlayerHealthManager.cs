using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealthManager : MonoBehaviour {

	public int playerMaxHealth;
	public int playerCurrentHealth;

	public bool flashActive;
	public float flashLength;
	private float flashCounter;
	private SpriteRenderer playerSprite;

	private SFXManager sfxMan;
	private CursorManager theCM;
	private PlayerController thePC;
	private EnemyDirection[] theED;

//	public float respawnTime;

	// Use this for initialization
	void Start () {
		playerCurrentHealth = playerMaxHealth;

		playerSprite = GetComponent<SpriteRenderer> ();

		sfxMan = FindObjectOfType<SFXManager> ();

		theCM = FindObjectOfType<CursorManager> ();

		thePC = FindObjectOfType<PlayerController> ();

		theED = FindObjectsOfType<EnemyDirection> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (playerCurrentHealth <= 0) {
//			gameObject.SetActive (false);
			thePC.IsDead ();
			sfxMan.playerDead.Play();
			theCM.LockSet ();
			Application.LoadLevel ("Dead");
			SetMaxHealth ();
			//Respawn ();

		}
		if (flashActive) {
			thePC.PlayerHurtMove ();
			if (flashCounter > flashLength * .66f) {
				playerSprite.color = new Color (playerSprite.color.r, playerSprite.color.g, playerSprite.color.b, 0f);
			} else if (flashCounter > flashLength * .33f) {
				playerSprite.color = new Color (playerSprite.color.r, playerSprite.color.g, playerSprite.color.b, 1f);
			} else if (flashCounter > 0) {
				playerSprite.color = new Color (playerSprite.color.r, playerSprite.color.g, playerSprite.color.b, 0f);
				for (int i = 0; i < theED.Length; i++) {
					theED [i].enemyInArea = false;
				}
			} else {
				playerSprite.color = new Color (playerSprite.color.r, playerSprite.color.g, playerSprite.color.b, 1f);
				flashActive = false;
			}

			flashCounter -= Time.deltaTime;
		}
	}

	public void HurtPlayer(int damageToGive)
	{
		playerCurrentHealth -= damageToGive;

		flashActive = true;
		flashCounter = flashLength;

		sfxMan.playerHurt.Play ();
	}

	public void SetMaxHealth()
	{
		playerCurrentHealth = playerMaxHealth;
	}

//	public void Respawn()
//	{
//		respawnTime -= Time.deltaTime;
//		if (respawnTime < 0) {
//			gameObject.SetActive (true);
//		}
//	}
}
