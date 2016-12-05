using UnityEngine;
using System.Collections;

public class ProgressBar : MonoBehaviour {

	public int nbRound;
	public int currentRound=0;
	public int previousRound =0;

	public int bossMaxLife;
	public int currentBossLife =0;
	public int previousBossLife=0;

	public bool isBoss = false;

	public bool triggerBossPhase;
	public bool triggerRoundPhase;
	// Use this for initialization
	void Start () {
		GetComponent<UISlider> ().value = 0f;
	}
	
	// Update is called once per frame
	void Update () {

		if (isBoss) {
			if (!triggerBossPhase) {
				
				triggerBossPhase = true;
				GetComponent<UISlider> ().value = MapValueRangeProgress (currentRound);
				GameObject.FindGameObjectWithTag ("skull_ui").GetComponent<Animator> ().SetBool ("isBoss", true);
				GetComponent<UISlider> ().fillDirection = UIProgressBar.FillDirection.RightToLeft;

				GetComponent<UISlider> ().fillDirection = UIProgressBar.FillDirection.RightToLeft;

				transform.FindChild ("Bg").GetComponent<UISprite> ().color = new Color (0.90f,0.10f,0.10f);
				transform.FindChild ("Backdrop").GetComponent<UISprite>().color = new Color (0.188f,0.188f,0.188f);
				transform.FindChild ("Overlay").GetComponent<UISprite>().color = new Color (0.90f,0.10f,0.10f);


				GameObject.FindGameObjectWithTag ("skull_ui").transform.FindChild ("Bg").GetComponent<UISprite>().color = new Color (0.90f,0.10f,0.10f);
				GameObject.FindGameObjectWithTag ("skull_ui").transform.FindChild ("Backdrop").GetComponent<UISprite>().color = new Color (0.188f,0.188f,0.188f);
				GameObject.FindGameObjectWithTag ("skull_ui").transform.FindChild ("Skull").GetComponent<UISprite>().color = new Color (0.90f,0.10f,0.10f);

			}

			if (previousBossLife != currentBossLife) {
				previousBossLife = currentBossLife;
				float f = MapValueRangeBossLife (currentBossLife);
				Debug.Log (f);
				GetComponent<UISlider> ().value = MapValueRangeBossLife (currentBossLife);
			}



		} else {
			if (!triggerRoundPhase) {
				triggerRoundPhase = true;
				GameObject.FindGameObjectWithTag ("skull_ui").GetComponent<Animator> ().SetBool ("isBoss", false);
				GetComponent<UISlider> ().fillDirection = UIProgressBar.FillDirection.LeftToRight;
				GetComponent<UISlider> ().value = MapValueRangeProgress (0);

				transform.FindChild ("Bg").GetComponent<UISprite> ().color = new Color (0.192f,0.192f,0.192f);
				transform.FindChild ("Backdrop").GetComponent<UISprite>().color = new Color (0.56f,0.56f,0.56f);
				transform.FindChild ("Overlay").GetComponent<UISprite>().color = new Color (0.22f,0.43f,0.81f);


				GameObject.FindGameObjectWithTag ("skull_ui").transform.FindChild ("Bg").GetComponent<UISprite>().color = new Color (0.192f,0.192f,0.192f);
				GameObject.FindGameObjectWithTag ("skull_ui").transform.FindChild ("Backdrop").GetComponent<UISprite>().color = new Color (0.48f,0.48f,0.48f);
				GameObject.FindGameObjectWithTag ("skull_ui").transform.FindChild ("Skull").GetComponent<UISprite>().color = new Color (0.88f,0.88f,0.88f);
			}

			if (previousRound != currentRound) {
				previousRound = currentRound;
				GetComponent<UISlider> ().value = MapValueRangeProgress (currentRound);
			}

		}
	}
		
	public void EndBossPhase(){
		isBoss = false;
		currentRound = 0;
		triggerBossPhase = false;
	}

	public void SetBossLife(int life){
		
		currentBossLife = life;
	}

	public void NextRound() {
		currentRound++;
		Debug.Log (currentRound);

		if (currentRound == nbRound) {
			isBoss = true;
			triggerRoundPhase = false;

		} 
	}

	public float MapValueRangeProgress(float value) {
		return (value - 0f) / (nbRound - 0f) * (1f - 0f) + 0f;
	}

	public float MapValueRangeBossLife(int value) {
		return (value - 0f) / (bossMaxLife - 0f) * (1f - 0f) + 0f;
	}
}
