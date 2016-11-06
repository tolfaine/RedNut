using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class LevelManager : MonoBehaviour {


	public List<Transform> spawnningPoints;


	public LevelInfo levelInfo;
	private int currentLevelManagerIndex = 0;
	private float timerSinceLastRoundSpawn;
	private RoundManager currentRoundManager;
	private int nextRoundManagerIndex = 0;
	private GameObject currentGameObjectRoundManager;

	private SessionManager sessionManagerOwner;


	public void setValues(LevelInfo newLevelInfo,List<Transform> newSpawnningPoints, SessionManager owner ){
		levelInfo = newLevelInfo;
		sessionManagerOwner = owner;
		spawnningPoints = newSpawnningPoints;
		NextRound ();
	}

	// Use this for initialization
	void Start () {


	}
	
	// Update is called once per fra	me
	void Update () {
		
	}

	void CheckTimer ()
	{

	}

	public void NextRound ()
	{
		Destroy (currentGameObjectRoundManager);


		if (nextRoundManagerIndex <= levelInfo.listRound.Count-1) {
			Debug.Log ("Next Rouuuund!");
			currentGameObjectRoundManager = new GameObject ();
			currentGameObjectRoundManager.AddComponent<RoundManager> ();
			currentGameObjectRoundManager.name = "RoundManager";

			currentRoundManager = currentGameObjectRoundManager.GetComponent<RoundManager> ();
			currentRoundManager.setValues (levelInfo.listRound [nextRoundManagerIndex], spawnningPoints, this);
			currentRoundManager.SpawnEnemy ();
			nextRoundManagerIndex++;
		} else {
			sessionManagerOwner.NextLevel ();

		}
	}

}
