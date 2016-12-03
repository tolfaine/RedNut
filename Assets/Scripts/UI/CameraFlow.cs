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

	}
	void Update () {

		if (target != null) {
			cam.orthographicSize = (Screen.height / 5f) / 3f;
			//camUI.orthographicSize = (Screen.height / 5f) / 3f;
			transform.position = Vector3.MoveTowards (transform.position, target.position + new Vector3 (0f, 0f, -10), speed);


		}
	}

	[ContextMenu("Set Cam")]
	void setCam(){
		cam = GetComponent<Camera> ();
		cam.orthographicSize = (Screen.height / 5f) / 3f;
		transform.position = Vector3.MoveTowards (transform.position, transform.position + new Vector3 (0f, 0f, -10), speed);
	}

	public void SetTarget(Transform newTarget){
	//	target.GetComponent<PlayerCenterPoint>().setNewTarget (newTarget);
		target = newTarget;
	}

	public void StartBossCinematic(){
		Debug.Log ("StartBossCinematic");
	}

	public void EndBossCinematic(){
		Debug.Log ("EndBossCinematic");
	}

	public void ResetCamOnPlayer(){
		target = GameObject.FindGameObjectWithTag ("PlayerCenterPoint").transform;
		GameObject.FindGameObjectWithTag ("PlayerCenterPoint").GetComponent<PlayerCenterPoint>().findPlayers();
	}
}
