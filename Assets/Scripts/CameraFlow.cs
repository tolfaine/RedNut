using UnityEngine;
using System.Collections;

public class CameraFlow : MonoBehaviour {

	public Transform target;
	public float speed = 0.3f;
	Camera cam;

	void Start () {
		cam = GetComponent<Camera> ();


	}

	void Update () {
		cam.orthographicSize = (Screen.height / 100f) / 3f;
		transform.position = Vector3.MoveTowards(transform.position,target.position+ new Vector3 (0f, 0f, -10),1f);
	}
}
