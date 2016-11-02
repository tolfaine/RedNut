using UnityEngine;
using System.Collections;

public class Gun : MonoBehaviour {

	[Header("Magazine Settings")]
	public int magazineSize;
	public bool reloadingGun;
	[Range(0f,5f)]
	public float reloadingCooldown;
	[Range(0.1f,1.5f)]
	public float fireCooldown;

	[Space(10)]

	[Header("Hitting Settings")]
	public float damage;
	public LayerMask notToHit;

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
	bool shootButtonPressed = false;
	bool needToReleaseButton = false;
	bool needToReload = false ;
	bool isReloading = false;
	Vector2 movement_vector;

	void Awake () {
		firePoint = transform.FindChild ("FirePoint");
		if (firePoint == null) {
			Debug.LogError ("[GUN] No FirePoint");
		}
	}

	// Update is called once per frame
	void Update () {
		
		ProcessInput ();
		ProcessCooldowns ();
		ProcessingShoot ();

	}

	void ProcessInput(){
		
		float fireHorizontal = Input.GetAxis("RightJoystickHorizontal");
		float fireVertical = Input.GetAxis("RightJoystickVertical");

		if(Input.GetAxis("Fire2") > 0 && needToReleaseButton == false){
			if (needToReload == true) {
				Debug.Log ("Reloading...");
				needToReload = false;
			}
			shootButtonPressed = true;
		}else{
			shootButtonPressed = false;
		}

		if (needToReleaseButton) {
			if (Input.GetAxis ("Fire2") <= 0) {
				needToReleaseButton = false;
			}
		}

		movement_vector = new Vector2 (fireHorizontal, fireVertical);
		movement_vector.Normalize ();
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

	void ProcessingShoot(){
		if (movement_vector.x != 0 || movement_vector.y != 0) {
			if (canShoot && shootButtonPressed) {
				//Debug.Log ("Is Shooting");
				Shoot(movement_vector);
			}
		} else {

		}
	}

	void Shoot(Vector2 directionVector){
		hasShooted = true;

		GameObject go = Instantiate(defaultProjectile,firePoint.position,this.transform.rotation) as GameObject;
		nbBulletsUsed++;

		go.GetComponent<Rigidbody2D> ().velocity = new Vector2 (directionVector.x*bulletSpeed,directionVector.y*bulletSpeed);

		float deg = Vector2.Angle (new Vector2 (1, 0), directionVector);
		if (directionVector.y < 0) {
			deg = 360 - deg;
		}

		go.transform.eulerAngles = new Vector3(go.transform.eulerAngles.x,go.transform.eulerAngles.y, deg);
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
