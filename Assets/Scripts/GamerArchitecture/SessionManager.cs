using UnityEngine;
using System.Collections;

public class SessionManager : MonoBehaviour {

	private GameManager gameManagerOwner;
	public SessionInfo sessionInfo;

	private GameObject currentGameObjectLevelManager;
	private LevelManager currentLevelManager;

	private int nextLevelManagerIndex = 0;


	public void setValues(SessionInfo newSessionInfo, GameManager owner ){
		
		sessionInfo = newSessionInfo;
		gameManagerOwner = owner;

		NextLevel ();

	}

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void NextLevel ()
	{

		Destroy (currentGameObjectLevelManager);


		int listSize = sessionInfo.listLevel.Count;

		if (nextLevelManagerIndex <= listSize-1) {
			Debug.Log ("Next Level!");
			currentGameObjectLevelManager = new GameObject ();
			currentGameObjectLevelManager.AddComponent<LevelManager> ();
			currentGameObjectLevelManager.name = "LevelManager";

			currentLevelManager = currentGameObjectLevelManager.GetComponent<LevelManager> ();

			currentLevelManager.setValues (sessionInfo.listLevel [nextLevelManagerIndex],gameManagerOwner.spawnningPoints,nextLevelManagerIndex, this);
			nextLevelManagerIndex++;
		} else {
			gameManagerOwner.EndGame ();

		}
	}

}
