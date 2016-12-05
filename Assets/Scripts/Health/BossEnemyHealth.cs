using UnityEngine;
using System.Collections;

public class BossEnemyHealth : EnemyHealth {

	public GameObject lootItem;
	public int bossIndex;

	protected virtual void Start () {
		base.Start ();
		GameObject.FindGameObjectWithTag ("progressBar_ui").GetComponent<ProgressBar> ().bossMaxLife = maxHealth;


	}
	protected override void Die(){
		base.Die ();


	}

	public override void ModifHealth(int damageCount)
	{
		base.ModifHealth (damageCount);

		GameObject.FindGameObjectWithTag ("progressBar_ui").GetComponent<ProgressBar> ().SetBossLife (health);
	}

	void OnDestroy(){
		GameObject go = Instantiate (lootItem, transform.position, transform.rotation) as GameObject;
		go.GetComponent<LootableBossGun> ().bossIndex = bossIndex;
	}

	protected override void InstantiateBasicLoot(){
		
	}
}
