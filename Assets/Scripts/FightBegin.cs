using UnityEngine;
using System.Collections;

public class FightBegin : MonoBehaviour {

	public int startingLives;
	public string[] charNames;
	public GameObject[] spawnPoints;
	public GameObject[] UIpoints;
	public GameObject[] playerUI;
	GameObject respawnPoint;
	GameObject battlecanv;
	public GameObject[] players;
	public int playerCount;

	int control;
	// Use this for initialization
	void Start () {

		//get global variables for number of players and cha
		control = PlayerPrefs.GetInt ("UseKB");
		playerCount = PlayerPrefs.GetInt("PlayerAmount");
		charNames = PlayerPrefsX.GetStringArray ("Names");
		battlecanv = Instantiate (Resources.Load ("UI/BattleCanvas"), Vector2.zero, Quaternion.identity) as GameObject;

		//Find spawn and respawn points
		spawnPoints = GameObject.FindGameObjectsWithTag("Respawn");
		respawnPoint = GameObject.FindGameObjectWithTag ("RespawnPoint");


		UIpoints = new GameObject[5];

		UIpoints [0] = GameObject.Find ("P1UI");
		UIpoints [1] = GameObject.Find ("P2UI");
		UIpoints [2] = GameObject.Find ("P3UI");
		UIpoints [3] = GameObject.Find ("P4UI");
		UIpoints [4] = GameObject.Find ("SPUI");

		if (playerCount < 2) {
			UIpoints [0] = UIpoints [4];
		} else if (playerCount == 2) {
			UIpoints [0] = UIpoints [2];
			UIpoints [1] = UIpoints [3];
		} else if (playerCount == 3) {
			UIpoints [1] = UIpoints [4];
			UIpoints [2] = UIpoints [3];
		}


		//create array for player objects
		players = new GameObject[playerCount];
		//create array for player UI elements
		playerUI = new GameObject[playerCount];

		for (int i = 0; i < playerCount; i++)
		{
			players[i] = Instantiate (Resources.Load ("Characters/" + charNames[i]), spawnPoints[i].transform.position, Quaternion.identity) as GameObject;
			//set controls
			playerUI[i] = Instantiate (Resources.Load("UI/HpSlider"), UIpoints[i].GetComponent<RectTransform> ().localPosition, Quaternion.identity) as GameObject;
			playerUI [i].transform.SetParent (battlecanv.transform, false);
			players[i].GetComponent<Player>().horizontal = "Horizontal_P" + (i+control);
			players[i].GetComponent<Player>().vertical = "Vertical_P" + (i+control);
			players[i].GetComponent<Player>().fire1 = "Fire1_P" + (i+control);
			players[i].GetComponent<Player>().fire2 = "Fire2_P" + (i+control);
			players[i].GetComponent<Player>().fire3 = "Fire3_P" + (i+control);
			players[i].GetComponent<Player>().jump = "Jump_P" + (i+control);
			players[i].GetComponent<Player>().charName = charNames[i];
			players[i].GetComponent<Player>().lives = startingLives;

			//set player id or player number
			players[i].GetComponent<Player>().playerID = i;
		}
	}

	// Update is called once per frame
	void Update () {

	}
}
