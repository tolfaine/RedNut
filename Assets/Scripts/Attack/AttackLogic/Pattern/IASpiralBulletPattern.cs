using UnityEngine;
using System.Collections;

public class IASpiralBulletPattern : IAPattern {
	public int degInc= 45;

	protected int currentDeg =0;

	protected override void ProcessPattern(){
		owner.bras.eulerAngles = new Vector3 (owner.bras.eulerAngles.x, owner.bras.eulerAngles.y, currentDeg);

		currentDeg += degInc;

		if (currentDeg >= 360) {
			currentDeg = 0;
		}


		Vector3 dir = Quaternion.AngleAxis (currentDeg, Vector3.forward) * Vector3.right;
		dir.Normalize ();


		owner.AttackNoCD (dir);
	}


}
