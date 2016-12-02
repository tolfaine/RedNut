﻿using UnityEngine;
using System.Collections;

public class EnemyHealth : Health {
	
	protected RoundManager currentRound;

	// Use this for initialization
	protected override void Start () {
		base.Start ();
		isAlly = false;
		gameObject.tag = "Enemy";
	}

	// Update is called once per frame
	protected override void Update () {
		base.Update ();
	}

	public override void ModifHealth(int damageCount)
	{
		base.ModifHealth (damageCount);
	}

	protected override void Die(){
		base.Die ();
		if (currentRound != null) {
			currentRound.EnemyDied ();
		}
		InstantiateBasicLoot ();
	}
	protected virtual void InstantiateBasicLoot(){
		GameObject lm = GameObject.FindGameObjectWithTag ("LootManager");
		GameObject go = lm.GetComponent<LootManager> ().getRandomMobLoot ();
		if (go != null) {
			Instantiate (go, transform.position, this.transform.rotation);
		}
	}


	public void setRoundManagerOwner(RoundManager r){
		currentRound = r;
	}
		
}
