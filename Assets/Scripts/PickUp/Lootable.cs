using UnityEngine;
using System.Collections;

public class Lootable : MonoBehaviour {
	
	public float destroyTimer = 10f;
	public GameObject fxLoot;

	// Use this for initialization
	protected virtual void Start () {
		if (destroyTimer > 0f) {
			Destroy (gameObject, destroyTimer);
		}

		GameObject start = Instantiate (fxLoot, transform.position, transform.rotation) as GameObject;
		start.transform.parent = this.transform;
		start.GetComponent<Animator> ().SetBool ("active", true);
	}
	
	// Update is called once per frame
	protected virtual void Update () {
	
	}



		
}
