﻿using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PlayerCenterPoint : MonoBehaviour {
	
	public List<Transform> listTargets;
	private int nbTarget;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
		float x =0;
		float y =0;
		float z =0;

		foreach (Transform t in listTargets) {

			x += t.position.x;
			y +=t.position.y;
			z += t.position.z;
		}

		x = x / nbTarget;
		y = y / nbTarget;
		z = z /nbTarget;

		transform.position = new Vector3 (x, y, z);

	}

	public void findPlayers(){
		listTargets = new List<Transform> ();

		GameObject[] lGo = GameObject.FindGameObjectsWithTag ("Player");

		foreach (GameObject g in lGo) {
			PlayerHealth ph = g.GetComponent<PlayerHealth> ();
			if (!ph.isItDying ()) {
				listTargets.Add (g.transform);
			}
		}

		nbTarget = listTargets.Count;
	}
		
}
