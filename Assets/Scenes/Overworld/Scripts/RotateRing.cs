using UnityEngine;
using System.Collections;

public class RotateRing : MonoBehaviour {
	public float speed = 1f;
	// Update is called once per frame
	void Update () {
	
		transform.Rotate (transform.up, speed, Space.Self);
	}
}
