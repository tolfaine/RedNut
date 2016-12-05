using UnityEngine;
using System.Collections;

public class TimedEffect : Effect {

	public float duration = 2f ;
	public float startTime = 0f;
	public float repeatTime = 0f;

	// Use this for initialization
	protected virtual void Start () {
		target = transform;

		if (repeatTime > 0) {
			InvokeRepeating ("ApplyEffect", startTime, repeatTime);
		} else {
			Invoke ("ApplyEffect", startTime);
		}

		Invoke ("EndEffect", duration);
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	protected virtual void ApplyEffect(){

	}

	protected virtual void EndEffect(){
		CancelInvoke ();
		Destroy (this);
	}
}
