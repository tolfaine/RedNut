using UnityEngine;
using UnityEngine.EventSystems;

[AddComponentMenu("NGUI/Examples/Load Level On Click")]
public class LoadLevelOnClick : MonoBehaviour
{
	public string levelName;
	public bool start=false;
	public bool back=false;

	void Update(){
		ProcessInput ();

		if (start) {
			if (!string.IsNullOrEmpty(levelName))
			{
				#if UNITY_4_6 || UNITY_4_7 || UNITY_5_0 || UNITY_5_1 || UNITY_5_2
				Application.LoadLevel("RedNut");
				#else
				UnityEngine.SceneManagement.SceneManager.LoadScene("RedNut");
				#endif
			}

		}else if (back) {
	
			PointerEventData pointer = new PointerEventData (EventSystem.current);
			ExecuteEvents.Execute (gameObject, pointer, ExecuteEvents.submitHandler);
		}
	}

	public void ProcessInput(){
		if(Input.GetButtonDown("Start_P1") || Input.GetButtonDown("Start_P1")){
			start = true;
		}
	}

	void OnClick ()
	{

		if (!string.IsNullOrEmpty(levelName))
		{
#if UNITY_4_6 || UNITY_4_7 || UNITY_5_0 || UNITY_5_1 || UNITY_5_2
			Application.LoadLevel(levelName);
#else
			UnityEngine.SceneManagement.SceneManager.LoadScene(levelName);
#endif
		}
	}
}
