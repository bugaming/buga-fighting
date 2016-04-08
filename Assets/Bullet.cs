using UnityEngine;
using System.Collections;

public class Bullet : MonoBehaviour {
	

	Vector2 start;
	public float dmg;
	public float speed;

	void Start()
	{
		start = this.transform.position;
	}

	// Update is called once per frame
	void Update () {
		this.transform.Translate (Vector2.right * speed);
		if (this.transform.position.x > (start.x + 15) || this.transform.position.x < (start.x - 15)) 
		{
			Destroy (this.gameObject);
		}
	}
	void OnCollisionEnter2D(Collision2D col)
	{
		if (col.gameObject.tag == ("Player")) {
			col.gameObject.GetComponent<Player> ().Damage (dmg);
			Destroy (this.gameObject);
		} 
		if (col.gameObject.tag == "Level") {
			Destroy (this.gameObject);
		}

	}
}
