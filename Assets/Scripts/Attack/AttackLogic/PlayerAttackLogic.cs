﻿using UnityEngine;
using System.Collections;

public class PlayerAttackLogic : AttackLogic {
	
	Vector2 movement_vector;

	// Use this for initialization
	protected override void Start () {
		base.Start();
	}
	
	// Update is called once per frame
	void Update () {
		ProcessInput ();
		ProcessingAttack ();
	}

	void ProcessInput(){

		float fireHorizontal = Input.GetAxis("RightJoystickHorizontal");
		float fireVertical = Input.GetAxis("RightJoystickVertical");

		if (Input.GetAxis ("Fire2") > 0) {
			attackButtonPressed = true;
		} else {
			attackButtonPressed = false;
		}
		movement_vector = new Vector2 (fireHorizontal, fireVertical);
		movement_vector.Normalize ();
	}

	void ProcessingAttack(){
		if (movement_vector.x != 0 || movement_vector.y != 0) {
			if (attackButtonPressed) {
				weapon.Attack(movement_vector);
			}
		} else {

		}
	}


}
