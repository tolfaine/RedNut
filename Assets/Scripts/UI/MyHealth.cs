using UnityEngine;
using System.Collections;

public class MyHealth : MonoBehaviour {
	public float control_life_f = 0f;
	public float maxHealthPlayer = 1f;
	public float lastLife =0f;

	UIProgressBar lifeProgressBar;

	// Update is called once per frame
	void Start (){
		GetComponent<UIProgressBar> ().value = 1f;
	}

	void Update () {

		if (control_life_f != lastLife) {
			lastLife = control_life_f;
			float newValue = MapValueRangeLife (control_life_f);
			GetComponent<UIProgressBar> ().value = newValue;
		}


	}

	public void SetLife(float life) {
		control_life_f = life;
	}

	public float MapValueRangeLife(float value) {
		return (value - 0f) / (maxHealthPlayer - 0f) * (1f - 0f) + 0f;
	}

}
