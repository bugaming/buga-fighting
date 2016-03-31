using UnityEngine;
using System.Collections;

public class CameraFollow : MonoBehaviour {
	public ArrayList players = new ArrayList();
	public ArrayList vectors = new ArrayList();
	private float distanceFromMid;
	private float distancePlayers;
	private float cameraDistance;

	private float aspectRatio;
	Vector3 sum;

	Vector3 middle;

	// Use this for initialization
	void Start () 
	{
		aspectRatio = Screen.width / Screen.height;
		players.AddRange (GameObject.FindGameObjectsWithTag("Player"));
	}
	
	// Update is called once per frame
	void Update () 
	{
		

		//create list and dynamically add to and remove players who aren't alive and aren't in the list or array if array would work


		foreach (GameObject player in players) {
			if (player.GetComponent<Player> ().isAlive == false) 
			{
				if (players.Contains(player) == true)
				{
					players.Remove (player);
				}
			}
		}
		foreach (GameObject player in players) {
			for (int i = 0; i < players.Count; i ++)
			{
				vectors [i] = player.GetComponent<Transform>().position;
			}

		}
			

		foreach (Vector3 vec in vectors) {
			sum += vec;
		}
			
		Camera.main.transform.position = new Vector3 (sum.x, sum.y, - 10);
	
	}

}
