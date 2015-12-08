using UnityEngine;
using System.Collections;

public class RotateRing : MonoBehaviour {

	// Update is called once per frame
	void Update () {
	
		transform.Rotate (transform.up, 1, Space.Self);
	}
}
