using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class LootManager : MonoBehaviour {

	public List<GameObject> mobLoots;
	public List<GameObject> bossLots;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public GameObject getRandomMobLoot(){

		float rand = Random.Range(0f,1f);

		if(rand <= 0.7f){

			float clop = Random.Range(0f,1f);

			if (clop <= 0.8) {
				GameObject o;
				o = mobLoots[0];
				return o;
			} else {
				GameObject o;
				int rand2 = Random.Range(0,mobLoots.Count);
				o = mobLoots[rand2];
				return o;
			}
		}
		return null;
	}

	public GameObject getBossLootAtIndex(){
		return null;
	}
}
