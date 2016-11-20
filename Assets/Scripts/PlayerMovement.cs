using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour {

	public int playerNumber;
	public float speed;

	Rigidbody2D rbody;
	Animator anim;
	Vector2 velocity;
	Vector2 movement_vector;
	Vector2 direction_vector;

	void Start () {
		rbody = GetComponent<Rigidbody2D> ();
		anim = GetComponent<Animator> ();
	}

	void Update () {
		ProcessInput ();
	}

	void FixedUpdate(){
		
		ProcessMovement ();
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
