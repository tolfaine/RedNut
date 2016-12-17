using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[System.Serializable]
public class RoundManager : MonoBehaviour {

	public int nbEnemiesDead;
	public RoundInfo roundInfo;
	public List<Transform> spawnningPoints;
	public GameObject enemyPrefab;
	private bool isBossRound;

	public bool isLastRound;

	private LevelManager levelManagerOwner;

	public void setValues(RoundInfo newRoundInfo,List<Transform> newSpawnningPoints,LevelManager owner){
		spawnningPoints = newSpawnningPoints;
		roundInfo = newRoundInfo;
		levelManagerOwner = owner;
	}


	public LevelManager getOwner(){
		return levelManagerOwner;
	}
	// Use this for initialization
	void Awake () {


	}

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void setIsBossRound(bool b){
		isBossRound = b;
	}

	public void EnemyDied ()  // Faut que chaque enemy ait une ref vers sont round manager
	{
		nbEnemiesDead++;
		CheckNbDiedEnemis();
	}

	void CheckNbDiedEnemis ()
	{
		if (nbEnemiesDead == roundInfo.nbEnemies && !isBossRound) {
			GameObject.FindGameObjectWithTag ("progressBar_ui").GetComponent<ProgressBar> ().NextRound ();

			if (roundInfo.isLastRound) {
				levelManagerOwner.EndLastRound ();
			} else {
				levelManagerOwner.NextRound ();
			}

		}// else if (isBossRound) {
			//levelManagerOwner.NextRound ();
		//}

	}

	public void EndBossRound(){
		GameObject.FindGameObjectWithTag ("progressBar_ui").GetComponent<ProgressBar> ().EndBossPhase ();

		GameObject[] lGo = GameObject.FindGameObjectsWithTag ("Player");
		foreach (GameObject g in lGo) {
			PlayerHealth ph = g.GetComponent<PlayerHealth> ();
			if (!ph.isItDying ()) {
				ph.ModifHealth (-100);
			}
		}

		levelManagerOwner.EndLastRound ();
	}
		
	public void SpawnEnemy(){
		
		if (!isBossRound) {


			

			Debug.Log ("Spawn Enemies");
			Transform currentTransform;
			int index = 0;
			int count = spawnningPoints.Count;

			GameManager gm = GameObject.FindWithTag ("GameManager").GetComponent<GameManager> ();
			for (int i = 0; i < roundInfo.nbEnemies; i++) {

				enemyPrefab = GameObject.FindWithTag ("GameManager").GetComponent<GameInfo> ().getRandomEnemyAtLevelIndex (levelManagerOwner.getCurrentLevelIndex());

				currentTransform = spawnningPoints [index];
				if (enemyPrefab == null) {
					Debug.Log ("dafuq2");
				}
				GameObject go = Instantiate (enemyPrefab, gm.randomPosition(), transform.rotation) as GameObject;
				go.GetComponent<EnemyHealth> ().setRoundManagerOwner (this);

				go.GetComponent<IAAttackLogic> ().StartAppearing (2f);

				index++;
				if (index == count) {
					index = 0;
				}
			}
		} else {

			SpawnBoss ();

		}
			
	}

	protected void SpawnBoss(){

		Debug.Log ("BOSS ROUND");
	/*	enemyPrefab = GameObject.FindWithTag ("GameManager").GetComponent<GameInfo> ().getBossAtIndex (levelManagerOwner.getCurrentLevelIndex());
		Transform currentTransform = spawnningPoints [0];
		GameObject go = Instantiate (enemyPrefab, currentTransform.position, transform.rotation) as GameObject;
		go.GetComponent<EnemyHealth> ().setRoundManagerOwner (this);*/

		GameObject.FindWithTag ("CinematicManager").GetComponent<CinematicManager> ().ActivateCinematicAtIndex (levelManagerOwner.getCurrentLevelIndex ());

		/*
		CameraFlow c = GameObject.FindGameObjectWithTag ("MainCamera").GetComponent<CameraFlow>();

		go.GetComponent<IAAttackLogic> ().StartAppearing ();
		c.StartBossCinematic ();

		float timer = go.GetComponent<IAAttackLogic> ().GetAppearDuration();
		c.Invoke("EndBossCinematic",timer);*/
		//go.GetComponent<IAAttackLogic> ().StartAppearing ();
	}
		
}
