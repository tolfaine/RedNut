using UnityEngine;
using System.Collections;

public class Line : MonoBehaviour {

	LineRenderer lineRender;
	GameObject target;

	Transform firstPosition;
	float width = 5f;

	public bool isActive = false;

	Vector2 uvOffset = Vector2.zero;
	Vector2 uvAnimateRate = new Vector2(5f,0.0f);

	// Use this for initialization
	void Start () {
		lineRender = gameObject.GetComponent<LineRenderer> ();
		target = transform.FindChild("Target").gameObject;
		lineRender.sortingLayerName = "Units";

		lineRender.SetWidth (3,5);

	}

	void LateUpdate(){
		uvOffset -= (uvAnimateRate * Time.deltaTime);

		if (lineRender.enabled) {
			lineRender.material.mainTextureOffset = uvOffset;
		}
	}


	// Update is called once per frame
	void Update () {
	//	firstPosition = this.transform.position;
		if (isActive) {
			
			lineRender.SetPosition (1, target.transform.position);
			lineRender.SetPosition (0, firstPosition.position);

			float dist = Vector3.Distance (firstPosition.position, target.transform.position);
			lineRender.material.mainTextureScale = new Vector2 ((dist) / width, 1);
		}


	}

	public void setStartPosition(Transform newPosition){
		lineRender.SetPosition (0, newPosition.position);
		firstPosition = newPosition;
	}

	public void setTargetPosition(Vector3 newPosition){
		target.transform.position = newPosition;
		lineRender.SetPosition (1, target.transform.position);

		float dist = Vector3.Distance (firstPosition.position, target.transform.position);
		lineRender.material.mainTextureScale = new Vector2 (dist * 2, 1);
	}

	public void setToSamePosition(Vector3 newPosition){

		lineRender.SetPosition (1, newPosition);
		lineRender.SetPosition (0, newPosition);
	}
}
