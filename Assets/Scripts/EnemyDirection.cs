using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDirection : MonoBehaviour {

	public int playerDirectionX;
	public int playerDirectionY;

	public bool enemyInArea;
	public bool isX;
	public bool isY;

	void OnTriggerEnter2D (Collider2D other)
	{
		if (other.gameObject.tag == "Enemy") {
			enemyInArea = true;
		} else {
			enemyInArea = false;
		}
	}
}
