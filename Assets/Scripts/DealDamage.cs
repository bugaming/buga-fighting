using UnityEngine;
using System.Collections;

public class DealDamage : MonoBehaviour {
	public float dmg;
	public float atkRange;
	public int direction;
	//direction, 1 = right, 2 = left, 3 = up, 4 = down


	public void doDamage()
	{
		Vector2 dir = Vector2.right;
		switch (direction) {
		case 1:
			dir = Vector2.right;
			break;
		case 2:
			dir = Vector2.left;
			break;
		case 3: 
			dir = Vector2.up;
			break;
		case 4: 
			dir = Vector2.down;
			break;
		default:
			print ("NoDirection set");
			break;
		}


		RaycastHit2D hit = Physics2D.Raycast (this.transform.position, dir, atkRange);
		if (hit.transform.gameObject.tag == "Player") 
		{
				hit.transform.gameObject.GetComponent<Player> ().Damage (dmg);
				dmg = 0;
		} 
	}
}
