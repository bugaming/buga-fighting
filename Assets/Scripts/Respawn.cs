using UnityEngine;
using System.Collections;

public class Respawn : MonoBehaviour {
	public GameObject[] players;

	// Update is called once per frame
	void Start () {
		players = GameObject.FindGameObjectsWithTag ("Player");
	
	}
	void OnTriggerEnter2D (Collider2D col)
	{
		foreach (GameObject player in players)
		{
			if (col.gameObject.tag == "Player") 
			{
				Destroy (col.gameObject);
				Instantiate (player, new Vector3 (0, 2, 0), Quaternion.identity);
			}
		}
	}
}
