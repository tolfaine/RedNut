using UnityEngine;
using System.Collections;
using System.Collections.Generic;



public class EnemyHealth : Health {
	
	protected RoundManager currentRound;
	//public List<AudioClip> dieSounds = new List<AudioClip>(1);
	public float volumeDead = 1f;

	public bool calledOwner = false;

	// Use this for initialization
	protected override void Start () {
		base.Start ();
		isAlly = false;
		gameObject.tag = "Enemy";
	}

	// Update is called once per frame
	protected override void Update () {
		base.Update ();

		if (fell && !calledOwner) {
			calledOwner = true;
			currentRound.EnemyDied ();
		}

		if (readyToSelfDestroy && !destroyActivated) {
			destroyActivated = true;
			Debug.Log ("Destroy");
			Destroy (this.gameObject);
		}
	}
	public void playRandomDeadSound(){

		AudioClip clip = GameObject.FindGameObjectWithTag ("GameManager").GetComponent<GameManager> ().randomDeadSound ();
		if (clip != null) {
			AudioSource source = CustomAudioSource.PlayClipAt (clip, transform.position);
			source.volume = volumeDead;
		}
	}


	public override void ModifHealth(int damageCount)
	{
		base.ModifHealth (damageCount);
	}

	protected override void Die(){
		if (currentRound != null && !isDying) {
			//currentRound.EnemyDied ();
		}
		playRandomDeadSound ();
		base.Die ();


	}

	void OnDestroy(){

		//currentRound.EnemyDied ();

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
