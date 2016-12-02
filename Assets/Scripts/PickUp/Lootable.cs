using UnityEngine;
using System.Collections;

public class Lootable : MonoBehaviour {
	
	public float destroyTimer = 10f;

	// Use this for initialization
	protected virtual void Start () {
		if (destroyTimer > 0f) {
			Destroy (gameObject, destroyTimer);
		}
	}
	
	// Update is called once per frame
	protected virtual void Update () {
	
	}



		
}
