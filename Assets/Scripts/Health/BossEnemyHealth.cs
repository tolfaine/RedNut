using UnityEngine;
using System.Collections;

public class BossEnemyHealth : EnemyHealth {

	public GameObject lootItem;

	protected override void Die(){
		base.Die ();
		GameObject go = Instantiate (lootItem, transform.position, transform.rotation) as GameObject;

	}

	protected override void InstantiateBasicLoot(){
	}
}
