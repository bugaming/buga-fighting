using UnityEngine;
using System.Collections;

public class Respawn : MonoBehaviour {
	public GameObject[] players;
	Transform rp;

	// Update is called once per frame
	void Start()
	{
		PlayerCheck ();
		rp = GameObject.FindGameObjectWithTag ("RespawnPoint").GetComponent<Transform> ().transform;
	}
	void PlayerCheck()
	{
		players = GameObject.FindGameObjectsWithTag ("Player");

		for (int i = 0; i < players.Length; i++)
		{
			foreach (GameObject player in players) 
			{
				if (player.GetComponent<Player>().playerID == i)
				{
					players [i] = player;
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
					Instantiate (players[0], rp.position, Quaternion.identity);
					Destroy (col.gameObject);
					PlayerCheck ();
					break;
				}
			case 1:
				{
					Instantiate (players[1], rp.position, Quaternion.identity);
					Destroy (col.gameObject);
					PlayerCheck ();
					break;
				}
			}
		}

	}
}
