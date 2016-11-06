using UnityEngine;
using System.Collections;

public class Weapon : MonoBehaviour {

	[Header("Hitting Settings")]
	public bool isAlly;
	public int damage;
	//public LayerMask notToHit;
	protected AttackLogic attackLogicOwner;

	// Use this for initialization
	protected virtual void Start () {
		attackLogicOwner = transform.GetComponent<AttackLogic> ();
	}
	
	// Update is called once per frame
	protected virtual void Update () {
	
	}

	public virtual void Attack(Vector2 directionVector){
		
	}
}
