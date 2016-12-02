using UnityEngine;
using System.Collections;

public class LootableBossGun : Lootable {

	// Use this for initialization
	void Start () {
		destroyTimer = 0f;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter2D(Collider2D collision){

		GameObject go = collision.gameObject;


		if (go.tag == "Player") {

			RoundManager r = GameObject.FindGameObjectWithTag ("RoundManager").GetComponent<RoundManager>();
			r.EndBossRound ();

			Destroy (gameObject);
		}

	}

}
