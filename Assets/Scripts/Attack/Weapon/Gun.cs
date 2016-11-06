﻿using UnityEngine;
using System.Collections;

public class Gun : Weapon {

	[Header("Magazine Settings")]
	public int magazineSize;
	public bool reloadingGun;
	[Range(0f,5f)]
	public float reloadingCooldown;
	[Range(0.1f,1.5f)]
	public float fireCooldown;
	[Space(10)]

	[Header("Projectile Settings")]
	public GameObject defaultProjectile;
	public float bulletSpeed;

	[Space(10)]


	private float currentReloadingCooldown;
	private int nbBulletsUsed = 0;
	private float currentFireCooldown = 0.0f;
	private bool hasShooted = false;
	private bool canShoot = true;
	Transform firePoint;
	bool needToReleaseButton = false;
	bool needToReload = false ;
	bool isReloading = false;


	void Awake () {

		firePoint = transform.FindChild ("FirePoint");
		if (firePoint == null) {
			Debug.LogError ("[GUN] No FirePoint");
		}
	}

	// Use this for initialization
	protected override void Start () {
		base.Start();
	}

	// Update is called once per frame
	protected override void Update () {
		ProcessCooldowns ();
		ProcessReload();
	}

	void ProcessReload(){
		if(attackLogicOwner.getAttackButtonIsPressed() && needToReleaseButton == false){
			if (needToReload == true) {
				Debug.Log ("Reloading...");
				needToReload = false;
			}
		}
		if (needToReleaseButton) {
			if (!attackLogicOwner.getAttackButtonIsPressed()) {
				needToReleaseButton = false;
			}
		}
	}

	void ProcessCooldowns(){
		if (needToReload == false) {
			if (hasShooted) {
				currentFireCooldown = fireCooldown;
				if (nbBulletsUsed == magazineSize) {
					nbBulletsUsed = 0;
					currentReloadingCooldown= reloadingCooldown;

					if (reloadingGun == true) {
						needToReleaseButton = true;
						needToReload = true;
						Debug.Log ("Need to Reload");
					}
				}
				hasShooted = false;
			}

			canShoot = true;

			if (currentReloadingCooldown > 0.0f) {
				currentReloadingCooldown -= Time.deltaTime;
				canShoot = false;
			} else {
				currentReloadingCooldown = 0.0f;
			}

			if (currentFireCooldown > 0.0f) {
				currentFireCooldown = currentFireCooldown - Time.deltaTime;
				canShoot = false;
			} else {
				currentFireCooldown = 0.0f;
			}
		}
	}
	/*
	void ProcessingShoot(){
		if (movement_vector.x != 0 || movement_vector.y != 0) {
			if (canShoot && shootButtonPressed) {
				//Debug.Log ("Is Shooting");
				Attack(movement_vector);
			}
		} else {

		}
	}*/

	public override void Attack(Vector2 directionVector){

		if (canShoot) {
			hasShooted = true;

			GameObject go = Instantiate (defaultProjectile, firePoint.position, this.transform.rotation) as GameObject;
			nbBulletsUsed++;

			go.GetComponent<Rigidbody2D> ().velocity = new Vector2 (directionVector.x * bulletSpeed, directionVector.y * bulletSpeed);

			float deg = Vector2.Angle (new Vector2 (1, 0), directionVector);
			if (directionVector.y < 0) {
				deg = 360 - deg;
			}

			go.transform.eulerAngles = new Vector3 (go.transform.eulerAngles.x, go.transform.eulerAngles.y, deg);

			Projectile p = go.GetComponent<Projectile> ();
			p.setIsAlly (isAlly);
			p.SetDamage (damage);
		}
	}


	[ContextMenu("Set to Machine Gun")]
	void setToDefaultMachineGun(){
		magazineSize = 1;
		reloadingGun = false;;
		reloadingCooldown = 0f;
		fireCooldown = 0.1f;
	}

	[ContextMenu("Set to 6 hit Gun")]
	void setToDefaultClassicGun(){
		magazineSize = 6;
		reloadingGun = true;;
		reloadingCooldown = 1;
		fireCooldown = 0.3f;
	}

}
