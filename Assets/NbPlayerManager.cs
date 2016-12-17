using UnityEngine;
using System.Collections;

public class NbPlayerManager : MonoBehaviour {

	public int nbPlayer;


	// Use this for initialization
	void Start () {
		if (GameObject.FindGameObjectsWithTag ("NbPlayerManager").Length >= 2) {
			Destroy (this.gameObject);
		} else {
			DontDestroyOnLoad (this.gameObject);
		}
	}
}
