using UnityEngine;
using System.Collections;

public class LevelSelect : MonoBehaviour {
	public int lvlNumber;
	string[] levelName;

	void Start()
	{
		levelName = new string[2];
		levelName[1] = "Arena";
	}

	public void GoToGame()
	{
		UnityEngine.SceneManagement.SceneManager.LoadScene (levelName[lvlNumber]);
	}

}
