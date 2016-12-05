using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Gun : Weapon {
	
	public List<AudioClip> shotSounds = new List<AudioClip>(1);

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


	protected float currentReloadingCooldown;
	protected int nbBulletsUsed = 0;
	protected float currentFireCooldown = 0.0f;
	protected bool hasShooted = false;
	protected bool canShoot = true;
	protected Transform firePoint;
	protected bool needToReleaseButton = false;
	protected bool needToReload = false ;
	protected bool isReloading = false;

	protected Vector2 direction;


	public float volumeGun = 1f;
	public float randomPitchrRange = 0f;

	public AudioClip randomShotSound(){
		if (shotSounds.Count > 0) {
			int rand = Random.Range (0, shotSounds.Count);
			return shotSounds [rand];
		}
		return null;
	}

	protected virtual void Awake () {

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

	protected virtual void ProcessCooldowns(){
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

	public float randomPitch(){
	//	float rand = Random.Range(0.95f,1.05f); gland
		float rand = Random.Range(1f - randomPitchrRange,1f + randomPitchrRange);
		return rand;
	}


	public override void AttackNoCd(Vector2 directionVector){
		direction = directionVector;

		playRandomShotSound ();

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

	public override void Attack(Vector2 directionVector){
		direction = directionVector;

		if (canShoot) {
			hasShooted = true;

			playRandomShotSound ();

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


	public override void setOwner(AttackLogic a){
		base.setOwner (a);


	}

	public void playRandomShotSound(){
		//if (a != null ) {
		//	a.clip = randomShotSound ();
		//	a.pitch = randomPitch ();
		//	a.Play ();
		AudioClip clip = randomShotSound ();
		if (clip != null) {
			AudioSource source =  CustomAudioSource.PlayClipAt (clip, transform.position);
			source.volume = volumeGun;
			source.pitch = randomPitch ();
		}
		//}
	}
}
