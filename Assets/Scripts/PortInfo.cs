using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PortInfo : MonoBehaviour {
	public string pName;
	public Sprite selected;
	private Sprite not;

	void Start()
	{
		not = this.GetComponent<Image> ().sprite;
	}
		
	void OnTriggerEnter2D (Collider2D col)
	{
		if (col.gameObject.tag == "Player") {
			this.GetComponent<Image> ().overrideSprite = selected;
		}
	}
	void OnTriggerExit2D(Collider2D col)
	{
		if (col.gameObject.tag == "Player")
		{
			this.GetComponent<Image> ().overrideSprite = not;
		}
	}
}
