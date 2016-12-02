using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Projectile : MonoBehaviour {
	public List<AudioClip> shotSounds = new List<AudioClip>(1);
	[Range(0.2f,5)]
	public float destroyTimer = 2f;
	public bool isAlly;
	int damage;	


//	LayerMask notToHit;

	// Use this for initialization
	void Start () {
		Destroy (gameObject, destroyTimer);
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter2D(Collider2D collision){
		if (collision.gameObject.tag == "Enemy" || collision.gameObject.tag == "Player") {
			GameObject go = collision.gameObject;
			playRandomHitSound ();
		}

	}

	public void SetDamage(int newDamage){
		damage = newDamage;
	}
	public int getDamage(){
		return damage;
	}

/*	public void SetNotToHiLayer(LayerMask newLayer){
		notToHit = newLayer;
	}*/
	public void setIsAlly(bool newIsAlly){
		isAlly = newIsAlly;
	}

	public bool getIsAlly(){
		return isAlly;
	}

	public void destroy(){

	}

	public float randomPitch(){
		//float rand = Random.Range(0.95f,1.05f);
		float rand = Random.Range(0.90f,1.05f);
		return rand;
	}

	public AudioClip randomShotSound(){
		if (shotSounds.Count > 0) {
			int rand = Random.Range (0, shotSounds.Count);
			return shotSounds [rand];
		}

		return null;
	}

	public void playRandomHitSound(){
		AudioClip clip = randomShotSound ();
		if (clip != null) {
			CustomAudioSource.PlayClipAt (clip, transform.position);
		}
	}


}
