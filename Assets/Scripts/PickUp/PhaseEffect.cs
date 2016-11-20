using UnityEngine;
using System.Collections;

public class PhaseEffect : Effect {
	
	private enumStat typeStat = enumStat.Phase;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	protected override void ApplyEffect(){
		PhaseManager pm = target.GetComponentInChildren<PhaseManager> ();
		pm.addPoints (1);
	}

}
