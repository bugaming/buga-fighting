using UnityEngine;
using System.Collections;

public class CursorControl : MonoBehaviour {
	public string horizontal;
	public string vertical;
	public string submit;
	public string back;
	public string choice;
	public GameObject controller;
	public GameObject choicePortrait;
	Transform parent;
	float vertSpeed = 400f;
	float horiSpeed = 400f;
	bool choiceMade;
	public GameObject[] positions = new GameObject[4];
	public int playerNum;
	int mod;
	// Use this for initialization
	void Start () {
		/*
		mod = PlayerPrefs.GetInt ("UseKB");
		if (mod == 1)
		playerNum = (int.Parse (horizontal.Substring((horizontal.Length - 1), 1)));
		else if (mod != 1)
		*/
		playerNum = (int.Parse (horizontal.Substring((horizontal.Length - 1), 1)));
		parent = GameObject.FindGameObjectWithTag ("CharCanvas").transform;
		controller = GameObject.FindGameObjectWithTag ("GameController");
		positions [0] = GameObject.Find ("p1Pos");
		positions [1] = GameObject.Find ("p2Pos");
		positions [2] = GameObject.Find ("p3Pos");
		positions [3] = GameObject.Find ("p4Pos");

	}
	
	// Update is called once per frame
	void Update () {
		
		//horizontal movement
		float hMove = (Input.GetAxisRaw (horizontal)); 
		this.transform.Translate (Vector2.right * hMove * Time.deltaTime * horiSpeed);
		//vertical movement
		float vMove = (Input.GetAxisRaw (vertical)); 
		//Debug.Log (vMove);
		this.transform.Translate (Vector2.up * vMove * Time.deltaTime * vertSpeed);

		if (Input.GetButtonDown (submit)) 
		{
			
			RaycastHit2D hit = Physics2D.Raycast (this.transform.position, Vector2.zero);
			if (hit.collider.gameObject.tag =="SelectPortrait") 
			{
				choice = hit.transform.gameObject.GetComponent<PortInfo>().pName;
				Destroy (choicePortrait);
				//create portrait to fill player slot;
				choicePortrait = Instantiate (hit.transform.gameObject, new Vector2 (100, 200), Quaternion.identity) as GameObject;			
				print (controller.transform.position);
			
				choicePortrait.transform.SetParent (parent, false);
				print (choicePortrait.transform.position);

				//SendMessageUpwards (choice);
				Debug.Log ("hit portrait");
				choiceMade = true;
			}

		}
		if (Input.GetButtonDown(back) && choiceMade == false && this.name != "Selector") 
		{
			choice = null;
			Debug.Log ("Back button pressed");
			Destroy (transform.gameObject);
		}
		else if (Input.GetButtonDown(back) && choiceMade == true) 
		{
			choice = null;
			Destroy (choicePortrait);
			choiceMade = false;
		}
		if (choiceMade == true) {
			choicePortrait.transform.position = (Vector2.Lerp (choicePortrait.transform.position, positions [playerNum].GetComponent<Transform> ().position, .1f));
		}
	}

}
