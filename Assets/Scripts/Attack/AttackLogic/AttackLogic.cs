using UnityEngine;
using System.Collections;

public class AttackLogic : MonoBehaviour {

	protected Weapon weapon;
	protected bool attackButtonPressed;
	public Transform bras;

	// Use this for initialization
	protected virtual void Start () {
		weapon = transform.GetComponentInChildren<Weapon> ();
		weapon.setOwner(this);
		bras = transform.FindChild("BrasAnchor");
	}
	
	// Update is called once per frame
	protected virtual void Update () {
	
	}

	protected virtual void FixedUpdate () {

	}

	protected virtual void ProcessInput(){

	}

	protected virtual void ProcessingAttack(){

	}

	public bool getAttackButtonIsPressed(){
		return attackButtonPressed;
	}
}
