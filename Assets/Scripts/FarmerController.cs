using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FarmerController : MonoBehaviour {

	public float moveSpeed;

	private Rigidbody2D myRigidbody;

	private bool moving;

	public float timeBetweenMove;
	private float timeBetweenMoveCounter;

	public float timeToMove;
	private float timeToMoveCounter;

	private Vector3 moveDirection;

	public Collider2D walkZone;
	private bool hasWalkZone;
	private Vector2 minWalkPoint;
	private Vector2 maxWalkPoint;

	// Use this for initialization
	void Start () {
		myRigidbody = GetComponent<Rigidbody2D> ();

//		timeBetweenMoveCounter = timeBetweenMove;
//		timeToMoveCounter = timeToMove;

		timeBetweenMoveCounter = Random.Range (timeBetweenMove * 0.75f, timeBetweenMove * 1.25f);
		timeToMoveCounter = Random.Range (timeToMove * 0.75f, timeToMove * 1.25f);

		if (walkZone != null) {
			minWalkPoint = walkZone.bounds.min;
			maxWalkPoint = walkZone.bounds.max;
			hasWalkZone = true;
		}
	}
	
	// Update is called once per frame
	void Update () {
		if (moving) {
			if (hasWalkZone) {
				timeToMoveCounter -= Time.deltaTime;
				myRigidbody.velocity = moveDirection;
				if (transform.position.y > maxWalkPoint.y || transform.position.x > maxWalkPoint.x || transform.position.y < minWalkPoint.y || transform.position.x < minWalkPoint.x) {
					timeToMoveCounter = -1f;
				}
			} else {
				timeToMoveCounter -= Time.deltaTime;
				myRigidbody.velocity = moveDirection;
			}


			if (timeToMoveCounter < 0f) {
				moving = false;
//				timeBetweenMoveCounter = timeBetweenMove;
				timeBetweenMoveCounter = Random.Range (timeBetweenMove * 0.75f, timeBetweenMove * 1.25f);
			}
		} else {
			timeBetweenMoveCounter -= Time.deltaTime;
			myRigidbody.velocity = Vector2.zero;
			if (timeBetweenMoveCounter < 0f) {
				moving = true;
//				timeToMoveCounter = timeToMove;
				timeToMoveCounter = Random.Range (timeToMove * 0.75f, timeToMove * 1.25f);
				moveDirection = new Vector3 (Random.Range (-1f, 1f) * moveSpeed, Random.Range (-1f, 1f) * moveSpeed, 0f);
			}
		}
	}

	void OnCollisionEnter2D(Collision2D other)
	{
//		if (other.gameObject.name == "Player") {
//			Application.LoadLevel ("dead");
//		}
	}
}
