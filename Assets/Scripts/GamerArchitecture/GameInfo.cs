using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

public enum enumTypeEnnemi{Business, Enfant, Fourrier,Wesh, Jardinier, Joggers }

public class GameInfo : MonoBehaviour {
	public List<SessionInfo> listSession = new List<SessionInfo>(1);
	public List<GroupEnemies> listGroupEnemies = new List<GroupEnemies>(1);
	public List<Boss> listBoss = new List<Boss>(1);


	// Use this for initialization
	void Start () {

	}

	// Update is called once per frame
	void Update () {

	}

	public GameObject getRandomEnemyAtLevelIndex(int index){
		int rand = Random.Range(0,3);
		enumTypeEnnemi e = enumTypeEnnemi.Joggers;
		if (rand == 0) {
			e = listBoss [index].type;
		} else if (rand == 1) {
			e = enumTypeEnnemi.Jardinier;
		} else if (rand == 2) {
			e = enumTypeEnnemi.Joggers;
		}
		return getRandomEnemyOfType (e);
	}

	private GameObject getRandomEnemyOfType(enumTypeEnnemi type){
		for (int i = 0; i < listGroupEnemies.Count; i++) {
			if (listGroupEnemies[i].type == type) {
				return getRandomEnemyPrefabAtIndex (i);
			}
		}
		return null;
	}

	private GameObject getRandomEnemyPrefabAtIndex(int index){

		int rand = Random.Range(0,listGroupEnemies[index].mobs.Count);
		return listGroupEnemies[index].mobs[rand];
	}

	private GameObject getRandomEnemyPrefab(){
		GroupEnemies o;
		int rand = Random.Range(0,listGroupEnemies.Count);
		o = listGroupEnemies[rand];
		rand = Random.Range(0,o.mobs.Count);

		return o.mobs[rand];
	}

	public GameObject getBossAtIndex(int index){
		return listBoss [index].boss;
	}

	public GameObject getGunBossAtIndex(int index, bool worn ){
		Debug.Log (index);
		if (worn) {
			return listBoss [index].wornGun;
		} else {
			return listBoss [index].lootedGun;
		}
		return null;
	}

}


[System.Serializable]
public class SessionInfo{
	//public int nbRounds;
	//public int difficultyMod;
	public int nbPlayers;
	public List<LevelInfo> listLevel = new List<LevelInfo>(1);

}

[System.Serializable]
public class LevelInfo{
	//public int nbRounds;
	public int difficulty;
	public List<RoundInfo> listRound = new List<RoundInfo>(1);

}


[System.Serializable]
public class RoundInfo{
	public int nbEnemies;
	public bool isBossRound;
	public bool isLastRound;
}


[System.Serializable]
public class GroupEnemies{
	public enumTypeEnnemi type;
	public List<GameObject> mobs;
}

[System.Serializable]
public class Boss{
	public enumTypeEnnemi type;
	public GameObject boss;
	public GameObject lootedGun;
	public GameObject wornGun;
}

