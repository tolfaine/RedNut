using UnityEngine;
using System.Collections;


public class PlayerAttackLogic : AttackLogic {
	
	public int playerNumber;
	Vector2 movement_vector;


	// Use this for initialization
	protected override void Start () {
		base.Start();

	}
	
	// Update is called once per frame
	protected override void Update () {
		ProcessInput ();
		ProcessArmMovement ();
		ProcessingAttack ();
	}

	protected override void FixedUpdate () {
		base.FixedUpdate ();
	}

	protected override void ProcessInput(){
		float fireHorizontal = Input.GetAxis("RightJoystickHorizontal_P"+playerNumber);
		float fireVertical = Input.GetAxis("RightJoystickVertical_P"+playerNumber);

		if (Mathf.Abs(fireVertical) > 0.2f || Mathf.Abs(fireHorizontal) > 0.2f) {
			attackButtonPressed = true;
		} else {
			attackButtonPressed = false;
		}
		movement_vector = new Vector2 (fireHorizontal, fireVertical);
		movement_vector.Normalize ();
	}

	protected override void ProcessingAttack(){
		if (movement_vector.x != 0 || movement_vector.y != 0) {
			if (attackButtonPressed) {
				weapon.AttackButtonPressed = true;
				weapon.Attack(movement_vector);
			}
		} else {
			weapon.AttackButtonPressed = false;
		}
	}

	protected void ProcessArmMovement(){
		
		float deg = Vector2.Angle (new Vector2 (1, 0), movement_vector);
		if (movement_vector.y < 0) {
			deg = 360 - deg;
		}
		bras.eulerAngles = new Vector3 (bras.eulerAngles.x, bras.eulerAngles.y, deg);
	}


}
