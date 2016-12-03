using UnityEngine;
using System.Collections;

public enum TypePattern{Spirale}

public class IAPattern : MonoBehaviour {

	public float duration = 2f ;
	public float startTime = 0f;
	public float repeatTime = 0f;

	public BossAttackLogic owner;
	public Transform ownerTransform;

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void StartPattern(){

		if (repeatTime > 0) {
			InvokeRepeating ("ProcessPattern", startTime, repeatTime);
		} else {
			Invoke ("ProcessPattern", startTime);
		}

		Invoke ("EndPattern", duration);
	}

	protected virtual void ProcessPattern(){
	}

	protected virtual void EndPattern(){
		CancelInvoke ();
		owner.NextPattern ();
	}

	public void Stop(){
		CancelInvoke ();
	}

}