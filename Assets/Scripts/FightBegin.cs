using UnityEngine;
using System.Collections;

public class FightBegin : MonoBehaviour {
	GameObject[] players;
	int playerCount;
	// Use this for initialization
	void Start () {
		players = GameObject.FindGameObjectsWithTag ("Player");
		foreach (GameObject player in players) {
			player.AddComponent<Player> ();
		}
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
