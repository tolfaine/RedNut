using UnityEngine;
using System.Collections;
using System.Collections.Generic;


public enum BossCinematicState{Inactive,Car,Spawn,Walking,Finished};


public class BossCinematic : MonoBehaviour {

	public BossCinematicState state = BossCinematicState.Inactive;
	private RoundManager roundOwner;
	public bool triggeredOnce = false;

	public BossCinematicInfo bossCinematicInfo;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		switch (state) {
		case BossCinematicState.Inactive:
			break;
		case BossCinematicState.Car:
			MoveCar ();
			break;
		case BossCinematicState.Spawn:
			SpawnBossAndMinions ();
			break;
		case BossCinematicState.Walking:
			MoveBossToCenter ();
			break;
		case BossCinematicState.Finished:
			break;
		}
	}

	void SetCameraCenterPoint(Transform newTarget){

	}


	void MoveCar(){
		if (triggeredOnce) {
			bossCinematicInfo.car.GetComponent<Animator> ().SetBool ("isMoving", true);
		}

	}

	void SpawnBossAndMinions(){
		if (triggeredOnce) {

		}

	}

	void MoveBossToCenter(){
		if (triggeredOnce) {

		}

	}

	void changeState(BossCinematicState newState){
		triggeredOnce = false;
		state = newState;
	}

}

[System.Serializable]
public class BossCinematicInfo{
	public GameObject boss;
	public List<GameObject> minions;
	public GameObject gate;
	public GameObject car;
}
