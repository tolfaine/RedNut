using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Pause : MonoBehaviour
{

    private bool pauseEnabled = false;
    public GameObject menuPause;

	public List<AudioClip> pauseIn = new List<AudioClip>(1);
	public List<AudioClip> pauseOut = new List<AudioClip>(1);

	public float volume = 1f;

    void Start()
    {
        menuPause.SetActive(false);
        pauseEnabled = false;
        Time.timeScale = 1;
        AudioListener.volume = 1;;
    }

    void Update()
    {

		if (Input.GetButtonDown("Pause_P1") || Input.GetButtonDown("Pause_P2"))
        {
			Debug.Log ("Pause");

            if (pauseEnabled) { restart(); }
            else { pause(); }
        }
    }

    public void restart()
    {
		playRandomOutSound ();

        pauseEnabled = false;
        menuPause.SetActive(false);
        Time.timeScale = 1;
        //AudioListener.volume = 1;
    }

    public void pause()
    {
		if (!transform.parent.FindChild ("GameOver").GetComponent<GameOver>().over) {
			playRandomINSound ();

			menuPause.SetActive (true);
			pauseEnabled = true;
			// AudioListener.volume = 0;
			Time.timeScale = 0;
		}
    }

	public AudioClip randomShotIn(){
		if (pauseIn.Count > 0) {
			int rand = Random.Range (0, pauseIn.Count);
			return pauseIn [rand];
		}

		return null;
	}

	public void playRandomINSound(){

		AudioClip clip = randomShotIn ();
		if (clip != null) {
			AudioSource source = CustomAudioSource.PlayClipAt (clip, transform.position);
			source.volume = volume;
		}
	
	}

	public AudioClip randomShotOut(){
		if (pauseOut.Count > 0) {
			int rand = Random.Range (0, pauseOut.Count);
			return pauseOut [rand];
		}

		return null;
	}

	public void playRandomOutSound(){

		AudioClip clip = randomShotOut ();
		if (clip != null) {
			AudioSource source = CustomAudioSource.PlayClipAt (clip, transform.position);
			source.volume = volume;
		}

	}

}
