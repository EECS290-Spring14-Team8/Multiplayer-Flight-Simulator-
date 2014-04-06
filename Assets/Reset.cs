using UnityEngine;
using System.Collections;

public class Reset : MonoBehaviour {
	void Update () {
		if (Input.GetKey ("t")){
			this.transform.position = new Vector3(0,2,0);
			this.rigidbody.velocity = Vector3.zero;
			this.transform.rotation = Quaternion.identity;
		}
	}
}

