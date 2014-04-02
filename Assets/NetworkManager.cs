using UnityEngine;
using System.Collections;

public class NetworkManager : Photon.MonoBehaviour {
	public Cameras camerasObject;
	// Use this for initialization
	void Start () {
		PhotonNetwork.ConnectUsingSettings("alpha 0.1");
	}

	void OnGUI(){
		GUILayout.Label(PhotonNetwork.connectionStateDetailed.ToString());
	}

	void OnJoinedLobby(){
		PhotonNetwork.JoinRandomRoom();
	}

	void OnPhotonRandomJoinFailed(){
		PhotonNetwork.CreateRoom(null);
	}

	void OnJoinedRoom(){
		GameObject myPlane = PhotonNetwork.Instantiate("Plane",Random.onUnitSphere ,Quaternion.identity,0);
		Camera.main.transform.parent = myPlane.transform;

	}

}
