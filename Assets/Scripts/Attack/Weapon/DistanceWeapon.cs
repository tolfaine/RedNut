using UnityEngine;
using System.Collections;

public class DistanceWeapon : Weapon {
	
	public float HitCooldown;
	private float currentHitCooldown = 0.0f;
	private bool canHit= true;
	private bool hasHitted = false;

	// Use this for initialization
	protected override void Start () {
		base.Start();
	}
	
	// Update is called once per frame
	protected override void Update () {
		ProcessCooldowns ();
	}


	void ProcessCooldowns(){

		if (hasHitted) {
			currentHitCooldown = HitCooldown;
			hasHitted = false;
		}

		canHit = true;

		if (currentHitCooldown > 0.0f) {
			currentHitCooldown = currentHitCooldown - Time.deltaTime;
			canHit = false;
		} else {
			currentHitCooldown = 0.0f;
		}

	}

	public override void Attack(Vector2 directionVector){

		if (canHit) {
			hasHitted = true;

		}
	}
}
