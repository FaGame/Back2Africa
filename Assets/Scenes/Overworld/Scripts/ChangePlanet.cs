using UnityEngine;
using System.Collections;

public class ChangePlanet : MonoBehaviour {

	public GameObject newSphere;

	private Quaternion initRotation;

	private bool transition;
	private GameObject Player;

	public float transitionTime = 3.0f;

	void OnTriggerStay(Collider collision)
	{
		if(Input.GetButtonDown ("A") || Input.GetKeyDown (KeyCode.Space))
		{
		
			if(collision.gameObject.tag == "Player")
			{
				Debug.Log ("worked");
				Player = collision.gameObject;
				InvokeRepeating("MoveTowardSphere", 0, 0.01f);
				Invoke ("ChangeSphere", 0.5f);
				Player.GetComponent<PlayerController>().lockedControl = true;
				Camera.main.GetComponent<CameraController>().cameraType = CameraController.CameraType.Cinematic;
				Invoke ("ChangeCamera", transitionTime);
			}

		}
	}

	void MoveTowardSphere()
	{
		Player.transform.position = Vector3.MoveTowards (Player.transform.position, newSphere.transform.position, Time.deltaTime * 7);
	}

	void ChangeSphere()
	{
		Player.GetComponent<OrbitPlanetPhysics>().sphere = newSphere;
	}

	void ChangeCamera()
	{
		CancelInvoke ("MoveTowardSphere");
		Camera.main.GetComponent<CameraController>().cameraType = CameraController.CameraType.Follow;
		Player.GetComponent<PlayerController>().lockedControl = false;
	}
}
