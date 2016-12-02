using UnityEngine;
using System.Collections;

public class CirclePattern : IAPattern {

	public int degInc= 45;
	public bool decal = false;

	protected override void ProcessPattern(){

		if (!decal) {
			decal = true;

			for (int i = 0; i < 360; i = i + degInc) {
				owner.bras.eulerAngles = new Vector3 (owner.bras.eulerAngles.x, owner.bras.eulerAngles.y, i);

				Vector3 dir = Quaternion.AngleAxis (i, Vector3.forward) * Vector3.right;
				dir.Normalize ();
				owner.AttackNoCD (dir);
			}
		} else {
			decal = false;
			int firstI = degInc / 2;

			Debug.Log (firstI);
			for (int i = firstI; i < 360; i = i + degInc) {
				owner.bras.eulerAngles = new Vector3 (owner.bras.eulerAngles.x, owner.bras.eulerAngles.y, i);

				Vector3 dir = Quaternion.AngleAxis (i, Vector3.forward) * Vector3.right;
				dir.Normalize ();
				owner.AttackNoCD (dir);
			}
		}


	}

}
