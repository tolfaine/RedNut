using UnityEngine;
using System.Collections;

public class CameraFlow : MonoBehaviour {

	public Transform target;
	public float speed = 0.3f;
	Camera cam;
	Camera camUI;

	void Start () {
		cam = GetComponent<Camera> ();
		target = GameObject.FindGameObjectWithTag ("PlayerCenterPoint").transform;
		camUI = GameObject.FindGameObjectWithTag ("CameraUI").GetComponent<Camera>();
	}

	void FixedUpdate(){
		if (target != null) {
			cam.orthographicSize = (Screen.height / 5f) / 3f;
			//camUI.orthographicSize = (Screen.height / 5f) / 3f;
			transform.position = Vector3.MoveTowards (transform.position, target.position + new Vector3 (0f, 0f, -10), speed);
		}
	}
	void Update () {


	}

	[ContextMenu("Set Cam")]
	void setCam(){
		cam = GetComponent<Camera> ();
		cam.orthographicSize = (Screen.height / 5f) / 3f;
		transform.position = Vector3.MoveTowards (transform.position, transform.position + new Vector3 (0f, 0f, -10), speed);
	}
}
