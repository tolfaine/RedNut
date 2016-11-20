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
	float playerDistance;
	bool isAttacking;
	Vector2 movement_vector;



	// Use this for initialization
	protected override void Start () {
		base.Start();
		findNearestPlayer ();
		rbody = GetComponent<Rigidbody2D> ();

	}
	
	// Update is called once per frame

	protected override void FixedUpdate () {
		base.FixedUpdate ();
		findNearestPlayer ();

	}

	protected void findNearestPlayer () {		
		GameObject[] lGo = GameObject.FindGameObjectsWithTag ("Player");

		Transform nearestObjTransform = null;
		float nearestDistance = 999999f;;

		foreach(GameObject go in lGo){
			Transform t = go.transform;
			Vector2 dir= t.position - transform.position;
			float dist = dir.magnitude;

			if (dist < nearestDistance) {
				nearestDistance = dist;
				nearestObjTransform = go.transform;
			}
		}

		playerTarget = nearestObjTransform;
	}

	protected override void Update () {		
		ProcessInput ();
		ProcessingAttack ();
	}

	protected override void ProcessInput(){

		movement_vector = playerTarget.position - transform.position;
		playerDistance = movement_vector.magnitude;
		movement_vector.Normalize ();
	}

	protected override void ProcessingAttack(){
		if (playerDistance < range) {
			StopMoving ();
			Attack ();
		} else {
			Move ();
		}
	}

	void Attack(){
		isAttacking = true;
		if (weapon != null) {
			//Debug.Log ("Attack player");
			weapon.Attack (movement_vector);
		}
		isAttacking = false;
	}

	void Move(){
		rbody.velocity = new Vector2(movement_vector.x *speed,movement_vector.y *speed);
	}

	void StopMoving(){
		rbody.velocity = Vector2.zero;
	}




}
