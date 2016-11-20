using UnityEngine;
using System.Collections;

public class BossEnemyHealth : EnemyHealth {

	public GameObject lootItem;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	protected override void Die(){
		base.Die ();
		GameObject go = Instantiate (lootItem, transform.position, transform.rotation) as GameObject;

	}
}
