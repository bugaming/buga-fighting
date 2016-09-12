using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class HealthPortrait : MonoBehaviour {
	//instantiate in FightBegin script and set player id of this script to match instantiated
	public Sprite port;
	public Image component;
	public Slider hpbar;
	public int id = 0;
	float curHp;
	public string aname;

	GameObject[] players;

	// Use this for initialization
	void Start () {
		
		hpbar = this.transform.gameObject.GetComponent<Slider> ();
		component = transform.FindChild ("PortandHealth").transform.FindChild ("Portrait").GetComponent<Image>();
		aname = GameObject.FindGameObjectWithTag ("GameController").GetComponent<FightBegin>().charNames [id];
		aname.ToLower ();
		port = Resources.Load<Sprite> ("CharSelect/" + aname); 
		component.sprite = port;


		//needs work, portrait not working

	}
	
	// Update is called once per frame
	void Update () {
		curHp = GameObject.FindGameObjectWithTag("GameController").GetComponent<FightBegin>().players[id].GetComponent<Player>().hp;

		hpbar.value = curHp;

		if (curHp <= 15) {
			//make animatino for flashing red
		}
	
	}
}
