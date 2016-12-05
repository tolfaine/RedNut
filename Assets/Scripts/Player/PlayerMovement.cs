using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PlayerMovement : MonoBehaviour {

	public int playerNumber;
	public float speed;

	Rigidbody2D rbody;
	Animator anim;
	Vector2 velocity;
	Vector2 movement_vector;
	Vector2 direction_vector;

	public List<AudioClip> footSteps;

	public bool dead;

	public List<AudioClip> startGameSound = new List<AudioClip> ();
	public float volumeStart = 1f;


	public AudioClip randomStartSound(){
		if (startGameSound.Count > 0) {
			int rand = Random.Range (0, startGameSound.Count);
			return startGameSound [rand];
		}

		return null;
	}

	public void playRandomStartSound(){
		AudioClip clip = randomStartSound ();
		if (clip != null) {
			AudioSource source =  CustomAudioSource.PlayClipAt (clip, transform.position);
			source.volume = volumeStart;

		}
	}

	void Start () {
		rbody = GetComponent<Rigidbody2D> ();
		anim = GetComponent<Animator> ();

		if (playerNumber == 1) {
			playRandomStartSound ();
		}

	}

	void Update () {
		if (!dead) {
			ProcessInput ();
		}
	}

	void FixedUpdate(){
		if (!dead) {
			ProcessMovement ();
		}
	}

	public AudioClip randomFootstep(){
		if (footSteps.Count > 0) {
			int rand = Random.Range (0, footSteps.Count);
			return footSteps [rand];
		}

		return null;
	}


	public void PlayFootStep(){
		AudioClip clip = randomFootstep ();

		if (clip != null) {
			CustomAudioSource.PlayClipAt (clip, transform.position);
		}
	}

	void ProcessInput(){
		float LeftHorizontal = Input.GetAxis("LeftJoystickHorizontal_P"+playerNumber);
		float LeftVertical = Input.GetAxis("LeftJoystickVertical_P"+playerNumber);
		movement_vector = new Vector2 (LeftHorizontal, LeftVertical);

		float RightHorizontal = Input.GetAxis("RightJoystickHorizontal_P"+playerNumber);
		float RightVertical = Input.GetAxis("RightJoystickVertical_P"+playerNumber);
		direction_vector = new Vector2 (RightHorizontal, RightVertical);

		bool isShooting = false;
		if (RightHorizontal != 0 || RightVertical != 0) {
			isShooting = true;
		}


		if (isShooting) {
			if (LeftHorizontal != 0 || LeftVertical != 0) {
				anim.SetBool ("isWalking", true);
				anim.SetFloat ("input_x", RightHorizontal);
				anim.SetFloat ("input_y", RightVertical);
			} else {
				anim.SetBool ("isWalking", false);
				anim.SetFloat ("input_x", RightHorizontal);
				anim.SetFloat ("input_y", RightVertical);
			}
		} else {
			if (LeftHorizontal != 0 || LeftVertical != 0) {
				anim.SetBool ("isWalking", true);
				anim.SetFloat ("input_x", LeftHorizontal);
				anim.SetFloat ("input_y", LeftVertical);
			} else {
				anim.SetBool ("isWalking", false);
			}
		}


	}

	void ProcessMovement(){
		movement_vector.Normalize ();
		rbody.MovePosition (rbody.position + movement_vector * Time.fixedDeltaTime*speed);

	}

}
