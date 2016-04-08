using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {

	public string horizontal;
	public string vertical;
	public string fire1;
	public string fire2;
	public string fire3;
	public string jump;
	public float moveSpeed = 12f;
	public float jumpPower = 900f;
	public int playerID;
	public float hp;
	public int maxJumpAmt;
	public int lives;
	public float punchTimer;
	public bool isAlive;
	public string charName;

	float groundRadius = 1f;
	public LayerMask whatIsGround;
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
		this.GetComponentInChildren<PolygonCollider2D> ().enabled = false;
		print (lives);
		hp = 100;
		whatIsGround = 512;
		this.name = "Player " + (playerID + 1);
		rigid = this.GetComponent<Rigidbody2D> ();
		rigid.mass = 3;
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
		if (Input.GetAxisRaw (horizontal) < 0 && !facingRight)
		{
			facingRight = true;
			Flip ();

		} 
		else if (Input.GetAxisRaw (horizontal) > 0 && facingRight)
		{
			facingRight = false;
			Flip ();
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
			this.GetComponent<PolygonCollider2D> ().enabled = false;
			transform.FindChild ("CrouchCollider").GetComponent<PolygonCollider2D> ().enabled = true;
		}
		else
		{
			transform.FindChild ("CrouchCollider").GetComponent<PolygonCollider2D> ().enabled = false;
			this.GetComponent<PolygonCollider2D> ().enabled = true;
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
		punchTimer = 0;



	}
	//functino to jump durrr
	void Jump (float jForce)
	{
		rigid.AddForce(new Vector2 (moveSpeed, jForce));
	}
	void Flip()
	{
		Vector2 theScale = this.transform.localScale;
		theScale.x *= -1;
		this.transform.localScale = theScale;

	}
	//shoot if projectile attack is available, this is an animation event
	void Shoot()
	{
		Vector2 origin = this.transform.position;
		GameObject bullet;
		if (facingRight)
		{
			origin.x -= 1;
		}
		else
			origin.x += 1;
		bullet = Instantiate (Resources.Load ("Projectiles/" + charName + "_bullet"), origin, Quaternion.identity) as GameObject;
		if (facingRight)
		{
			bullet.GetComponent<Bullet>().speed *= -1;
		}
		else 
			bullet.GetComponent<Bullet>().speed *= 1;
	}
	//animation event function to deal damage, in animation event use this format "damage amount,direction value,range of attack,child object name", ex (1,1,2.5,HitUP) NO SPACES
	//for direction, 1 = right/left, 3 = up, 4 = down, left is actually 2 in the script however in the event it could be either direction, so we will set it to 1
	//and then figure out the direction in the script using the facingright bool
	public void Attack(string info)
	{
		string[] nstring = info.Split (',');
		float d = float.Parse (nstring [0]);
		int dir = int.Parse (nstring [1]);
		float range = float.Parse (nstring [2]);
		string hitboxname = nstring [3];
		if (facingRight == true && dir == 1) {
			dir = 2;
		}
		DealDamage dmgscript = transform.FindChild (hitboxname).GetComponent<DealDamage> ();
		dmgscript.dmg = d;
		dmgscript.atkRange = range;
		dmgscript.direction = dir;
		dmgscript.doDamage ();
	}


	//take damage
	public void Damage(float d)
	{
		this.hp -= d;
	}
}
