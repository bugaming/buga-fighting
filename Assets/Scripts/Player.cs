using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {

	public string horizontal;
	public string vertical;
	public string fire1;
	public string fire2;
	public string fire3;
	public string jump;

	public float moveSpeed = 4f;
	public float jumpPower = 500f;
	public int playerID;
	Rigidbody2D rigid;
	GameObject player;



	// Use this for initialization
	void Start () {
		this.name = "Player " + (playerID + 1);

	}
	
	// Update is called once per frame
	void Update () {

		player = this.gameObject;

		rigid = player.GetComponent<Rigidbody2D>();

		if (Input.GetButtonDown (jump))
		{
			Jump (jumpPower);
		}
		float move = Input.GetAxisRaw (horizontal);

		rigid.velocity = new Vector2 (move * moveSpeed, rigid.velocity.y);
	}

	void Jump (float jForce)
	{
		rigid.AddForce(new Vector2 (moveSpeed, jForce));
	}

}
