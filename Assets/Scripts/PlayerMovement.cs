using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour {

	public int playerNumber;

	public float speed;
	Rigidbody2D rbody;
	Animator anim;
	Vector2 velocity;
	Vector2 movement_vector;

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
		float horizontal = Input.GetAxis("LeftJoystickHorizontal_P"+playerNumber);
		float vertical = Input.GetAxis("LeftJoystickVertical_P"+playerNumber);

		movement_vector = new Vector2 (horizontal, vertical);
		if (horizontal != 0 || vertical != 0) {
			anim.SetBool ("isWalking", true);
			anim.SetFloat ("input_x", horizontal);
			anim.SetFloat ("input_y", vertical);
		} else {
			anim.SetBool ("isWalking", false);
		}
	}

	void ProcessMovement(){
		movement_vector.Normalize ();
		rbody.MovePosition (rbody.position + movement_vector * Time.fixedDeltaTime*speed);

	}

}
