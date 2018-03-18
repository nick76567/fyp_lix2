using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DatabaseControl;

public class PlayerStats : MonoBehaviour {

	public Text HealthPower;
	public Text Attack;
	public Text Name;

	// Use this for initialization
	void Start () {

		if (DCF_DemoScene_ManagerScript_CSharp.instance.IsLoggedIn) {
			DCF_DemoScene_ManagerScript_CSharp.instance.GetData(OnReceivedData);

		}
	}

	void OnReceivedData (string data)
	{
		HealthPower.text = "Health: " + UserAccountDataTranslator.DataToHealth (data).ToString();
		Attack.text = "Attack: " + UserAccountDataTranslator.DataToAttack (data).ToString();
	}
}
