using UnityEngine;
using System.Collections;

public class HealthModEffect : TimedEffect {

	public int healthMod;


	protected override void ApplyEffect(){
		Debug.Log (target.gameObject.GetComponent<Health> ().maxHealth);
		target.gameObject.GetComponent<Health>().ModifHealth (healthMod);
	}
}
