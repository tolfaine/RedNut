using UnityEngine;
using System.Collections;

public class PhaseManager : MonoBehaviour {

	Animator anim;
	public float ptsForNextPhase;
	public float currentNbPoints = 0;
	public int currentPhase = 0;
	public int maxPhase = 0 ;

	// Use this for initialization
	void Start () {

		anim = GetComponent<Animator> ();
		anim.SetInteger ("phase", currentPhase);
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void addPoints(int pts){
		
		currentNbPoints += pts;

		if (currentNbPoints >= ptsForNextPhase) {
			if (currentPhase < maxPhase) {
				currentPhase++;
				currentNbPoints = 0;

				anim.SetInteger ("phase", currentPhase);
			}
		}

		Debug.Log ("Add point" + "   " + currentNbPoints + "   " + maxPhase + "   " + currentPhase);
	}


}
