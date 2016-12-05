using UnityEngine;
using System.Collections;

public class myBonus : MonoBehaviour {

	public float control_jauge_f = 0f;
	public float maxJauge= 1f;
	public float lastjauge =0f;
	public float lastjaugeMapped =0f;

	// Update is called once per frame
	void Start (){
		GetComponent<UISlider> ().value = 0f;
	}

	void Update () {
		
			float newValue = MapValueRangeLife (control_jauge_f);
		GetComponent<UISlider> ().value = newValue;


		if (GetComponent<UISlider> ().value <= 0) {

			transform.FindChild ("Overlay").gameObject.SetActive (false);
			transform.FindChild ("Icone").gameObject.SetActive (false);
				
		} else {

			transform.FindChild ("Overlay").gameObject.SetActive (true);
			transform.FindChild ("Icone").gameObject.SetActive (true);


		}

	}

	public void SetJauge(float jauge) {
		control_jauge_f = jauge;
	}
		

	public float MapValueRangeLife(float value) {
		return (value - 0f) / (maxJauge - 0f) * (1f - 0f) + 0f;
	}
}
