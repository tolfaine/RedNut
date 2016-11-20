using UnityEngine;
using System.Collections;


public class PlayerAttackLogic : AttackLogic {
	
	public int playerNumber;
	Vector2 movement_vector;
	private Transform bras;

	// Use this for initialization
	protected override void Start () {
		base.Start();
		bras = transform.FindChild("BrasAnchor");
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

		if (Input.GetAxis ("Fire_P"+playerNumber) > 0) {
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
				weapon.Attack(movement_vector);
			}
		} else {

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
