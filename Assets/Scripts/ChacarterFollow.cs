using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChacarterFollow : MonoBehaviour {

	public Transform target;
	public float distance;
	public float height;


	void LateUpdate() {
	
		if (!target)
			return;

		float wantedRotationAngle = target.eulerAngles.y;
		float wantedHeight = target.position.y + height;
		float currentRotationAngle = transform.eulerAngles.y;
		float currentHeight = transform.position.y;


		currentRotationAngle = Mathf.LerpAngle (currentRotationAngle, wantedRotationAngle, Time.deltaTime * 3);
		currentHeight = Mathf.Lerp (currentHeight, wantedHeight, Time.deltaTime * 2);


		Quaternion currentRotation = Quaternion.Euler (0, currentRotationAngle, 0);

		transform.position = target.position;
		transform.position -= currentRotation * Vector3.forward * distance;
		transform.position = new Vector3 (transform.position.x, currentHeight, transform.position.z);

		transform.LookAt (target);

	
	
	}
}
