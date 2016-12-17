using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GameManager : MonoBehaviour {

	private GameInfo gameInfo;

	public GameObject prefabPlayer;
	public GameObject prefabPlayer2;

	private GameObject currentGameObjectSessionManager;
	private SessionManager currentSessionManager;
	private int currentSessionManagerIndex = 0;

	public GameObject firstWeapon;
	public GameObject IaWeapon;

	public Transform height;
	public Transform width;

	public List<Transform> spawnningPoints;


	public List<AudioClip> dieSounds = new List<AudioClip>(1);
	public float volumeDead = 1f;


	public int nbPlayer = 2;

	public AudioClip randomDeadSound(){
		int rand = Random.Range(0,dieSounds.Count);

		return dieSounds [rand];
	}

	public Vector3 randomPosition(){

		Vector3 PlayerCenterPoint = GameObject.FindGameObjectWithTag ("PlayerCenterPoint").transform.position;

		float minHeight = PlayerCenterPoint.x - 50 ;
		float maxHeight = PlayerCenterPoint.x + 50 ;
		float minWidth = PlayerCenterPoint.y - 50 ;
		float maxWidth = PlayerCenterPoint.y + 50 ;


		float x = Random.Range (-width.position.x, width.position.x);
		float y = Random.Range (-height.position.y, height.position.y);

		return new Vector3 (x, y, 0f);

	}


	// Use this for initialization
	void Start () {
		/*
		GameObject g = GameObject.FindGameObjectWithTag ("NbPlayerManager");

		if (g != null) {
			nbPlayer = g.GetComponent<NbPlayerManager> ().nbPlayer;
		
		}*/

		gameInfo = transform.GetComponent<GameInfo> ();
		startMultiPlayerGame ();
		/*
		if (nbPlayer >= 2) {
			startMultiPlayerGame ();
		} else {
			startSinglePlayerGame ();
		}*/


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

		GameObject.FindGameObjectWithTag ("UI_1").SetActive (true);
		GameObject.FindGameObjectWithTag ("UI_2").SetActive (false);
		CreateSession ();

	}

	void startMultiPlayerGame(){
		Debug.Log ("Start Multi Player Game");
		currentSessionManagerIndex = 1;

		GameObject.FindGameObjectWithTag ("UI_1").SetActive (false);
		GameObject.FindGameObjectWithTag ("UI_2").SetActive (true);


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
			GameObject go;
			if (i == 0) {
				go = Instantiate (prefabPlayer, this.transform.position, this.transform.rotation) as GameObject; 
			} else {
				go = Instantiate (prefabPlayer2, this.transform.position, this.transform.rotation) as GameObject; 
			}

			GameObject weaponPoint =  go.transform.Find("BrasAnchor/Bras/WeaponPoint").gameObject;
			GameObject weaponHolding = Instantiate (firstWeapon, this.transform.position, this.transform.rotation) as GameObject; 
			weaponHolding.GetComponentInChildren<Weapon> ().isAlly = true;
			weaponHolding.transform.parent = weaponPoint.transform;
			weaponHolding.transform.localPosition = Vector3.zero;

			PlayerAttackLogic playerAttackLogic = go.GetComponent<PlayerAttackLogic>();
			playerAttackLogic.SetPlayerNumber(i+1);

			PlayerMovement playerMovement = go.GetComponent<PlayerMovement>();
			playerMovement.playerNumber = playerAttackLogic.playerNumber;
	
		}

		PlayerCenterPoint playerCenterPoint = GameObject.FindGameObjectWithTag ("PlayerCenterPoint").GetComponent<PlayerCenterPoint>();
		playerCenterPoint.findPlayers ();
	}

	public void EndGame(){


		GameObject.FindGameObjectWithTag ("Win").GetComponent<Win> ().PlayerWon ();
		Debug.Log ("GG EZ");
	}
}
