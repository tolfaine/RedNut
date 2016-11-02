using UnityEngine;
using System.Collections;

public class Projectile : MonoBehaviour {

	[Range(1,5)]
	public float destroyTimer = 2f;

	float damage;
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

	public void SetDamage(float newDamage){
		damage = newDamage;
	}

	public void SetNotToHiLayer(LayerMask newLayer){
		notToHit = newLayer;
	}
}
