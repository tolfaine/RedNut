using UnityEngine;
using System.Collections;

public class Weapon : MonoBehaviour {

	[Header("Hitting Settings")]
	public bool isAlly;
	public int damage;
	public bool AttackButtonPressed;
	//public LayerMask notToHit;
	public AttackLogic attackLogicOwner;

	// Use this for initialization
	protected virtual void Start () {
		
	}
	
	// Update is called once per frame
	protected virtual void Update () {
	
	}
	public virtual void AttackNoCd(Vector2 directionVector){

	}

	public virtual void Attack(Vector2 directionVector){
		
	}

	public virtual void setOwner(AttackLogic a){
		attackLogicOwner = a;
	}
}
