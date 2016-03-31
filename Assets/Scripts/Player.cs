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
	public float hp;
	public int maxJumpAmt;
	public int lives;
	public float punchTimer;
	public float move1;

	public bool isAlive;
	float groundRadius = 1f;
	LayerMask whatIsGround;
	Transform groundCheck;
	Transform rp;
	int jumpCount;
	bool facingRight;
	public bool grounded = false;
	Rigidbody2D rigid;
	GameObject player;
	Animator anim;


	// Use this for initialization
	void Start () {
		print (lives);
		hp = 100;
		whatIsGround = 512;
		this.name = "Player " + (playerID + 1);
		rigid = this.GetComponent<Rigidbody2D> ();
		anim = this.GetComponent<Animator> ();
		groundCheck = this.transform.FindChild ("groundCheck").GetComponent<Transform>();
		player = this.gameObject;
		rp = GameObject.FindGameObjectWithTag ("RespawnPoint").GetComponent<Transform> ().transform;
	}
	void FixedUpdate()
	{
		grounded = Physics2D.OverlapCircle (groundCheck.position, groundRadius, 512);
		anim.SetBool ("Ground", grounded);
	}
	// Update is called once per frame
	void Update () {
		

		if (lives < 0) {
			isAlive = false;
		} else
			isAlive = true;

		//player death if hp is 0 or less
		if (hp <= 0) {
			if (lives > 0) {
				lives -= 1;
				player.transform.position = rp.position;
			} else
				Destroy(player);

		}

		//if player is grounded and jump button pressed
		if (Input.GetButtonDown (jump) && grounded == true) {
			//aply jump power, set animation state
			Jump (jumpPower);
			jumpCount = 2;
			anim.SetBool ("Ground", false);
		}
		if (Input.GetButtonDown (jump) && jumpCount < maxJumpAmt && grounded == false) 
		{
			Jump (jumpPower);
			jumpCount += 1;
		}
		if (grounded == true) {
			jumpCount = 1;
		}
		if (grounded == true) {
			anim.SetBool ("Ground", true);
		}


		//move player left and right
		float move = Input.GetAxisRaw (horizontal);

		//flip object if changing direction
		if (Input.GetAxisRaw (horizontal) == -1)
		{
			facingRight = true;
			this.GetComponent<SpriteRenderer>().flipX = (facingRight);
		} 
		else if (Input.GetAxisRaw (horizontal) == 1)
		{
			facingRight = false;
			this.GetComponent<SpriteRenderer>().flipX = (facingRight);
		}

		//set animation states for moving or holding still;
		if (Input.GetAxisRaw(horizontal) != 0) {
			anim.SetFloat ("Speed", 1);
		}
		else 
		{
			anim.SetFloat ("Speed", 0);
		}

		//set animation states for crouching and holding up direction
		if (Input.GetAxisRaw (vertical) == 1) {
			anim.SetBool ("UpIsHeld", true);
		} 
		else if (Input.GetAxisRaw (vertical) == -1) {
			anim.SetBool ("Crouching", true);
		}
		else
		{
			anim.SetBool ("UpIsHeld", false);
			anim.SetBool("Crouching", false);
		}
		rigid.velocity = new Vector2 (move * moveSpeed, rigid.velocity.y);

		//set punching animation
		if (Input.GetButtonDown(fire1)) {
			punchTimer = 3;
		}
		if (punchTimer > 0) 
		{
			punchTimer -= 0.1f;
			anim.SetFloat ("Punching", 1);
			if (Input.GetButtonDown (fire1)) {
				anim.SetFloat ("Punching", 2);
				punchTimer = 3;
			}
		} 
		else anim.SetFloat ("Punching", 0);



	}
	//functino to jump durrr
	void Jump (float jForce)
	{
		rigid.AddForce(new Vector2 (moveSpeed, jForce));
	}

}
