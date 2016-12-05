using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class CinematicManager : MonoBehaviour {

	public List<GameObject> listVehicules = new List<GameObject>(1);
	public CameraFlow cameraFlow;
	public Animator currentAnimator;
	public int indexCinematic; 
	public bool active = false;

	public AudioClip dong;
	public AudioClip truck;
	public float voulumeDong = 1f;
	public float voulumeTruck= 1f;

	// Use this for initialization
	void Start () {
		cameraFlow = GameObject.FindGameObjectWithTag ("MainCamera").GetComponent<CameraFlow>();
	}
	
	// Update is called once per frame
	void Update () {
	
		if (active) {

			if (currentAnimator.GetCurrentAnimatorStateInfo (0).IsName ("transition") &&
			    currentAnimator.GetCurrentAnimatorStateInfo (0).normalizedTime >= 1.0f) {


				GameObject enemyPrefab = GameObject.FindWithTag ("GameManager").GetComponent<GameInfo> ().getBossAtIndex (indexCinematic);
				Transform currentTransform = listVehicules [indexCinematic].transform;
				GameObject go = Instantiate (enemyPrefab, currentTransform.position, transform.rotation) as GameObject;
				go.GetComponent<BossAttackLogic> ().bossIndex = indexCinematic;
				go.GetComponent<BossEnemyHealth> ().bossIndex = indexCinematic;

				if (indexCinematic == 0) {
					go.transform.position = new Vector3 (go.transform.position.x, go.transform.position.y + 40, go.transform.position.z);
				}else if(indexCinematic ==1){
					go.transform.position = new Vector3 (go.transform.position.x - 40, go.transform.position.y , go.transform.position.z);
				}else if(indexCinematic == 2){
					go.transform.position = new Vector3 (go.transform.position.x + 40 , go.transform.position.y, go.transform.position.z);
				}else{
					go.transform.position = new Vector3 (go.transform.position.x, go.transform.position.y - 40, go.transform.position.z);
				}


				go.GetComponent<EnemyHealth> ().setRoundManagerOwner ( GameObject.FindWithTag ("RoundManager").GetComponent<RoundManager> ());

				cameraFlow.SetTarget(go.transform);


				go.GetComponent<IAAttackLogic> ().StartAppearing (2f);
				cameraFlow.Invoke ("ResetCamOnPlayer", 2f);
				Invoke ("PlayDong", 2f);

				active = false;
			} else {

			}
				
			//cameraFlow.EndBossCinematic ();
		}
	}

	public void ActivateCinematicAtIndex(int index){

		active = true;

		indexCinematic = index;


		GameObject go = listVehicules [index];

		cameraFlow.SetTarget(go.transform);

		currentAnimator = go.GetComponent<Animator> ();
		currentAnimator.SetBool ("trigger", true);

		PlayTruck ();


	
	}

	public void PlayDong(){
		AudioSource source = CustomAudioSource.PlayClipAt (dong, transform.position);
		source.volume = voulumeDong;
	}

	public void PlayTruck(){
		AudioSource source = CustomAudioSource.PlayClipAt (truck, transform.position);
		source.volume = voulumeTruck;
	}
}
