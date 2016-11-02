using UnityEngine;
using System.Collections;

public class BasicChasingIA : MonoBehaviour {
	
	public float speed;
	public float range;

	Transform player;
	Rigidbody2D rbody;
	Gun enemyGun;
	Vector2 direction;
	bool playerInSight;
	float playerDistance;
	bool isAttacking;

	void Start () {
		player = GameObject.FindGameObjectWithTag ("Player").transform;
		rbody = GetComponent<Rigidbody2D> ();
		enemyGun = GetComponent<Gun> ();
	}

	void Update () {
		direction = player.position - transform.position;


	}

	void FixedUpdate(){
		playerDistance = direction.magnitude;
		direction.Normalize ();

		if (playerDistance < range) {
		//	Debug.Log ("Attack");
			StopMoving ();
			Attack ();
		} else {
			//Debug.Log ("Move");
			Move ();
		}

	}

	void Attack(){
		isAttacking = true;
		isAttacking = false;
	}

	void Move(){
		//rbody.MovePosition (rbody.position + direction * Time.fixedDeltaTime*speed);
		rbody.velocity = new Vector2(direction.x *speed,direction.y *speed);
	}

	void StopMoving(){
		rbody.velocity = Vector2.zero;
	}


	[ContextMenu("Set to default Cac IA")]
	void SetToDefaultCac(){
		range = 0.3f;
	}

	[ContextMenu("Set to default Dist IA")]
	void SetToDefaultDist(){
		range = 2f;
	}
}
