using UnityEngine;
using System.Collections;

public class MovementInfo : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info){
		if(stream.isWriting){
			stream.SendNext(transform.position);
			stream.SendNext(transform.rotation);
			stream.SendNext(rigidbody.velocity);
		}
		else{
			transform.position = Vector3.Lerp(transform.position,(Vector3)stream.ReceiveNext(),Time.deltaTime*10f);
			transform.rotation = Quaternion.Lerp(transform.rotation,(Quaternion)stream.ReceiveNext(),Time.deltaTime*10f);
			rigidbody.velocity = Vector3.Lerp(rigidbody.velocity,(Vector3)stream.ReceiveNext(),Time.deltaTime*10f);
		}

	}

}
