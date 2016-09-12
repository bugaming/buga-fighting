using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GameStart : MonoBehaviour {
	public GameObject[] mainButtons;
	public GameObject[] multiButtons;
	public GameObject OptionScreen;
	public string connectID;
	public string serverPassword;

	public Toggle controls;
	public Text text;
	public Text dialog;
	public string input;
	public string inputString;

	private GameObject inputField;


	// Use this for initialization
	void Start () {
		//find gameobjects
		inputField = GameObject.FindGameObjectWithTag("UserInput");
		inputField.SetActive (false);
		inputField.SetActive(false);

		PlayerPrefs.SetInt ("UseKB", 0);

		//initialize correct menu items
		foreach (GameObject mainButton in mainButtons) 
		{
			mainButton.SetActive (true);
		}
		foreach (GameObject multiButton in multiButtons) {
			multiButton.SetActive (false);
			OptionScreen.SetActive (false);
		}
	}

	//method inputfield calls in unity engine to send string to input method to use in other methods
	public void UserInput()
	{
		inputField.SetActive (true);
		input = text.text;
		inputString = input;
	}
	public string toString ()
	{
		return inputString;
	}


	//show multiplayer buttons
	public void showMultiplayer()
	{
		foreach (GameObject mainButton in mainButtons) 
		{
			mainButton.SetActive (false);
		}
		foreach (GameObject multiButton in multiButtons) {
			multiButton.SetActive (true);
		}
	}
	//begin singleplayer game
	public void SinglePGame()
	{
		UnityEngine.SceneManagement.SceneManager.LoadScene (1);

	}
	//Connect to mutltiplayergame
	public void ConnectToGame()
	{

		dialog.text = "Connect Address";
		UserInput ();
		connectID = toString ();
		if (connectID != "") {
			//need connect ID from input
			Network.Connect (connectID);
		}

		inputField.SetActive (true);


	}
	//host MultiplayerGame
	public void HostMultiplayer()
	{

		UserInput ();
		dialog.text = "Enter server password";
		serverPassword = toString();
		if (serverPassword != "") {
			Network.incomingPassword = (serverPassword);
			bool useNat = !Network.HavePublicAddress ();
			Network.InitializeServer (32, 25000, useNat);
		}
	}

	void OnServerInitialized()
	{
		print ("server started");
		UnityEngine.SceneManagement.SceneManager.LoadScene (1);
	}





	//return to main menu
	public void ReturnButton()
	{
		foreach (GameObject mainButton in mainButtons) 
		{
			mainButton.SetActive (true);
		}
		foreach (GameObject multiButton in multiButtons) {
			multiButton.SetActive (false);
		}
		OptionScreen.SetActive (false);
	}

	//open option menu
	public void OptionPanel()
	{
		OptionScreen.SetActive (true);
	}
	//exit the game
	public void Exit()
	{
		Application.Quit ();
	}

	//Host game start

	//ask player 1 what input they will be using, controller or keyboard, set con as 0 for kb, 1 for controller
	public void SetControls ()
	{
		bool usekb = controls.GetComponent<Toggle> ().isOn;
		if (usekb == true) {
			PlayerPrefs.SetInt ("UseKB", 1);
			print (PlayerPrefs.GetInt("UseKB"));
		}
		else if (usekb == false) {
			PlayerPrefs.SetInt ("UseKB", 0);
			print (PlayerPrefs.GetInt("UseKB"));
		}
	}

}	
