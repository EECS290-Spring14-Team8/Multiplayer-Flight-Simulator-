using UnityEngine;
using System.Collections;

public class NetworkManager : Photon.MonoBehaviour {
	public Cameras camerasObject;
	public GameObject minimapprefab;
	public GameObject planeholder;
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
		GameObject myPlane = PhotonNetwork.Instantiate("Plane", new Vector3(Random.onUnitSphere.x * 30, 2f, Random.onUnitSphere.z * 30) ,Quaternion.identity,0);
		myPlane.transform.parent = planeholder.transform;
		GameObject[] list = GameObject.FindGameObjectsWithTag("Player");
		for(int i = 0; i < list.Length; i++){
			if(!(list[i].Equals(myPlane))){
				GameObject dynamics =  list[i].transform.FindChild("dynamics").gameObject;
				dynamics.SetActive(false);
			}
		}
		Camera.main.transform.parent = myPlane.transform;
		Camera.main.transform.position = myPlane.transform.position + new Vector3 (0f, 4f, -10f);
		GameObject minimap = (GameObject)GameObject.Instantiate (minimapprefab);
		minimap.GetComponent<FollowPlane> ().plane = myPlane;

	}

}
