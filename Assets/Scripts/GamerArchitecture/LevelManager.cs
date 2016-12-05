using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class LevelManager : MonoBehaviour {


	public List<Transform> spawnningPoints;


	public LevelInfo levelInfo;
	public int currentLevelManagerIndex = 0;
	private float timerSinceLastRoundSpawn;
	private RoundManager currentRoundManager;
	private int nextRoundManagerIndex = 0;
	private GameObject currentGameObjectRoundManager;

	private SessionManager sessionManagerOwner;

	private bool bossHasbeenSpawned = false;

	public void setValues(LevelInfo newLevelInfo,List<Transform> newSpawnningPoints, int index, SessionManager owner ){
		currentLevelManagerIndex = index;
		levelInfo = newLevelInfo;
		sessionManagerOwner = owner;
		spawnningPoints = newSpawnningPoints;

		GameObject.FindGameObjectWithTag ("progressBar_ui").GetComponent<ProgressBar> ().nbRound = levelInfo.listRound.Count -1;

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
		Debug.Log ("Destroy Round manager");
		Destroy (currentGameObjectRoundManager);


		if (nextRoundManagerIndex <= levelInfo.listRound.Count) {
			Debug.Log ("Next Rouuuund!");
			currentGameObjectRoundManager = new GameObject ();
			currentGameObjectRoundManager.AddComponent<RoundManager> ();
			currentGameObjectRoundManager.name = "RoundManager";
			currentGameObjectRoundManager.tag = "RoundManager";

			currentRoundManager = currentGameObjectRoundManager.GetComponent<RoundManager> ();
			currentRoundManager.setValues (levelInfo.listRound [nextRoundManagerIndex], spawnningPoints, this);
			currentRoundManager.setIsBossRound (levelInfo.listRound [nextRoundManagerIndex].isBossRound);
			currentRoundManager.SpawnEnemy ();
			nextRoundManagerIndex++;
		} //else {

			//sessionManagerOwner.NextLevel ();

		//}
	}

	public int getCurrentLevelIndex(){
		return currentLevelManagerIndex;
	}

	public void EndLastRound(){
		sessionManagerOwner.NextLevel ();
	}
		
}
