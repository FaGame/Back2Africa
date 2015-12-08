using UnityEngine;
using System.Collections;

public class AlignToPlanetNormalPhysics : MonoBehaviour {
	
	/* NOT FUNCTIONAL YET
	*/

	public GameObject sphere;
	public float gravityAmount = 9.81f;
	public bool active = false;
	
	private Rigidbody rb;
	
	
	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody>();
		
	}
	
	// Update is called once per frame
	void Update () {
		
		if(active)
		{	
			ApplyGravity();	
			ApplyRotation();
		}
		
	}
	
	void ApplyGravity()
	{
		rb.AddForce((sphere.transform.position - transform.position).normalized * gravityAmount, ForceMode.Force);		
	}
	
	void ApplyRotation()
	{
		RaycastHit hit = new RaycastHit();
		float dist;
		Vector3 dir;
		dist = 0.5f;
		dir = -Vector3.up;

		Debug.DrawRay(transform.position, dir * dist, Color.green);

		if(Physics.Raycast(transform.position,dir,out hit,dist))
		    transform.rotation = Quaternion.FromToRotation(transform.up, hit.normal) * transform.rotation;
		else {
			transform.rotation = Quaternion.FromToRotation(transform.up, (transform.position - sphere.transform.position).normalized) * transform.rotation;
		}
	}

}
