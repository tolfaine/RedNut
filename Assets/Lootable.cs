using UnityEngine;
using System.Collections;

public class Lootable : MonoBehaviour {
	
	public enumStat typeStat;
	public bool isTimedEffect;
	public float modValue;
	public float destroyTimer = 4f;

	// Use this for initialization
	void Start () {
		Destroy (gameObject, destroyTimer);
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter2D(Collider2D collision){

		GameObject go = collision.gameObject;


		if (go.tag == "Player") {

			if (isTimedEffect) {
				StatModTimedEffect smte  = go.AddComponent<StatModTimedEffect> () as StatModTimedEffect;;
				smte.setTarget (go);
				smte.modValue = modValue;
				smte.typeStat = typeStat;
			} else {
				StatModEffect sme  = go.AddComponent<StatModEffect> () as StatModEffect;;
				sme.setTarget (go);
				sme.typeStat = typeStat;
			}
			Destroy (gameObject);
		}

	}
}
