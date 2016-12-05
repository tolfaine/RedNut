using UnityEngine;
using System.Collections;


public class PlayerAttackLogic : AttackLogic {
	
	public int playerNumber;
	Vector2 movement_vector;



	public void SetPlayerNumber(int number){
		playerNumber = number;
		GetComponent<PlayerHealth> ().playerNumber = number;
		GetComponent<PhaseManager> ().playerNumber = number;
	}
	// Use this for initialization
	protected override void Start () {
		base.Start();
	}
	
	// Update is called once per frame
	protected override void Update () {
		if (!isDying) {
			ProcessInput ();
			ProcessArmMovement ();
			ProcessingAttack ();
		}

	}
	public override void IsDyingFunc(){
		base.IsDyingFunc ();
		GetComponent<PlayerMovement> ().dead = true;
	}


	public override void Resurect(){
		base.Resurect ();
		GetComponent<PlayerMovement> ().dead = false;
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

	public void ChangeGun(GameObject newGun){
		GameObject weaponPoint =  transform.Find("BrasAnchor/Bras/WeaponPoint").gameObject;

		Transform[] listChildren = weaponPoint.GetComponentsInChildren<Transform> ();



		foreach (Transform t in listChildren) {
			if (t.gameObject != weaponPoint) {
				Destroy (t.gameObject);
			}
		}

		GameObject weaponHolding = Instantiate (newGun, this.transform.position, this.transform.rotation) as GameObject; 
		weaponHolding.GetComponentInChildren<Weapon> ().isAlly = true;

		weaponHolding.transform.parent = weaponPoint.transform;
		weaponHolding.transform.localPosition = Vector3.zero;
		weaponHolding.transform.localEulerAngles = Vector3.zero;

		weapon = weaponHolding.GetComponentInChildren<Weapon> ();

		if (weapon == null) {
			Debug.Log ("null null");
		}
		weapon.setOwner(this);


	}
		
}
