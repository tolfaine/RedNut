using UnityEngine;
using System.Collections;

public class Projectile : MonoBehaviour {

	[Range(1,5)]
	public float destroyTimer = 2f;
	bool isAlly = true;

	int damage;
	LayerMask notToHit;

	// Use this for initialization
	void Start () {
		Destroy (gameObject, destroyTimer);
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter2D(Collider2D collision){

	}

	public void SetDamage(int newDamage){
		damage = newDamage;
	}

	public void SetNotToHiLayer(LayerMask newLayer){
		notToHit = newLayer;
	}
	public void setIsAlly(bool newIsAlly){
		isAlly = newIsAlly;
	}

	public bool getIsAlly(){
		return isAlly;
	}

	public void destroy(){

	}

	public int getDamage(){
		return damage;
	}
}
