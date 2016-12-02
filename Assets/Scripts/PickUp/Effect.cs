using UnityEngine;
using System.Collections;

public enum enumStat{Speed, DamageBoost, AttackRate, Health, Phase, SlowEnemies}

public class Effect : MonoBehaviour {

	public Transform target;
	public float modValue;
	// Use this for initialization
	void Start () {
		target = transform;

		Invoke ("ApplyEffect", 0f);
		Destroy (this);

	}
	
	// Update is called once per frame
	void Update () {
	
	}

	protected virtual void ApplyEffect(){

	}
		
	public void setTarget(GameObject newTarget){
		target = newTarget.transform;
	}
}
