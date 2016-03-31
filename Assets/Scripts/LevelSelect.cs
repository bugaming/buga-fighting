using UnityEngine;
using System.Collections;

public class LevelSelect : MonoBehaviour {
	public int lvlNumber;
	string[] levelName;

	void Start()
	{
		levelName = new string[3];
		levelName[1] = "Arena";
		levelName[2] = "jungle";
	}

	public void GoToGame()
	{
		UnityEngine.SceneManagement.SceneManager.LoadScene (levelName[lvlNumber]);
	}

}
