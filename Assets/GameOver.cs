using UnityEngine;
using System.Collections;

public class GameOver : MonoBehaviour {

	public AudioClip gameoverSound;

	public GameObject display;

	public bool over =false;

	public void PlayerLost(){
		over = true;
		CustomAudioSource.PlayClipAt (gameoverSound, this.gameObject.transform.position);
		display.SetActive (true);

		//GameObject.FindGameObjectWithTag ("Pause").GetComponent<Pause> ().pause ();
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
