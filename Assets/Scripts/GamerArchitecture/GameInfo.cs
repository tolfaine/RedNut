using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

public class GameInfo : MonoBehaviour {
	public GameObject enemyPrefab;
	public List<SessionInfo> listSession = new List<SessionInfo>(1);
	// Use this for initialization
	void Start () {

	}

	// Update is called once per frame
	void Update () {

	}

	public GameObject getEnemyPrefab(){
		return enemyPrefab;
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


