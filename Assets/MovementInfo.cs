using UnityEngine;
using System.Collections;

public class MovementInfo : MonoBehaviour {

	// Use this for initialization
	void Start () {
		GameObject[] list = GameObject.FindGameObjectsWithTag("Player");
		for(int i = 0; i < list.Length; i++){
			if(list[i] != NetworkManager.currentPlane){
				Debug.Log (i);
				GameObject dynamics =  list[i].transform.FindChild("Dynamics").gameObject;
				Debug.Log(dynamics);
				dynamics.SetActive(false);
				list[i].GetComponent<Reset>().enabled = false;
			}
		}
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
