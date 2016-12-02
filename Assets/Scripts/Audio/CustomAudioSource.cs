using UnityEngine;
using System.Collections;

public class CustomAudioSource : MonoBehaviour {

	public static AudioSource PlayClipAt(AudioClip audioClip, Vector3 position){
		GameObject go =new GameObject ();
		go.name = "Custom Audio Source Instance";
		go.transform.position = position;
		go.transform.parent = GameObject.FindGameObjectWithTag ("SoundManager").transform;
		AudioSource audioSource = go.AddComponent<AudioSource> ();
		audioSource.clip = audioClip;
		audioSource.Play ();
		Destroy (go, audioClip.length);
		return audioSource;
	}
}
