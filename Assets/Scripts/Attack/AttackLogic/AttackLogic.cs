using UnityEngine;
using System.Collections;

public class AttackLogic : MonoBehaviour {

	public Weapon weapon;
	protected bool attackButtonPressed;
	public Transform bras;

	public bool isDying = false;

	// Use this for initialization


	protected virtual void Start () {
		weapon = transform.GetComponentInChildren<Weapon> ();
		weapon.setOwner(this);
		bras = transform.FindChild("BrasAnchor");
	}
	public virtual void IsDyingFunc(){
		isDying = true;
		bras.gameObject.SetActive (false);
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

	public virtual void Resurect(){
		isDying = false;
		bras.gameObject.SetActive (true);
	}
}
