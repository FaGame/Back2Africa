using UnityEngine;
using System.Collections;

public class SideScrollCamera : MonoBehaviour {

	public Transform target;

	public float xOffset, yOffset = 3.0f, zOffset = -15f, followSpeed = 10.0f;
	// Use this for initialization

	// Update is called once per frame
	void LateUpdate () {
	
		CalcCamera();
	}

	void CalcCamera()
	{
		Vector3 v = new Vector3(target.position.x + xOffset, target.position.y + yOffset, target.position.z + zOffset);
		transform.position = Vector3.Lerp (transform.position, v, Time.deltaTime * followSpeed);

		transform.rotation = Quaternion.LookRotation ((target.position - transform.position).normalized); 
		//transform.rotation = Quaternion.LookRotation (target.position - transform.position);
	}
}
