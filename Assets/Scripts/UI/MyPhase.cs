using UnityEngine;
using System.Collections;

public class MyPhase : MonoBehaviour {

	public float control_jaugePhase_f = 0f;
	public float maxPhaseJaugePlayer = 1f;
	public float lastjaugePhase =0f;

	public int currentPhase = -1;
	public int lastPhase = -1;

	// Update is called once per frame
	void Start (){
		GetComponent<UISlider> ().value = 0f;
	}

	void Update () {

		if (currentPhase != lastPhase) {
			lastPhase = currentPhase;
		}

		if (control_jaugePhase_f != lastjaugePhase) {
			lastjaugePhase = control_jaugePhase_f;
			float newValue = MapValueRangeLife (control_jaugePhase_f);
			GetComponent<UISlider> ().value = newValue;
		}


	}

	public void SetJaugePhase(float jaugePhase) {
		control_jaugePhase_f = jaugePhase;
	}

	public void SetPhase(int phase) {
		currentPhase = phase;
	}


	public float MapValueRangeLife(float value) {
		return (value - 0f) / (maxPhaseJaugePlayer - 0f) * (1f - 0f) + 0f;
	}

}
