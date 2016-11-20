using UnityEngine;
using System.Collections;

public enum enumStat{Speed, Damage, AttackRate, Health, Phase}

public class StatModTimedEffect : TimedEffect {

	public enumStat typeStat;
	public float modValue;

	protected override void ApplyEffect(){

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
		case enumStat.Damage:
			Weapon w = target.GetComponentInChildren<Gun> ();
			w.damage += (int)modValue;
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
		case enumStat.Damage:
			Weapon w = target.GetComponentInChildren<Gun> ();
			w.damage -= (int)modValue;
			break;
		}

		base.EndEffect ();

	}
}
