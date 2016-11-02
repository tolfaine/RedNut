using UnityEngine;
using System.Collections;

public class AttackLogic : MonoBehaviour {

	protected Weapon weapon;
	protected bool attackButtonPressed;
	// Use this for initialization
	protected virtual void Start () {
		weapon = transform.GetComponent<Weapon> ();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	protected virtual void ProcessInput(){

	}

	protected virtual void ProcessingAttack(){

	}

	public bool getAttackButtonIsPressed(){
		return attackButtonPressed;
	}
}
