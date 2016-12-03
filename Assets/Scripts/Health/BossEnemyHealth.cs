using UnityEngine;
using System.Collections;

public class BossEnemyHealth : EnemyHealth {

	public GameObject lootItem;
	public int bossIndex;

	protected virtual void Start () {
		base.Start ();

	}
	protected override void Die(){
		base.Die ();


	}

	void OnDestroy(){
		GameObject go = Instantiate (lootItem, transform.position, transform.rotation) as GameObject;
		go.GetComponent<LootableBossGun> ().bossIndex = bossIndex;
	}

	protected override void InstantiateBasicLoot(){
		
	}
}
