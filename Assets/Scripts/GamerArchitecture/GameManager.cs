using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GameManager : MonoBehaviour {

	private GameInfo gameInfo;

	public GameObject prefabPlayer;
	private GameObject currentGameObjectSessionManager;
	private SessionManager currentSessionManager;
	private int currentSessionManagerIndex = 0;

	public List<Transform> spawnningPoints;

	// Use this for initialization
	void Start () {
		gameInfo = transform.GetComponent<GameInfo> ();
		startMultiPlayerGame ();

	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void startTutoGame(){
		currentSessionManagerIndex = 0;
		CreateSession ();
	}

	void startSinglePlayerGame(){
		Debug.Log ("Start Single Player Game");
		currentSessionManagerIndex = 1;
		CreateSession ();

	}

	void startMultiPlayerGame(){
		Debug.Log ("Start Multi Player Game");
		currentSessionManagerIndex = 2;
		CreateSession ();
	}

	void CreateSession(){
		currentGameObjectSessionManager = new GameObject ();
		currentGameObjectSessionManager.AddComponent<SessionManager> ();
		currentGameObjectSessionManager.name = "SessionManager";

		currentSessionManager = currentGameObjectSessionManager.GetComponent<SessionManager> ();
		currentSessionManager.setValues (gameInfo.listSession [currentSessionManagerIndex], this);

		int nbP = gameInfo.listSession [currentSessionManagerIndex].nbPlayers;

		for (int i = 0; i < nbP; i++) {
			GameObject go =  Instantiate (prefabPlayer, this.transform.position, this.transform.rotation) as GameObject; 

			PlayerAttackLogic playerAttackLogic = go.GetComponent<PlayerAttackLogic>();
			playerAttackLogic.playerNumber = i+1;

			PlayerMovement playerMovement = go.GetComponent<PlayerMovement>();
			playerMovement.playerNumber = i+1;
	
		}
	}

	public void EndGame(){
		Debug.Log ("GG EZ");
	}
}
