using UnityEngine;
using System.Collections;

public class WaterPistol : Weapon {

	public Line projectileFlux;
	public float distance;
	Transform firePoint;
	protected bool fire = false;
	protected bool fireOnce = false;
	Vector2 direction;

	public float ticksTime = 0.3f;
	public float currentTicksTime = 0f;

	public bool canTick = false;
	public bool hasShooted = false;


	public AudioSource source;

	public float volumeShot = 1f;

	public bool triggeredSound = false;

	protected void Awake(){
		firePoint = transform.FindChild ("FirePoint");
		if (firePoint == null) {
			Debug.LogError ("[GUN] No FirePoint");
		}
	}

	// Use this for initialization
	protected override void Start () {
		base.Start ();

		source = GetComponent<AudioSource> ();
		source.volume = volumeShot;

		projectileFlux = GetComponentInChildren<Line> ();
		projectileFlux.setStartPosition (firePoint);


	}

	// Update is called once per frame
	protected override void Update () {
		base.Update ();
		ProcessCooldowns ();
	}

	void ProcessCooldowns(){

		if (hasShooted) {
			hasShooted = false;
			currentTicksTime = ticksTime;
		}

		if (currentTicksTime > 0.0f) {
			currentTicksTime -= Time.deltaTime;
			canTick = false;
		} else {
			currentTicksTime = 0f;
			canTick = true;
		}
	}

	protected void FixedUpdate(){
		if (AttackButtonPressed) {
		//	projectileFluxObj.SetActive (true);
			projectileFlux.isActive = true;

			if (!triggeredSound) {
				triggeredSound = true;

				source.Play ();
			}

			RaycastHit2D hit = Physics2D.Raycast (firePoint.position, direction, distance);

			if (hit.collider != null && hit.collider.gameObject.tag == "Enemy") {
				//float distance = Mathf.Abs (hit.point.y - transform.position.y);

				projectileFlux.setStartPosition (firePoint);
				projectileFlux.setTargetPosition (hit.point);

				if (canTick) {
					hasShooted = true;
					Debug.Log ("hasShooted");

					if (hit.collider.gameObject.GetComponent<Health> ().isAlly != isAlly) {
						hit.collider.gameObject.GetComponent<Health> ().ModifHealth (damage);
					}

				}

			} else {
				projectileFlux.setStartPosition (firePoint);
				Vector3 v = new Vector3 (direction.normalized.x, direction.normalized.y, 0);
				projectileFlux.setTargetPosition (firePoint.position + v * distance);
			}

		} else if (!AttackButtonPressed) {
			triggeredSound = false;
			source.Stop ();
			//projectileFluxObj.SetActive (false);
			projectileFlux.isActive = false;
			projectileFlux.setToSamePosition (firePoint.position);
		}
	}


	public override void AttackNoCd(Vector2 directionVector){


	}

	public override void Attack(Vector2 directionVector){

		direction = directionVector;
		//fire = true;
	}
}
