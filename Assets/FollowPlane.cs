using UnityEngine;
using System.Collections;

public class FollowPlane : MonoBehaviour {
	public GameObject plane;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		this.transform.position = plane.transform.position + Vector3.up * 60;
		this.transform.forward = -Vector3.up;
	}
}
