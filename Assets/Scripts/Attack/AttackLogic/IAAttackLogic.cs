using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class IAAttackLogic : AttackLogic {
	
	public float speed;
	public float range;

	//Transform player;
	Transform playerTarget;
	Rigidbody2D rbody;
	bool playerInSight;
	protected float playerDistance;
	protected bool isAttacking;
	Vector2 movement_vector;
	bool facingRight = true;
	Animator anim;

	public bool canMoveArm = true;

	public bool isAppearing = false;
	private float appearDuration = 1f;

	protected void Awake(){
		GameObject weaponPoint =  transform.Find("BrasAnchor/Bras/WeaponPoint").gameObject; // !!!!!!
		GameObject weaponHolding = Instantiate (GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>().IaWeapon, this.transform.position, this.transform.rotation) as GameObject; 
		weaponHolding.transform.parent = weaponPoint.transform;
		weaponHolding.transform.localPosition = Vector3.zero;

		weaponHolding.GetComponentInChildren<Weapon> ().isAlly = false;
	}

	// Use this for initialization
	protected override void Start () {
		base.Start();
		findNearestPlayer ();
		rbody = GetComponent<Rigidbody2D> ();
		anim = GetComponent<Animator> ();
	}
	
	// Update is called once per frame

	protected override void FixedUpdate () {
		base.FixedUpdate ();
		findNearestPlayer ();


	}

	public float GetAppearDuration(){
		return appearDuration;
	}

	public virtual void StartAppearing(float duration ){
		isAppearing = true;

		EnemyHealth e = gameObject.GetComponent<EnemyHealth> ();
		e.SetInvulnerability (isAppearing);
		Invoke("StopAppearing",duration);
	}

	public virtual void StopAppearing(){
		isAppearing = false;
		EnemyHealth e = gameObject.GetComponent<EnemyHealth> ();
		e.SetInvulnerability (isAppearing);
	}


	protected void findNearestPlayer () {		
		GameObject[] lGo = GameObject.FindGameObjectsWithTag ("Player");

		Transform nearestObjTransform = null;
		float nearestDistance = 999999f;;

		int nbNotDead = 0;
		foreach(GameObject go in lGo){
			if (!go.GetComponent<Health> ().isItDying ()) {
				nbNotDead++;
				Transform t = go.transform;
				Vector2 dir= t.position - transform.position;
				float dist = dir.magnitude;

				if (dist < nearestDistance) {
					nearestDistance = dist;
					nearestObjTransform = go.transform;
				}
			}
		}

		if (nbNotDead > 0) {
			playerTarget = nearestObjTransform;
		} else {
			playerTarget = null;
		}
	}

	protected override void Update () {		


		if (!isAppearing && !isDying && playerTarget != null) {
			ProcessInput ();
			ProcessArmMovement ();
			ProcessingAttack ();
		} else if (playerTarget == null) {
			StopMoving ();
		}
	}

	protected override void ProcessInput(){

		movement_vector = playerTarget.position - transform.position;
		playerDistance = movement_vector.magnitude;
		movement_vector.Normalize ();

		if (movement_vector.x != 0 || movement_vector.y != 0) {
			anim.SetFloat ("input_x", movement_vector.x);
			anim.SetFloat ("input_y", movement_vector.y);

			if (Mathf.Abs(movement_vector.x) > Mathf.Abs(movement_vector.y)) {
				if (movement_vector.x > 0f && !facingRight) {
					Flip ();
				} else if (movement_vector.x < 0f && facingRight) {
					Flip ();
				}

			}
		}
	}

	protected override void ProcessingAttack(){
		if (playerDistance < range) {
			StopMoving ();
			Attack ();
		} else {
			Move ();
		}
	}

	protected virtual void Attack(){
		isAttacking = true;
		if (weapon != null) {
			//Debug.Log ("Attack player");
			weapon.Attack (movement_vector);
		}
		isAttacking = false;
	}

	protected void Move(){
		rbody.velocity = new Vector2(movement_vector.x *speed,movement_vector.y *speed);
		anim.SetBool ("isWalking", true);
	}

	public void StopMoving(){
		rbody.velocity = Vector2.zero;
		anim.SetBool ("isWalking", false);
	}

	public override void IsDyingFunc(){

		base.IsDyingFunc ();
		StopMoving ();
	}

	protected void Flip(){
		
		facingRight = !facingRight;
		Vector3 scale = transform.localScale;
		scale.x *= -1;
		transform.localScale = scale;

		Vector3 scaleBras = bras.localScale;
		scaleBras.x *= -1;
		bras.localScale = scaleBras;
	}

	protected void ProcessArmMovement(){
		if (canMoveArm) {
			float deg = Vector2.Angle (new Vector2 (1, 0), movement_vector);
			if (movement_vector.y < 0) {
				deg = 360 - deg;
			}
			bras.eulerAngles = new Vector3 (bras.eulerAngles.x, bras.eulerAngles.y, deg);
		}
	}

	public Vector3 GetMovementVector(){
		return movement_vector;
	}

}
