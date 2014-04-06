using UnityEngine;
using System.Collections;

public class Smoke : MonoBehaviour {
	
	public Transform plane;
	public GameObject smoke;
	Queue smokeParticles;
	GameObject temp;
	// Use this for initialization
	void Start () {
		smokeParticles = new Queue ();
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetKey ("space")){
			smoke = PhotonNetwork.Instantiate ("Smoke Trail", plane.position, Quaternion.identity, 0);
			smokeParticles.Enqueue (smoke);
		}
		if (smokeParticles.Count > 100) {
			PhotonNetwork.Destroy((GameObject)smokeParticles.Dequeue ());
		}
	}
}
