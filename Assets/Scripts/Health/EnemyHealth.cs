using UnityEngine;
using System.Collections;

public class EnemyHealth : Health {
	
	RoundManager currentRound;

	// Use this for initialization
	protected override void Start () {
		base.Start ();
		isAlly = false;
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
		if (currentRound != null) {
			currentRound.EnemyDied ();
		}

	}

	public void setRoundManagerOwner(RoundManager r){
		currentRound = r;
	}
}
