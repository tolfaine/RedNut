using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class LootableEffect : Lootable {

	public enumStat typeStat;
	public bool isTimedEffect;
	public float modValue;
	public List<AudioClip> lootSounds = new List<AudioClip>(1);
	public List<Sprite> listSprites = new List<Sprite>(1);

	// Use this for initialization
	protected override void Start () {
		base.Start ();
		Sprite s = randomSprite ();
		if(s !=null){
			GetComponent<SpriteRenderer> ().sprite = s;
		}
				
	}

	// Update is called once per frame
	protected override void Update () {
		base.Update ();
	}

	public AudioClip randomLootSound(){
		int rand = Random.Range(0,lootSounds.Count);

		return lootSounds [rand];
	}

	public Sprite randomSprite(){
		if (listSprites.Count == 0) {
			return null;
		}
		int rand = Random.Range(0,listSprites.Count);
		return listSprites [rand];
	}

	void OnTriggerEnter2D(Collider2D collision){

		GameObject go = collision.gameObject;


		if (go.tag == "Player") {
			
			AudioSource a = go.GetComponent<AudioSource> ();
			a.clip = randomLootSound ();
			a.Play ();


			if (typeStat == enumStat.SlowEnemies) {
				GameObject[] allEnemies = GameObject.FindGameObjectsWithTag ("Enemy");

				foreach (GameObject g in allEnemies) {
					StatModTimedEffect smte = g.AddComponent<StatModTimedEffect> () as StatModTimedEffect;
					smte.setTarget (g);
					smte.modValue = modValue;
					smte.typeStat = enumStat.SlowEnemies;

					/*
					smte = g.AddComponent<StatModTimedEffect> () as StatModTimedEffect;
					smte.setTarget (g);
					smte.modValue = -0.2f;
					smte.typeStat = enumStat.AttackRate;*/
				}

			} else {
				if (isTimedEffect) {
					StatModTimedEffect smte = go.AddComponent<StatModTimedEffect> () as StatModTimedEffect;
					smte.setTarget (go);
					smte.modValue = modValue;
					smte.typeStat = typeStat;
				} else {
					StatModEffect sme = go.AddComponent<StatModEffect> () as StatModEffect;
					
					sme.setTarget (go);
					sme.typeStat = typeStat;
					sme.modValue = modValue;
				}
			}
			Destroy (gameObject);
		}

	}
}
