using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class BossAttackLogic : IAAttackLogic {

	List<IAPattern> listPattern = new List<IAPattern>();
	public int patternIndex = 0;
	public bool attackNormally = true;
	public bool invokeOnce = true;

	public float nbTimeBeforePattern;

	public bool processingPattern;

	public int bossIndex;

	protected void Awake(){

	}



	// Use this for initialization
	void Start () {
		GameObject weaponPoint =  transform.Find("BrasAnchor/Bras/WeaponPoint").gameObject; // !!!!!!
		GameObject weaponHolding = Instantiate (GameObject.FindWithTag ("GameManager").GetComponent<GameInfo> ().getGunBossAtIndex (bossIndex, true), this.transform.position, this.transform.rotation) as GameObject; 
		weaponHolding.transform.parent = weaponPoint.transform;
		weaponHolding.transform.localPosition = Vector3.zero;

		weaponHolding.GetComponentInChildren<Weapon> ().isAlly = false;


		base.Start();
		listPattern.AddRange (transform.GetComponents<IAPattern>());

	}

	protected override void ProcessingAttack(){
		if (attackNormally) {
			canMoveArm = true;
			if (invokeOnce) {
				Invoke ("StopAttackNormally", nbTimeBeforePattern);
				invokeOnce = false;
			}

			if (playerDistance < range) {
				
				StopMoving ();
				Attack ();
			} else {
				Move ();
			}
		} else {
			canMoveArm = false;
			StopMoving ();
			if (!processingPattern) {
				listPattern [patternIndex].owner = this;
				listPattern [patternIndex].StartPattern ();
				processingPattern = true;
			}
		}
	}

	public void NextPattern(){
		processingPattern = false;

		patternIndex++;

		if (patternIndex >= listPattern.Count) {
			patternIndex = 0;
		}
		attackNormally = true;

	}


	public void StopAttackNormally(){
		invokeOnce = true;
		attackNormally = false;
	}

	public virtual void Attack(Vector3 vector){
		isAttacking = true;
		if (weapon != null) {
			//Debug.Log ("Attack player");
			weapon.Attack (vector);
		}
		isAttacking = false;
	}

	public virtual void AttackNoCD(Vector3 vector){
		isAttacking = true;
		if (weapon != null) {
			//Debug.Log ("Attack player");
			weapon.AttackNoCd(vector);
		}
		isAttacking = false;
	}

	public override void IsDyingFunc(){
		base.IsDyingFunc ();

		StopPatterns ();
	}

	public void StopPatterns(){
		if (processingPattern) {
			listPattern [patternIndex].Stop ();
		}
	}
}
