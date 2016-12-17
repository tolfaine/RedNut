using UnityEngine;

[AddComponentMenu("NGUI/Examples/Load Level On Click")]
public class LoadLevelOnClick : MonoBehaviour
{
	public string levelName;
	public int nbPlayer;

	void OnClick ()
	{
		/*
		if (nbPlayer > 0) {
			GameObject g = GameObject.FindGameObjectWithTag ("NbPlayerManager");
			Debug.Log (nbPlayer);
			if (g != null) {
				g.GetComponent<NbPlayerManager> ().nbPlayer = nbPlayer;
				Debug.Log (g.GetComponent<NbPlayerManager> ().nbPlayer + " manager");
			}
		}*/

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
