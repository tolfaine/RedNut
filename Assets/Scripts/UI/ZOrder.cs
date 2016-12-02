using UnityEngine;
using System.Collections;

public class ZOrder : MonoBehaviour {

	private SpriteRenderer sprite;
	public int order;
	Transform groundPoint;

	// Use this for initialization
	void Start () {
		groundPoint = transform.FindChild ("GroundPoint");
		if (groundPoint == null) {
			Debug.LogError ("[ZOrder] No groundPoint");
		}
		sprite = GetComponent<SpriteRenderer>();
	}
	
	// Update is called once per frame
	void Update () {
		order = (int)(-groundPoint.position.y*100);
		sprite.sortingOrder = order;
	}
}
