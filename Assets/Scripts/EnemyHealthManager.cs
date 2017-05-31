using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyHealthManager : MonoBehaviour {

	public int enemyMaxHealth;
	public int enemyCurrentHealth;

	private PlayerStats thePlayerStats;

	public int expToGive;

	public string enemyQuestName;
	private QuestManager theQM;

	public Slider enemyHealth;

	// Use this for initialization
	void Start () {
		enemyCurrentHealth = enemyMaxHealth;

		thePlayerStats = FindObjectOfType<PlayerStats> ();

		theQM = FindObjectOfType<QuestManager> ();

		enemyHealth.maxValue = enemyMaxHealth;
	}

	// Update is called once per frame
	void Update () {
		if (enemyCurrentHealth <= 0) {
			theQM.enemyKilled = enemyQuestName;

			Destroy (gameObject);

			thePlayerStats.AddExperience (expToGive);
		}
		enemyHealth.value = enemyCurrentHealth;
	}

	public void HurtEnemy(int damageToGive)
	{
		enemyCurrentHealth -= damageToGive;
	}

	public void SetMaxHealth()
	{
		enemyCurrentHealth = enemyMaxHealth;
	}
}
