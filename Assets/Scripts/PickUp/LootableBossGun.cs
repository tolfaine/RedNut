using UnityEngine;
using System.Collections;

public class LootableBossGun : Lootable {

	public GameObject bossGun;
	public int bossIndex;
	// Use this for initialization



	protected override void Start () {

		base.Start ();
		destroyTimer = 0f;

		bossGun = GameObject.FindWithTag ("GameManager").GetComponent<GameInfo> ().getGunBossAtIndex (bossIndex, false);
		GetComponent<SpriteRenderer> ().sprite = bossGun.GetComponentInChildren <SpriteRenderer> ().sprite;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter2D(Collider2D collision){

		GameObject go = collision.gameObject;


		if (go.tag == "Player") {

			GameObject[] gos = GameObject.FindGameObjectsWithTag ("Player");

			foreach (GameObject g in gos) {
				g.GetComponent<PlayerAttackLogic> ().ChangeGun (bossGun);
			}

			RoundManager r = GameObject.FindGameObjectWithTag ("RoundManager").GetComponent<RoundManager>();
			r.EndBossRound ();

			Destroy (gameObject);
		}

	}

}
