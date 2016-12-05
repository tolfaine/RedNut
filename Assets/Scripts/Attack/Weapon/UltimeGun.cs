using UnityEngine;
using System.Collections;

public class UltimeGun : Gun {
	public Line projectileFlux;
	public float distance;

	public float ticksTime = 0.3f;
	public float currentTicksTime = 0f;
	public bool canTick = false;

	public float lasorDelay = 1f;
	public float currentDelay = 0f;

	public float lasorDuration = 2f;
	public float currentDuration = 0f;
	public int lasorDamage = 5;

	public bool lasoring = true;

	public bool triggerLasor = false;
	public bool stoppedLasor = false;

	public bool triggerDuration = false;
	public bool triggerDelay = false;

	public AudioSource source;

	public float volumeShot = 1f;

	public bool triggeredSound = false;

	protected override void Awake () {
		base.Awake ();
		currentDuration = lasorDuration;

	}

	// Use this for initialization
	protected override void Start () {
		base.Start ();

		source = GetComponent<AudioSource> ();
		source.volume = volumeShot;

		projectileFlux = GetComponentInChildren<Line> ();
		projectileFlux.setStartPosition (firePoint);
	}

	protected override void ProcessCooldowns(){
		base.ProcessCooldowns ();

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

		if (currentDuration > 0.0f) {
			currentDuration -= Time.deltaTime;
		} else {
			if (currentDelay <=0f && lasoring && !triggerDuration) {
				triggerDuration = true;
				currentDelay = lasorDelay;
				triggerDelay = false;
			}
		}

		if (currentDelay > 0.0f) {
			currentDelay -= Time.deltaTime;
			lasoring = false;
		} else {
			if (!triggerDelay) {
				triggerDelay = true;
				lasoring = true;
				triggerLasor = false;
			}
		}


	}


	protected void FixedUpdate(){

		if (AttackButtonPressed && lasoring) {
			if (!triggeredSound) {

			}

			if (!triggerLasor) {
				triggerLasor = true;
				stoppedLasor = false;
				currentDuration = lasorDuration;
				triggerDuration = false;

				triggeredSound = true;
				source.Play ();
			}

			projectileFlux.isActive = true;
			RaycastHit2D hit = Physics2D.Raycast (firePoint.position, direction, distance);

			if (hit.collider != null && hit.collider.gameObject.tag == "Enemy") {
				//float distance = Mathf.Abs (hit.point.y - transform.position.y);

				projectileFlux.setStartPosition (firePoint);
				projectileFlux.setTargetPosition (hit.point);

				if (canTick) {
					hasShooted = true;

					if (hit.collider.gameObject.GetComponent<Health> ().isAlly != isAlly) {
						hit.collider.gameObject.GetComponent<Health> ().ModifHealth (lasorDamage);
						Debug.Log (hit.collider.gameObject.GetComponent<Health> ().health);
					}

				}

			} else {
				projectileFlux.setStartPosition (firePoint);
				Vector3 v = new Vector3 (direction.normalized.x, direction.normalized.y, 0);
				projectileFlux.setTargetPosition (firePoint.position + v * distance);
			}


		} else if((AttackButtonPressed && !lasoring ) || !AttackButtonPressed ) {

			triggeredSound = true;
			source.Stop ();
			/*
			if (!stoppedLasor) {
				stoppedLasor = true;
				triggerLasor = false;
				currentDelay = lasorDelay;
			}*/

			projectileFlux.isActive = false;
			projectileFlux.setToSamePosition (firePoint.position);
		}
	}

}
