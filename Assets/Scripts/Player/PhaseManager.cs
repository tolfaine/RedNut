using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PhaseManager : MonoBehaviour {

	Animator anim;
	public float ptsForNextPhase;
	public float currentNbPoints = 0;
	public int currentPhase = 0;
	public int maxPhase = 0 ;
	public MyPhase phase_ui;

	public int playerNumber;

	public List<AudioClip> listSounEvol = new List<AudioClip> (1);
	public float volumeEvol = 1f;

	// Use this for initialization
	void Start () {

		anim = GetComponent<Animator> ();
		anim.SetInteger ("phase", currentPhase);

		phase_ui = GameObject.FindGameObjectWithTag ("HUD").transform.FindChild("Control-clope_"+ playerNumber).GetComponent<MyPhase> ();
		phase_ui.maxPhaseJaugePlayer = ptsForNextPhase;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void addPoints(int pts){
		
		currentNbPoints += pts;
		phase_ui.SetJaugePhase(currentNbPoints);

		if (currentNbPoints >= ptsForNextPhase) {
			if (currentPhase < maxPhase) {
				playRandomEvolSound ();
				currentPhase++;
				currentNbPoints = 0;
				anim.SetInteger ("phase", currentPhase);
				phase_ui.SetPhase(currentPhase);
				GameObject.FindGameObjectWithTag ("PhaseMusicManager").GetComponent<PhaseMusicManager> ().ChangePhase (currentPhase);

			}
		}
	}


	public void playRandomEvolSound(){
		AudioClip clip = listSounEvol [currentPhase];
		if (clip != null) {
			AudioSource source =  CustomAudioSource.PlayClipAt (clip, transform.position);
			source.volume = volumeEvol;
		}
	}




}
