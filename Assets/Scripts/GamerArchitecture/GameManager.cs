using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GameManager : MonoBehaviour {

	private GameInfo gameInfo;

	private GameObject currentGameObjectSessionManager;
	private SessionManager currentSessionManager;
	private int currentSessionManagerIndex = 0;

	public List<Transform> spawnningPoints;

	// Use this for initialization
	void Start () {
		gameInfo = transform.GetComponent<GameInfo> ();
		startSinglePlayerGame ();

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

	void CreateSession(){
		currentGameObjectSessionManager = new GameObject ();
		currentGameObjectSessionManager.AddComponent<SessionManager> ();
		currentGameObjectSessionManager.name = "SessionManager";

		currentSessionManager = currentGameObjectSessionManager.GetComponent<SessionManager> ();
		currentSessionManager.setValues (gameInfo.listSession [currentSessionManagerIndex], this);
	}

	public void EndGame(){
		Debug.Log ("GG EZ");
	}
}
