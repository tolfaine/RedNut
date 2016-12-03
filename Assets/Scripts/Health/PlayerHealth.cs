﻿using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PlayerHealth : Health {
	MyHealth life_ui;
	public List<AudioClip> hitSounds = new List<AudioClip>(1);
	public List<AudioClip> dieSounds = new List<AudioClip>(1);
	AudioSource a;

	// Use this for initialization
	protected override void Start () {
		base.Start ();
		SetInvulnerability (false);
		isAlly = true;
		life_ui = GameObject.FindGameObjectWithTag ("life_ui").GetComponent<MyHealth> ();
		life_ui.maxHealthPlayer = maxHealth;

		a= gameObject.GetComponent<AudioSource> ();


	}
	
	// Update is called once per frame
	protected override void Update () {
		base.Update ();
	}

	public override void Resurect(){
		base.Resurect ();

		PlayerCenterPoint playerCenterPoint = GameObject.FindGameObjectWithTag ("PlayerCenterPoint").GetComponent<PlayerCenterPoint>();
		playerCenterPoint.findPlayers ();
	}


	public override void ModifHealth(int damageCount)
	{
		if (!isDying) {
			a.clip = randomHItSound ();
			a.Play ();
		}

		base.ModifHealth (damageCount);
		life_ui.SetLife(health);



	}

	protected override void Die(){
		if (!isDying) {
			a.clip = randomDeadSound ();
			a.Play ();
		}


		base.Die ();

		PlayerCenterPoint playerCenterPoint = GameObject.FindGameObjectWithTag ("PlayerCenterPoint").GetComponent<PlayerCenterPoint>();
		playerCenterPoint.findPlayers ();

	}
		

	public AudioClip randomHItSound(){
		int rand = Random.Range(0,hitSounds.Count);

		return hitSounds [rand];
	}

	public AudioClip randomDeadSound(){
		int rand = Random.Range(0,dieSounds.Count);

		return dieSounds [rand];
	}
}
