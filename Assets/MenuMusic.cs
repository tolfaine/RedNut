using UnityEngine;
using System.Collections;

public class MenuMusic : MonoBehaviour {

	AudioSource source;


	void OnLevelWasLoaded(int level){

		if (level >= 4) {
			Destroy (this.gameObject);
		}
	}


	void Awake(){

	}

	// Use this for initialization
	void Start () {

		if (GameObject.FindGameObjectsWithTag ("MenuMusic").Length >= 2) {
			Destroy (this.gameObject);
		} else {
			DontDestroyOnLoad (this.gameObject);
		}

		source = GetComponent<AudioSource> ();
		source.Play ();
	}
	
	// Update is called once per frame
	void Update () {
	
	}


}
