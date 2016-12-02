using UnityEngine;
using System.Collections;



public class StatModTimedEffect : TimedEffect {

	public enumStat typeStat;


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
