using UnityEngine;
using System.Collections;

public class Win : MonoBehaviour {
	public AudioClip winSound;
	public GameObject display;

	public void PlayerWon(){
		CustomAudioSource.PlayClipAt (winSound, this.gameObject.transform.position);
		display.SetActive (true);

		Time.timeScale = 0;

		AudioSource[] a = GameObject.FindGameObjectWithTag ("PhaseMusicManager").GetComponents<AudioSource> ();

		foreach (AudioSource source in a) {
			source.Stop ();
		}

		AudioSource a2 = GameObject.FindGameObjectWithTag ("SoundManager").GetComponent<AudioSource> ();

		a2.Stop();
	}

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
