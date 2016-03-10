using UnityEngine;
using System.Collections;

public class FightBegin : MonoBehaviour {

	public string[] charNames;
	public GameObject[] spawnPoints;
	GameObject respawnPoint;
	public GameObject[] players;
	public int playerCount;
	// Use this for initialization
	void Start () {
		//get global variables for number of players and character choices
		playerCount = PlayerPrefs.GetInt("PlayerAmount");
		charNames = PlayerPrefsX.GetStringArray ("Names");

		//Find spawn and respawn points
		spawnPoints = GameObject.FindGameObjectsWithTag("Respawn");
		respawnPoint = GameObject.FindGameObjectWithTag ("RespawnPoint");

		//create array for player objects
		players = new GameObject[playerCount];

		for (int i = 0; i < playerCount; i++)
		{
			players[i] = Instantiate (Resources.Load (charNames[i]), spawnPoints[i].transform.position, Quaternion.identity) as GameObject;
			//set controls
			players[i].GetComponent<Player>().horizontal = "Horizontal_P" + (i+1);
			players[i].GetComponent<Player>().vertical = "Vertical_P" + (i+1);
			players[i].GetComponent<Player>().fire1 = "Fire1_P" + (i+1);
			players[i].GetComponent<Player>().fire2 = "Fire2_P" + (i+1);
			players[i].GetComponent<Player>().fire3 = "Fire3_P" + (i+1);
			players[i].GetComponent<Player>().jump = "Jump_P" + (i+1);

			//set player id or player number
			players[i].GetComponent<Player>().playerID = i;
		}
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
