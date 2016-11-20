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
		GameObject o;
		int rand = Random.Range(0,mobLoots.Count);
		o = mobLoots[rand];
		return o;
	}

	public GameObject getBossLootAtIndex(){
		return null;
	}
}
