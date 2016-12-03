using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;

public class Quit : MonoBehaviour {


	void Update(){
		ProcessInput ();
	}

	public void ProcessInput(){
		if(Input.GetKeyDown(KeyCode.B)){
			Debug.Log ("Click");
			PointerEventData pointer = new PointerEventData (EventSystem.current);
			ExecuteEvents.Execute (gameObject, pointer, ExecuteEvents.submitHandler);
		}
	}


	public void QuitGame()
    {
        Application.Quit();
    }
}
