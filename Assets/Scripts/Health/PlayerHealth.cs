using UnityEngine;
using System.Collections;

public class PlayerHealth : Health {

	// Use this for initialization
	protected override void Start () {
		base.Start ();
		isAlly = true;
	}
	
	// Update is called once per frame
	protected override void Update () {
		base.Update ();
	}

	public override void TakeDamage(int damageCount)
	{
		base.TakeDamage (damageCount);

	}

	protected override void Die(){
		base.Die ();

	}
}
