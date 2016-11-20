using UnityEngine;
using System.Collections;

public class CameraFlow : MonoBehaviour {

	public Transform target;
	public float speed = 0.3f;
	Camera cam;

	void Start () {
		cam = GetComponent<Camera> ();
		target = GameObject.FindGameObjectWithTag ("PlayerCenterPoint").transform;
	}

	void FixedUpdate(){
		if (target != null) {
			cam.orthographicSize = (Screen.height / 5f) / 3f;
			transform.position = Vector3.MoveTowards (transform.position, target.position + new Vector3 (0f, 0f, -10), speed);
		}
	}
	void Update () {


	}
}
