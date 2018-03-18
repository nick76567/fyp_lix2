using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using UnityEngine.SceneManagement;
using DatabaseControl;



public class UserAccount_Lobby : MonoBehaviour {

	public Text usernameText;

	// Use this for initialization
	void Start () {

		usernameText.text = "Logged in as " + DCF_DemoScene_ManagerScript_CSharp.playerUsername;
	}

	
	public void LogOut ()
	{
		DCF_DemoScene_ManagerScript_CSharp.instance.Logout ();
	}

}