using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadingCircle : MonoBehaviour {

	// Use this for initialization

	public float rotSpeed = 0f;

	// Update is called once per frame
	void Update () {

		transform.Rotate (Vector3.forward * Time.deltaTime * rotSpeed);
	}
}
