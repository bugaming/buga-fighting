using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class CharacterSelect : MonoBehaviour {
	int playerNum = 1;
	int p2Count = 0;
	int p3Count = 0;
	int p4Count = 0;
	Transform parent;
	int[] playerSlot = new int[3];
	public GameObject selector;
	public GameObject P1_cursor;
	public GameObject charSelect;
	public GameObject levelSelect;
	GameObject P2_cursor;
	GameObject P3_cursor;
	GameObject P4_cursor;

	//array size is set in game editor, string array size cannot be set
	public string[] charChoices;


	// Use this for initialization
	void Start () 
	{
		levelSelect = GameObject.FindGameObjectWithTag("LevelCanvas");
		charSelect = GameObject.FindGameObjectWithTag ("CharCanvas");
		levelSelect.SetActive (false);
		//get transform of parent object so cursors are instatiated as child of canvas
		parent = GameObject.FindGameObjectWithTag ("CharCanvas").transform;
		//set playerSlot 0 to 1 for player one who is in play by default
		playerSlot [0] = 1;
	}
	
	// Update is called once per frame
	void Update () 
	{
		//Create cursor for players if they press assigned Join button (default start on 360 controller)
		//Player one is created automatically since they are assumed to be there by default
		if (Input.GetButtonDown ("Join_P2") && p2Count == 0) {
			p2Count = 1;
			playerNum += 1;
			playerSlot [1] = 2;
			P2_cursor = Instantiate (selector, new Vector2 (484, 308), Quaternion.identity) as GameObject;
			P2_cursor.transform.SetParent (parent, false);
			//add cursor control script with assignments
			P2_cursor.GetComponent<CursorControl> ().horizontal = "Horizontal_P2";
			P2_cursor.GetComponent<CursorControl> ().vertical = "Vertical_P2";
			P2_cursor.GetComponent<CursorControl> ().submit = "Submit_P2";
			P2_cursor.GetComponent<CursorControl> ().back = "Back_P2";
		}
		if (Input.GetButtonDown("Back_P2"))
			{
				playerNum -= 1;
				p2Count = 0;
				playerSlot [1] = 0;
			}

		if (Input.GetButtonDown ("Join_P3") && p3Count == 0)
		{
			p3Count = 1;
			playerNum += 1;
			playerSlot [2] = 3;
			P3_cursor = Instantiate (selector, new Vector2 (484, 308), Quaternion.identity) as GameObject;
			P3_cursor.transform.SetParent (parent, false);
			P3_cursor.GetComponent<CursorControl> ().horizontal = "Horizontal_P3";
			P3_cursor.GetComponent<CursorControl>().vertical = "Vertical_P3";
			P3_cursor.GetComponent<CursorControl>().submit = "Submit_P3";
			P3_cursor.GetComponent<CursorControl>().back = "Back_P3";

		}
		if (Input.GetButtonDown("Back_P3"))
		{
			p3Count = 0;
			playerNum -= 1;
			playerSlot [2] = 0;
		}
		if (Input.GetButtonDown ("Join_P4") && p4Count == 0)
		{
			p4Count = 1;
			playerNum += 1;
			playerSlot [3] = 4;
			P4_cursor = Instantiate (selector, new Vector2 (484, 308), Quaternion.identity) as GameObject;
			P4_cursor.transform.SetParent (parent, false);
			P4_cursor.GetComponent<CursorControl> ().horizontal = "Horizontal_P4";
			P4_cursor.GetComponent<CursorControl>().vertical = "Vertical_P4";
			P4_cursor.GetComponent<CursorControl>().submit = "Submit_P4";
			P4_cursor.GetComponent<CursorControl>().back = "Back_P4";
		}
		if (Input.GetButtonDown("Back_P4"))
		{
			p4Count = 0;
			playerNum -= 1;
			playerSlot [3] = 0;
		}
	}

	public void PlayerInfoStorage ()
	{
		//set name of char choice  from cursor control script to correct player slot, else set name to nothing

		for (int i = 0; i < 3; i++) 
		{
			if (playerSlot [i] > 0) {
				switch (i) {
				case 0:
					{
						charChoices [0] = P1_cursor.GetComponent<CursorControl> ().choice;
						break;
					}
				case 1:
					{
						charChoices [1] = P2_cursor.GetComponent<CursorControl> ().choice;
						break;
					}
				case 2:
					{
						charChoices [2] = P3_cursor.GetComponent<CursorControl> ().choice;
						break;
					}
				case 3:
					{
						charChoices [3] = P4_cursor.GetComponent<CursorControl> ().choice;
						break;
					}
				}
			} else if (playerSlot [i] == 0)
			{
				switch (i) {
				case 0:
					{
						charChoices [0] = "";
						break;
					}
				case 1:
					{
						charChoices [1] = "";
						break;
					}
				case 2:
					{
						charChoices [2] = "";
						break;
					}
				case 3:
					{
						charChoices [3] = "";
						break;
					}
				}
			}
		}
		charSelect.SetActive (false);
		levelSelect.SetActive (true);
			
		//save info to transfer to arena scene
		PlayerPrefs.SetInt ("PlayerAmount", playerNum);
		PlayerPrefsX.SetStringArray ("Names", charChoices);
	}
}
