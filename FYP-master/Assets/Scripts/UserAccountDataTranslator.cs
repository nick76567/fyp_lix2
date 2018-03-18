//using System.Collections;
//using System.Collections.Generic;
using System;
using UnityEngine;

public class UserAccountDataTranslator : MonoBehaviour {

	private static string HEALTH_SYM= "[HEALTH]";
	private static string ATTACK_SYM= "[ATTACK]";

	public static string ValuesToData ( int health, int attack){
	
		return HEALTH_SYM + health + "/" + ATTACK_SYM + attack;
	
	}

	public static int DataToHealth ( string data) {

		return int.Parse (DataToValue (data, HEALTH_SYM));
	}

	public static int DataToAttack ( string data) {
	
		return int.Parse (DataToValue (data, ATTACK_SYM));
	}
		

	private static string DataToValue (string data, string symbol)
	{

		string[] pieces = data.Split ('/');
		foreach (string piece in pieces) {

			if (piece.StartsWith (symbol)) {

				return piece.Substring (symbol.Length);
			}
		}

		Debug.LogError (symbol + " not found in " + data);
		return "";

	}


}
