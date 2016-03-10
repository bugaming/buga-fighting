using UnityEngine;
using System.Collections;

public class CursorControl : MonoBehaviour {
	public string horizontal;
	public string vertical;
	public string submit;
	public string back;
	public string choice;
	float vertSpeed = 200f;
	float horiSpeed = 200f;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		//horizontal movement
		float hMove = (Input.GetAxisRaw (horizontal)); 
		this.transform.Translate (Vector2.right * hMove * Time.deltaTime * horiSpeed);
		//vertical movement
		float vMove = (Input.GetAxisRaw (vertical)); 
		this.transform.Translate (Vector2.up * vMove * Time.deltaTime * vertSpeed);

		if (Input.GetButtonDown (submit)) 
		{
			RaycastHit2D hit = Physics2D.Raycast (transform.position, Vector2.zero);
			if (hit.collider.tag == "SelectPortrait") 
			{
				choice = hit.transform.gameObject.GetComponent<PortInfo>().pName;
				//SendMessageUpwards (choice);
				Debug.Log ("hit portrait");
			}

		}
		if (Input.GetButtonDown(back)) 
		{
			choice = null;
			Debug.Log ("Back button pressed");
			Destroy (transform.gameObject);
		}


	
	}
}
