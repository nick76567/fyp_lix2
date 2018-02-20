using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SmoothTransform : Photon.MonoBehaviour {

    private Vector3 realPosition;
    private Quaternion realRotation;

	void Update ()
	{
		if(!photonView.isMine)
        {
            transform.position = Vector3.Lerp(transform.position,this.realPosition, Time.deltaTime * 5);
            transform.rotation = Quaternion.Lerp(transform.rotation,this.realRotation, Time.deltaTime * 5);
        }
	}

	void OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info)
	{
	    if (stream.isWriting)
        {
                    // We own this player: send the others our data
            stream.SendNext(transform.position);
            stream.SendNext(transform.rotation);

        }
        else
        {
                    // Network player, receive data
            this.realPosition = (Vector3)stream.ReceiveNext();
            this.realRotation = (Quaternion)stream.ReceiveNext();
        }
	}

}
