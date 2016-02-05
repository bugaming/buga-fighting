using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class CharacterSelect : MonoBehaviour {
	int playerNum = 0;

	//list to hold char choices, list made so characters can change their mind before game starts
	List<string> charChoices = new List<string>();
	 

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () 
	{
		//Create cursor for players if they press assigned Join button (default start on 360 controller)
		//Player one is created automatically since they are assumed to be there by default
		if (Input.GetButtonDown ("Join_P2"))
		{
			GameObject P2_cursor = Instantiate (Resources.Load ("Selector", typeof(GameObject)), new Vector2 (484, 308), Quaternion.identity) as GameObject;
			//add cursor control script with assignments
			P2_cursor.AddComponent<CursorControl>();
			P2_cursor.GetComponent<CursorControl> ().horizontal = "Horizontal_P2";
			P2_cursor.GetComponent<CursorControl>().vertical = "Vertical_P2";
			P2_cursor.GetComponent<CursorControl>().submit = "Submit_P2";
			P2_cursor.GetComponent<CursorControl>().back = "Back_P2";
			if (Input.GetButtonDown ("Join_P2"))
			{
				Destroy (P2_cursor);
			}
		}
		if (Input.GetButtonDown ("Join_P3"))
		{
			GameObject P3_cursor = Instantiate (Resources.Load ("Selector", typeof(GameObject)), new Vector2 (484, 308), Quaternion.identity) as GameObject;
			P3_cursor.AddComponent<CursorControl>();
			P3_cursor.GetComponent<CursorControl> ().horizontal = "Horizontal_P3";
			P3_cursor.GetComponent<CursorControl>().vertical = "Vertical_P3";
			P3_cursor.GetComponent<CursorControl>().submit = "Submit_P3";
			P3_cursor.GetComponent<CursorControl>().back = "Back_P3";
			if (Input.GetButtonDown ("Join_P3"))
			{
				Destroy (P3_cursor);
			}
		}
		if (Input.GetButtonDown ("Join_P4"))
		{
			GameObject P4_cursor = Instantiate (Resources.Load ("Selector", typeof(GameObject)), new Vector2 (484, 308), Quaternion.identity) as GameObject;
			P4_cursor.AddComponent<CursorControl>();
			P4_cursor.GetComponent<CursorControl> ().horizontal = "Horizontal_P4";
			P4_cursor.GetComponent<CursorControl>().vertical = "Vertical_P4";
			P4_cursor.GetComponent<CursorControl>().submit = "Submit_P4";
			P4_cursor.GetComponent<CursorControl>().back = "Back_P4";
			if (Input.GetButtonDown ("Join_P4"))
			{
				Destroy (P4_cursor);
			}
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
