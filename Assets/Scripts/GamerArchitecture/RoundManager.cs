using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[System.Serializable]
public class RoundManager : MonoBehaviour {

	public int nbEnemiesDead;
	public RoundInfo roundInfo;
	public List<Transform> spawnningPoints;
	public GameObject enemyPrefab;

	private LevelManager levelManagerOwner;

	public void setValues(RoundInfo newRoundInfo,List<Transform> newSpawnningPoints,LevelManager owner){
		spawnningPoints = newSpawnningPoints;
		roundInfo = newRoundInfo;
		levelManagerOwner = owner;
	}


	// Use this for initialization
	void Awake () {
		enemyPrefab = GameObject.FindWithTag ("GameManager").GetComponent<GameInfo>().getEnemyPrefab();

	}

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
	
	}


	public void EnemyDied ()  // Faut que chaque enemy ait une ref vers sont round manager
	{
		nbEnemiesDead++;
		CheckNbDiedEnemis();
	}

	void CheckNbDiedEnemis ()
	{
		if (nbEnemiesDead == roundInfo.nbEnemies) {
			levelManagerOwner.NextRound ();
		}

	}
		
	public void SpawnEnemy(){
		Debug.Log ("Spawn Enemies");
		Transform currentTransform;
		int index = 0;
		int count = spawnningPoints.Count;
		for (int i = 0; i < roundInfo.nbEnemies; i++) {
			currentTransform = spawnningPoints [index];
			if (enemyPrefab == null) {
				Debug.Log ("dafuq2");
			}
			GameObject go = Instantiate (enemyPrefab, currentTransform.position, transform.rotation) as GameObject;
			go.GetComponent<EnemyHealth> ().setRoundManagerOwner (this);

			index++;
			if (index == count) {
				index = 0;
			}
		}
			
	}

}
