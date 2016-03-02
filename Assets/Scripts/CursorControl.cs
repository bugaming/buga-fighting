using UnityEngine;
using System.Collections;

public class CursorControl : MonoBehaviour {
	public string horizontal;
	public string vertical;
	public string submit;
	public string back;
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

		if (Input.GetButtonDown (submit)) {
			print ("submit pressed");
		}
		if (Input.GetButtonDown(back)) 
		{
			Debug.Log ("Back button pressed");
			Destroy (transform.gameObject);
		}


	
	}
}
