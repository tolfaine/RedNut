using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

public enum enumTypeEnnemi{Business, Enfant, Fourrier,Wesh, Jardinier, Joggers }

public class GameInfo : MonoBehaviour {
	public GameObject enemyPrefab;
	public List<SessionInfo> listSession = new List<SessionInfo>(1);
	public List<GroupEnemies> listGroupEnemies = new List<GroupEnemies>(1);
	public List<Boss> listBoss = new List<Boss>(1);

	// Use this for initialization
	void Start () {

	}

	// Update is called once per frame
	void Update () {

	}

	public GameObject getEnemyPrefab(){
		return enemyPrefab;
	}

	public GameObject getRandomEnemyPrefab(){
		GroupEnemies o;
		int rand = Random.Range(0,listGroupEnemies.Count);
		o = listGroupEnemies[rand];
		rand = Random.Range(0,o.mobs.Count);

		return o.mobs[rand];
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
}

