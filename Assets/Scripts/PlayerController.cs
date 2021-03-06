﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

	public float moveSpeed;
	private float currentMoveSpeed;
	public float diagonalMoveModifier;

	private Animator anim;
	private Rigidbody2D myRigidbody;

	private bool playerMoving;
	public Vector2 lastMove;
	private Vector2 moveInput;

//	private static bool playerExists;

	private bool attacking;
	public float attackTime;
	private float attackTimeCounter;

	public string startPoint;

	public bool canMove;

	private SFXManager sfxMan;
	private EnemyDirection[] theED;

	// Use this for initialization
	void Start () {
		anim = GetComponent<Animator> ();
		myRigidbody = GetComponent<Rigidbody2D> ();
		sfxMan = FindObjectOfType<SFXManager> ();
		theED = FindObjectsOfType<EnemyDirection> ();

//		if (!playerExists) {
//			playerExists = true;
//			DontDestroyOnLoad (transform.gameObject);
//		} else {
//			Destroy (gameObject);
//		}

		canMove = true;

		lastMove = new Vector2 (0f, -1f);
	}
	
	// Update is called once per frame
	void Update () {

		playerMoving = false;

		if (!canMove) {
			myRigidbody.velocity = Vector2.zero;
			return;
		}

		if (!attacking) {
//			if (Input.GetAxisRaw ("Horizontal") > 0.1f || Input.GetAxisRaw ("Horizontal") < -0.1f) {
//				//transform.Translate (new Vector3 (Input.GetAxisRaw ("Horizontal") * moveSpeed * Time.deltaTime, 0f, 0f));
//				myRigidbody.velocity = new Vector2 (Input.GetAxisRaw ("Horizontal") * currentMoveSpeed, myRigidbody.velocity.y);
//				playerMoving = true;
//				lastMove = new Vector2 (Input.GetAxisRaw ("Horizontal"), 0f);
//			}
//
//			if (Input.GetAxisRaw ("Vertical") > 0.1f || Input.GetAxisRaw ("Vertical") < -0.1f) {
//				//transform.Translate (new Vector3 (0f, Input.GetAxisRaw ("Vertical") * moveSpeed * Time.deltaTime, 0f));
//				myRigidbody.velocity = new Vector2 (myRigidbody.velocity.x, Input.GetAxisRaw ("Vertical") * currentMoveSpeed);
//				playerMoving = true;
//				lastMove = new Vector2 (0f, Input.GetAxisRaw ("Vertical"));
//			}
//
//			if (Input.GetAxisRaw ("Horizontal") < 0.1f && Input.GetAxisRaw ("Horizontal") > -0.1f) {
//				myRigidbody.velocity = new Vector2 (0f, myRigidbody.velocity.y);
//			}
//
//			if (Input.GetAxisRaw ("Vertical") < 0.1f && Input.GetAxisRaw ("Vertical") > -0.1f) {
//				myRigidbody.velocity = new Vector2 (myRigidbody.velocity.x, 0f);
//			}

			moveInput = new Vector2 (Input.GetAxisRaw ("Horizontal"), Input.GetAxisRaw ("Vertical")).normalized;

			if (moveInput != Vector2.zero) {
				myRigidbody.velocity = new Vector2 (moveInput.x * moveSpeed, moveInput.y * moveSpeed);
				playerMoving = true;
				lastMove = moveInput;
			} else {
				myRigidbody.velocity = Vector2.zero;
			}

			if (Input.GetAxisRaw ("Fire1") > 0.1f) {
				attackTimeCounter = attackTime;
				attacking = true;
				myRigidbody.velocity = Vector2.zero;
				anim.SetBool ("Attack", true);

				sfxMan.playerAttack.Play();
			}

//			if (Mathf.Abs (Input.GetAxisRaw ("Horizontal")) > 0.1f && Mathf.Abs (Input.GetAxisRaw ("Vertical")) > 0.1f) {
//				currentMoveSpeed = moveSpeed * diagonalMoveModifier;
//			} else {
//				currentMoveSpeed = moveSpeed;
//			}

		}

		if (attackTimeCounter > 0) {
			attackTimeCounter -= Time.deltaTime;
		}

		if (attackTimeCounter <= 0) {
			attacking = false;
			anim.SetBool ("Attack", false);
		}

		anim.SetFloat ("MoveX", Input.GetAxisRaw ("Horizontal"));
		anim.SetFloat ("MoveY", Input.GetAxisRaw("Vertical"));
		anim.SetBool ("PlayerMoving", playerMoving);
		anim.SetFloat ("LastMoveX", lastMove.x);
		anim.SetFloat ("LastMoveY", lastMove.y);
	}

	public void IsDead()
	{
		attacking = false;
		anim.SetBool ("Attack", false);
	}

	public void PlayerHurtMove()
	{
		int directionX = 0;
		int directionY = 0;
		canMove = false;
		for (int i = 0; i < theED.Length; i++) {
			if (theED [i].enemyInArea) {
				if (theED [i].isX) {
					directionX = theED [i].playerDirectionX;
				} else if (theED [i].isY) {
					directionY = theED [i].playerDirectionY;
				}
			}
		}
		myRigidbody.velocity = new Vector2 (directionX * moveSpeed, directionY * moveSpeed);
		canMove = true;
	}
}
