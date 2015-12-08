using UnityEngine;
using System.Collections;



public class CameraController : MonoBehaviour {

	public enum CameraType {
		Cinematic,
		Follow,
		Overhead,
		Reverse
	}

	public CameraType cameraType;
	public GameObject target;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
		/*
		if(Input.GetButtonDown ("Y") || Input.GetKeyDown (KeyCode.C))
		{
			if(cameraType.Equals (CameraType.Overhead))
				cameraType = CameraType.Reverse;
			else if(cameraType.Equals (CameraType.Reverse))
				cameraType = CameraType.Follow;
			else if(cameraType.Equals (CameraType.Follow)) 
				cameraType = CameraType.Cinematic;	
			else if(cameraType.Equals (CameraType.Cinematic)) 
				cameraType = CameraType.Overhead;	
		}

		*/

		if(cameraType.Equals (CameraType.Cinematic))
			CalcCinematicCamera();
		else if(cameraType.Equals (CameraType.Follow)) 
			CalcFollowCamera();
		else if(cameraType.Equals (CameraType.Overhead)) 
			CalcOverheadCamera();
		else if(cameraType.Equals (CameraType.Reverse)) 
			CalcReverseCamera();
		
	}

	void CalcCinematicCamera()
	{
		float xOffset = 0.0f, yOffset = 3.0f, zOffset = -3.0f, followSpeed = 0.5f, rotateSpeed = 1.0f;
		Vector3 targetPosition = new Vector3(target.transform.position.x + xOffset,target.transform.position.y + yOffset, target.transform.position.z + zOffset);
		transform.position = Vector3.Lerp (transform.position, targetPosition, Time.deltaTime * followSpeed);
		transform.rotation = Quaternion.Lerp (transform.rotation, Quaternion.LookRotation ((target.transform.position - transform.position).normalized), Time.deltaTime * rotateSpeed);
	}

	void CalcFollowCamera()
	{
		float xOffset = 0.0f, yOffset = 1.5f, zOffset = -3.0f;
		Vector3 targetPosition = target.transform.rotation * new Vector3(xOffset, yOffset, zOffset) + target.transform.position;
		transform.rotation = target.transform.rotation;
		transform.position = targetPosition;
	
	}

	void CalcReverseCamera()
	{
		float xOffset = 0.0f, yOffset = 1.5f, zOffset = 3.0f;
		Vector3 targetPosition = target.transform.rotation * new Vector3(xOffset, yOffset, zOffset) + target.transform.position;
		transform.rotation = Quaternion.LookRotation ((target.transform.position - transform.position).normalized);
		transform.position = targetPosition;
		
	}

	void CalcOverheadCamera()
	{
		float xOffset = 0.0f, yOffset = 5.0f, zOffset = 0.0f, followSpeed = 1.0f, rotateSpeed = 2.0f;
		Vector3 targetPosition = target.transform.rotation * new Vector3(xOffset, yOffset, zOffset) + target.transform.position;
		transform.position = Vector3.Lerp (transform.position, targetPosition, Time.deltaTime * followSpeed);
		transform.rotation = Quaternion.Lerp (transform.rotation, Quaternion.LookRotation ((target.transform.position - transform.position).normalized), Time.deltaTime * rotateSpeed);
		
	}
}
