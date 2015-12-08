using UnityEngine;
using System.Collections;

public class OrbitPlanetPhysics : MonoBehaviour {

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
		transform.rotation = Quaternion.FromToRotation(transform.up, (transform.position - sphere.transform.position).normalized) * transform.rotation;
	}

}
