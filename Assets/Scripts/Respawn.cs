using UnityEngine;
using System.Collections;

public class Respawn : MonoBehaviour {
	public GameObject[] players;
	Transform rp;

	// Update is called once per frame
	void Start()
	{
		PlayerCheck ();
		rp = GameObject.FindGameObjectWithTag ("RespawnPoint").GetComponent<Transform> ();
	}
	void Update()
	{
		
	}


	void PlayerCheck()
	{
		//error because as object is instantiated it is found afterward, making it second slot instead of first

		players = GameObject.FindGameObjectsWithTag ("Player");
		for (int i = 0; i < players.Length; i++)
		{
			foreach (GameObject player in players) 
			{
				if (player.GetComponent<Player>().playerID == i)
				{
					if (players[i] != player)
					{
						players[i] = player;
					}
				}
			}
		}
	}
	void OnTriggerEnter2D (Collider2D col)
	{
		if (col.gameObject.tag == "Player") 
		{
			switch (col.GetComponent<Player> ().playerID) 
			{
			case 0:
				{
					if (players [0].GetComponent<Player> ().lives != 0) {
						col.GetComponent<Player> ().lives -= 1;
						col.transform.position = (rp.position);
						break;
					} else
						col.gameObject.SetActive(false);
						break;
				}
			case 1:
				{
					if (players [1].GetComponent<Player> ().lives != 0) {
						col.GetComponent<Player> ().lives -= 1;
						col.transform.position = (rp.position);
						break;
					} else
						col.gameObject.SetActive (false);
					break;
				}
			case 2:
				{
					if (players [2].GetComponent<Player> ().lives != 0) {
						col.GetComponent<Player> ().lives -= 1;
						col.transform.position = (rp.position);
						break;
					} else
						col.gameObject.SetActive (false);
					break;
				}
			case 3:
				{
					if (players [3].GetComponent<Player> ().lives != 0) {
						col.GetComponent<Player> ().lives -= 1;
						col.transform.position = (rp.position);
						break;
					} else
						col.gameObject.SetActive (false);
					break;
				}

			}
		}

	}
}
