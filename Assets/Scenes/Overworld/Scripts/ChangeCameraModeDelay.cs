using UnityEngine;
using System.Collections;

public class ChangeCameraModeDelay : MonoBehaviour {

	public float changeDelay = 3.3f;
	// Use this for initialization
	void Start () {
		Invoke ("ChangeCamera", changeDelay);
	}
	


	void ChangeCamera()
	{
		GetComponent<CameraController>().cameraType = CameraController.CameraType.Follow;
		//GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>().lockedControl = false;
	}
}
