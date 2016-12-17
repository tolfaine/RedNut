using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PhaseMusicManager : MonoBehaviour {

	public List<AudioClip> listPhaseMusic = new List<AudioClip>(1);

	public List<AudioSource> sources = new List<AudioSource>(1);

	public int currenteSource = 0;
	public int lastSource = 1;

	public bool fadeSource = false;

	public int currentPhase = 0;

	public int newPhase;

	public bool waitingForTempo = false;

	private float freq = 60f / 175f;
	public float currentFreq = 0f;

	private float volume = 0.5f;


	// Use this for initialization
	void Start () {

	sources.AddRange(GetComponents<AudioSource>());
			
		sources[0].volume = volume;

		if (listPhaseMusic.Count > 0) {
			sources[0].clip = listPhaseMusic [currentPhase];
			sources[0].Play ();
		}

	}


	public void ChangePhase(int newPhase){

		if (newPhase > currentPhase) {
			waitingForTempo = true;
			this.newPhase = newPhase;

			if (currenteSource == 0) {
				currenteSource = 1;
				lastSource = 0;
			} else {
				currenteSource = 0;
				lastSource = 1;

			}
		}
	}


	// Update is called once per frame
	void Update () {
	
		currentFreq += Time.deltaTime;

		if (currentFreq >= freq) {
			currentFreq = 0f;

			if (waitingForTempo) {
				waitingForTempo = false;

				//fadeSource = true;
				sources [lastSource].Stop();
				sources[currenteSource].clip = listPhaseMusic [newPhase];
				sources[currenteSource].Play ();

				if (newPhase == 2) {
					sources[currenteSource].volume = 0.6f;
				}if (newPhase == 3) {
					sources [currenteSource].volume = 0.7f;
				} else {
					
					sources [currenteSource].volume = volume;
				}

				currentPhase = newPhase;
			}

		}
		/*
		if (fadeSource) {
			if (sources [lastSource].volume > 0) {
				sources [lastSource].volume -= Time.deltaTime;
			} else {
				fadeSource = false;
			}
		}*/


	}
}
