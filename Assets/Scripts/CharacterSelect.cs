using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class CharacterSelect : MonoBehaviour {
	int playerNum = 1;
	int p2Count = 0;
	int p3Count = 0;
	int p4Count = 0;
	int j = 1;
	int k = 2;
	int l = 3;
	int useCon;
	Transform parent;
	public int[] playerSlot = new int[3];
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
		useCon = PlayerPrefs.GetInt ("UseKB");
		P1_cursor.GetComponent<Image>().color = new Color(0,0,225);
		levelSelect = GameObject.FindGameObjectWithTag("LevelCanvas");
		charSelect = GameObject.FindGameObjectWithTag ("CharCanvas");
		levelSelect.SetActive (false);
		//get transform of parent object so cursors are instatiated as child of canvas
		parent = GameObject.FindGameObjectWithTag ("CharCanvas").transform;
		//set playerSlot 0 to 1 for player one who is in play by default
		playerSlot [0] = 1;

		//set cursor controls to P1 to use controller, and P0 to use mouse and KB
		if (useCon == 1) {
			P1_cursor.GetComponent<CursorControl> ().horizontal = "Horizontal_P1";
			P1_cursor.GetComponent<CursorControl> ().vertical = "Vertical_P1";
			P1_cursor.GetComponent<CursorControl> ().submit = "Submit_P1";
			P1_cursor.GetComponent<CursorControl> ().back = "Back_P1";
		} else if (useCon == 0) {
			P1_cursor.GetComponent<CursorControl> ().horizontal = "Horizontal_P0";
			P1_cursor.GetComponent<CursorControl> ().vertical = "Vertical_P0";
			P1_cursor.GetComponent<CursorControl> ().submit = "Submit_P0";
			P1_cursor.GetComponent<CursorControl> ().back = "Back_P0";
		}
	}

	// Update is called once per frame
	void Update () 
	{
		//Create cursor for players if they press assigned Join button (default start on 360 controller)
		//Player one is created automatically since they are assumed to be there by default
		if (Input.GetButtonDown ("Join_P" + (j + useCon )) && p2Count == 0) {
			p2Count = 1;
			playerNum += 1;
			playerSlot [1] = 2;
			P2_cursor = Instantiate (selector, new Vector2 (484, 308), Quaternion.identity) as GameObject;
			P2_cursor.transform.SetParent (parent, false);
			P2_cursor.GetComponent<Image>().color = new Color(225, 0, 0);
			//add cursor control script with assignments
			P2_cursor.GetComponent<CursorControl> ().horizontal = "Horizontal_P"+ (j + useCon );
			P2_cursor.GetComponent<CursorControl> ().vertical = "Vertical_P" + (j + useCon );
			P2_cursor.GetComponent<CursorControl> ().submit = "Submit_P" + (j + useCon );
			P2_cursor.GetComponent<CursorControl> ().back = "Back_P" + (j + useCon );
		}
		if (Input.GetButtonDown("Back_P" + (j + useCon)))
		{
			playerNum -= 1;
			p2Count = 0;
			playerSlot [1] = 0;
		}

		if (Input.GetButtonDown ("Join_P"+ (2 + useCon )) && p3Count == 0)
		{
			p3Count = 1;
			playerNum += 1;
			playerSlot [2] = 3;
			P3_cursor = Instantiate (selector, new Vector2 (484, 308), Quaternion.identity) as GameObject;
			P3_cursor.transform.SetParent (parent, false);
			P3_cursor.GetComponent<Image>().color = new Color(0, 225, 0);
			P3_cursor.GetComponent<CursorControl> ().horizontal = "Horizontal_P" + (k + useCon );
			P3_cursor.GetComponent<CursorControl>().vertical = "Vertical_P" + (k + useCon );
			P3_cursor.GetComponent<CursorControl>().submit = "Submit_P" + (k + useCon );
			P3_cursor.GetComponent<CursorControl>().back = "Back_P" + (k + useCon );

		}
		if (Input.GetButtonDown("Back_P"+ (2 + useCon )))
		{
			p3Count = 0;
			playerNum -= 1;
			playerSlot [2] = 0;
		}
		if (Input.GetButtonDown ("Join_P"+ (3 + useCon )) && p4Count == 0)
		{
			p4Count = 1;
			playerNum += 1;
			playerSlot [3] = 4;
			P4_cursor = Instantiate (selector, new Vector2 (484, 308), Quaternion.identity) as GameObject;
			P4_cursor.transform.SetParent (parent, false);
			P4_cursor.GetComponent<Image>().color = new Color(0, 225, 225);
			P4_cursor.GetComponent<CursorControl> ().horizontal = "Horizontal_P" + (l + useCon );
			P4_cursor.GetComponent<CursorControl>().vertical = "Vertical_P" + (l + useCon );
			P4_cursor.GetComponent<CursorControl>().submit = "Submit_P" + (l + useCon );
			P4_cursor.GetComponent<CursorControl>().back = "Back_P" + (l + useCon );
		}
		if (Input.GetButtonDown("Back_P"+ (3 + useCon )))
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
