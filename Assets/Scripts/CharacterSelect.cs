using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class CharacterSelect : MonoBehaviour {
	int playerNum = 0;
	Transform parent;
	public GameObject selector;
	public int p2Count = 0;
	int p3Count = 0;
	int p4Count = 0;

	//list to hold char choices, list made so characters can change their mind before game starts
	List<string> charChoices = new List<string>();
	 

	// Use this for initialization
	void Start () {
		parent = GameObject.FindGameObjectWithTag ("CharCanvas").transform;
	
	}
	
	// Update is called once per frame
	void Update () 
	{
		//Create cursor for players if they press assigned Join button (default start on 360 controller)
		//Player one is created automatically since they are assumed to be there by default
		if (Input.GetButtonDown ("Join_P2") && p2Count == 0) {
			p2Count = 1;
			Debug.Log ("Joined button pressed");
			GameObject P2_cursor = Instantiate (selector, new Vector2 (484, 308), Quaternion.identity) as GameObject;
			P2_cursor.transform.SetParent (parent, false);
			//add cursor control script with assignments
			P2_cursor.GetComponent<CursorControl> ().horizontal = "Horizontal_P2";
			P2_cursor.GetComponent<CursorControl> ().vertical = "Vertical_P2";
			P2_cursor.GetComponent<CursorControl> ().submit = "Submit_P2";
			P2_cursor.GetComponent<CursorControl> ().back = "Back_P2";
		}
		if (Input.GetButtonDown("Back_P2"))
			{
				p2Count = 0;
			}

		if (Input.GetButtonDown ("Join_P3") && p3Count == 0)
		{
			p3Count = 1;
			GameObject P3_cursor = Instantiate (selector, new Vector2 (484, 308), Quaternion.identity) as GameObject;
			P3_cursor.GetComponent<CursorControl> ().horizontal = "Horizontal_P3";
			P3_cursor.GetComponent<CursorControl>().vertical = "Vertical_P3";
			P3_cursor.GetComponent<CursorControl>().submit = "Submit_P3";
			P3_cursor.GetComponent<CursorControl>().back = "Back_P3";

		}
		if (Input.GetButtonDown("Back_P3"))
		{
			p3Count = 0;
		}
		if (Input.GetButtonDown ("Join_P4") && p4Count == 0)
		{
			p4Count = 1;
			GameObject P4_cursor = Instantiate (selector, new Vector2 (484, 308), Quaternion.identity) as GameObject;
			P4_cursor.GetComponent<CursorControl> ().horizontal = "Horizontal_P4";
			P4_cursor.GetComponent<CursorControl>().vertical = "Vertical_P4";
			P4_cursor.GetComponent<CursorControl>().submit = "Submit_P4";
			P4_cursor.GetComponent<CursorControl>().back = "Back_P4";
		}
		if (Input.GetButtonDown("Back_P4"))
		{
			p4Count = 0;
		}

	// need to code choosing character, add the character to the list, remove character from list, find out how many players there are
	}
	void PlayerInfoStorage ()
	{
		//save info to transfer to arena scene
		string[] playerNameAry = charChoices.ToArray ();
		PlayerPrefs.SetInt ("PlayerAmount", playerNum);
		PlayerPrefsX.SetStringArray ("Names", playerNameAry);
	}
}
