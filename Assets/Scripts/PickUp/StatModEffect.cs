using UnityEngine;
using System.Collections;

public class StatModEffect : Effect {

	public enumStat typeStat;

	protected override void ApplyEffect(){

		switch (typeStat) {
		case enumStat.Phase:
			PhaseManager pm = target.GetComponentInChildren<PhaseManager> ();
			pm.addPoints (1);
			break;
		case enumStat.Health:
			Health h = target.GetComponentInChildren<Health> ();
			h.ModifHealth (-(int)modValue);
			break;
		}
	}
}
