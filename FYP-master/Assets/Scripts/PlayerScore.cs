using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DatabaseControl;



[RequireComponent(typeof(Player))]
public class PlayerScore : MonoBehaviour {


	Player player;
	// Use this for initialization
	void Start () {

		player = GetComponent<Player> ();
		StartCoroutine (SyncScoreLoop ());


	}

	IEnumerator SyncScoreLoop () {

		while (true) {

			yield return new WaitForSeconds (5f);
			SyncNow ();
		
		}
	}

//	void OnDestroy() {
//
//	if (player != null) {
//			SyncNow ();
//		}
//	}
//

	void SyncNow () {

		if (DCF_DemoScene_ManagerScript_CSharp.instance.IsLoggedIn) {

			DCF_DemoScene_ManagerScript_CSharp.instance.GetData (OnDataReceived);

		}
	}

	void OnDataReceived(string data)
	{
		int health = UserAccountDataTranslator.DataToHealth (data);
		int attack = UserAccountDataTranslator.DataToAttack (data);

		int newhealth = player.health+ health;
		int newattack = player.attack + attack;

		string newData = UserAccountDataTranslator.ValuesToData (newhealth, newattack);

		Debug.Log ("Syncing: " + newData);



		DCF_DemoScene_ManagerScript_CSharp.instance.SendData (newData);



	}
}
