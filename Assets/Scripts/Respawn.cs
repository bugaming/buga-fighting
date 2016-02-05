using UnityEngine;
using System.Collections;

public class Respawn : MonoBehaviour {
	public GameObject player;
	// Update is called once per frame
	void Start () {
	
	}
	void OnTriggerEnter2D (Collider2D col)
	{
		if (col.gameObject.tag == "Player") {
			Destroy (col.gameObject);
			Instantiate (player, new Vector3 (0, 2, 0), Quaternion.identity);
		}
	}
}
