using UnityEngine;
using System.Collections;



public class StatModTimedEffect : TimedEffect {

	public enumStat typeStat;
	public int playerNumber;
	public float timer = 0f;
	public float updateTimer = 0.2f;

	protected override void Start () {
		base.Start ();

		timer = duration;
		if (typeStat == enumStat.SlowEnemies || typeStat == enumStat.Speed) {

			if (typeStat == enumStat.SlowEnemies) {
				GameObject.FindGameObjectWithTag ("HUD").transform.FindChild ("BonusWeed_" + playerNumber).GetComponent<myBonus> ().maxJauge= duration;
				GameObject.FindGameObjectWithTag ("HUD").transform.FindChild ("BonusWeed_" + playerNumber).GetComponent<myBonus> ().SetJauge(duration);
			} else {
				GameObject.FindGameObjectWithTag ("HUD").transform.FindChild("BonusSpeed_"+ playerNumber).GetComponent<myBonus> ().maxJauge= duration;
				GameObject.FindGameObjectWithTag ("HUD").transform.FindChild("BonusSpeed_"+ playerNumber).GetComponent<myBonus> ().SetJauge(duration);
			}
			InvokeRepeating ("UpdateIcones", 0f, updateTimer);
		}
	}

	public void UpdateIcones(){
		timer -= updateTimer;

		if (typeStat == enumStat.SlowEnemies) {
			GameObject.FindGameObjectWithTag ("HUD").transform.FindChild ("BonusWeed_" + playerNumber).GetComponent<myBonus> ().SetJauge(timer);
		} else if (typeStat == enumStat.Speed) {
			GameObject.FindGameObjectWithTag ("HUD").transform.FindChild("BonusSpeed_"+ playerNumber).GetComponent<myBonus> ().SetJauge(timer);
		}
	}

	public void refreshEffect(){
		CancelInvoke ();

		target = transform;

		if (repeatTime > 0) {
			InvokeRepeating ("ApplyEffect", startTime, repeatTime);
		} else {
			Invoke ("ApplyEffect", startTime);
		}

		Invoke ("EndEffect", duration);
	}

	protected override void ApplyEffect(){
		Debug.Log ("Apply effect");
		switch (typeStat) {
		case enumStat.AttackRate:
			Gun g = target.GetComponentInChildren<Gun> ();
			if (g != null) {
				g.fireCooldown += modValue;
			}
			break;
		case enumStat.Speed:
			PlayerMovement pm = target.GetComponentInChildren<PlayerMovement> ();
			pm.speed += modValue;
			break;
		case enumStat.DamageBoost:
			Weapon w = target.GetComponentInChildren<Gun> ();
			w.damage += (int)modValue;
			break;
		case enumStat.SlowEnemies:
			IAAttackLogic ia = target.GetComponentInChildren<IAAttackLogic> ();
			ia.speed += (int)modValue;
			Gun gu = target.GetComponentInChildren<Gun> ();
			gu.fireCooldown *= 2;
			target.GetComponent<SpriteRenderer> ().color = new Color (0f, 255f, 0f, 1f);
			break;
		}
	}

	protected override void EndEffect(){

		if (typeStat == enumStat.SlowEnemies) {
			GameObject.FindGameObjectWithTag ("HUD").transform.FindChild ("BonusWeed_" + playerNumber).GetComponent<myBonus> ().SetJauge(0f);
		} else {
			GameObject.FindGameObjectWithTag ("HUD").transform.FindChild("BonusSpeed_"+ playerNumber).GetComponent<myBonus> ().SetJauge(0f);
		}

		switch (typeStat) {
		case enumStat.AttackRate:
			Gun g = target.GetComponentInChildren<Gun> ();
			if (g != null) {
				g.fireCooldown -= modValue;
			}
			break;
		case enumStat.Speed:
			PlayerMovement pm = target.GetComponentInChildren<PlayerMovement> ();
			pm.speed -= modValue;
			break;
		case enumStat.DamageBoost:
			Weapon w = target.GetComponentInChildren<Gun> ();
			w.damage -= (int)modValue;
			break;
		case enumStat.SlowEnemies:
			IAAttackLogic ia = target.GetComponentInChildren<IAAttackLogic> ();
			ia.speed -= (int)modValue;
			Gun gu = target.GetComponentInChildren<Gun> ();
			gu.fireCooldown /= 2f;
			target.GetComponent<SpriteRenderer> ().color = new Color (255f, 255f, 255f, 1f);
			break;
		}

		base.EndEffect ();

	}
}
