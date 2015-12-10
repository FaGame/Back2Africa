using UnityEngine;
using System.Collections;

public class FighterCameraController : MonoBehaviour {

	public Transform target1, target2;
	
	private float initialDistance;
	public float lerpSpeed = 3.0f;

	// Use this for initialization
	void Start () {
	
		initialDistance = transform.position.x;

	}
	
	// Update is called once per frame
	void LateUpdate () {
	
		CalcCamera();
	}
	
	void CalcCamera()
	{
		float cameraDistance = 0.0f;
		
		cameraDistance = 1 + (Mathf.Abs (target1.position.z - target2.position.z) + Mathf.Abs (target1.position.y - target2.position.y)) / 2;
		cameraDistance = Mathf.Clamp (cameraDistance, 3, 6);

		Vector3 cameraPos = (target1.position + target2.position) / 2;
		Vector3 lookAtPos = cameraPos;
		lookAtPos.y += 1;
		Quaternion cameraRot = Quaternion.LookRotation (lookAtPos - transform.position);
		cameraPos.x = cameraDistance;
		cameraPos.y += 2.0f;

		transform.position = Vector3.Lerp (transform.position, cameraPos, Time.deltaTime * lerpSpeed);
		transform.rotation = Quaternion.Lerp (transform.rotation, cameraRot, Time.deltaTime * lerpSpeed);
				
		
	}
	
}
