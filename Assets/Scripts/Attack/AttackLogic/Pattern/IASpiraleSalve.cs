using UnityEngine;
using System.Collections;

public class IASpiraleSalve : IAPattern {

	public int degInc= 20;
	public int currentDeg = 0;
	public bool right = true;

	protected override void ProcessPattern(){

		Vector3 v = owner.GetMovementVector ();
		float deg = Vector2.Angle (new Vector2 (1, 0), v);
		if (v.y < 0) {
			deg = 360 - deg;
		}

		owner.bras.eulerAngles = new Vector3 (owner.bras.eulerAngles.x, owner.bras.eulerAngles.y, deg+currentDeg);

		if (currentDeg == degInc * 4) {
			right = false;
		}else if(currentDeg == -degInc * 4){
			right = true;
		}

		if (right) {
			currentDeg += degInc;
		} else {
			currentDeg -= degInc;
		}


		Vector3 dir = Quaternion.AngleAxis (deg+currentDeg, Vector3.forward) * Vector3.right;
		dir.Normalize ();

		owner.AttackNoCD (dir);
	}

}
