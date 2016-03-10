using UnityEngine;
using System.Collections;

public class LevelChoice : MonoBehaviour {

	public int lvlNum;
	GameObject gameController;

	void Start()
	{
		gameController = GameObject.FindGameObjectWithTag("GameController");
	}
	// Use this for initialization
	public void setLevelChoice()
	{
		gameController.GetComponent<LevelSelect> ().lvlNumber = lvlNum;
	}
}
