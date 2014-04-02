using UnityEngine;
using System.Collections;

public class Cameras : MonoBehaviour {
	public Vector3 offset;
	// Use this for initialization
	void Start () {
	
	}

	public void adjustTransform(GameObject plane){
		this.gameObject.transform.parent = plane.transform;

	}

	// Update is called once per frame
	void Update () {
		this.gameObject.transform.position = offset;
	}
}
