using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {

	public float moveSpeed = 8f;
	public float jumpPower = 250f;
	Rigidbody2D rigid;
	GameObject player;



	// Use this for initialization
	void Start () {



	}
	
	// Update is called once per frame
	void Update () {

		player = this.gameObject;

		player = GameObject.FindGameObjectWithTag ("Player");

		rigid = player.GetComponent<Rigidbody2D>();
		if (Input.GetKeyDown (KeyCode.Space)) {
			Jump (jumpPower);
		}
		float move = Input.GetAxis ("Horizontal");

		rigid.velocity = new Vector2 (move * moveSpeed, rigid.velocity.y);

		rigid.velocity = new Vector3 (move * moveSpeed, rigid.velocity.y);

		 
	
	}

	void Jump (float jForce)
	{
		rigid.AddForce(new Vector2 (moveSpeed, jForce));
	}

}
