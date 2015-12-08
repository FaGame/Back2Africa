using UnityEngine;
using System.Collections;

public class OrbitPlanetPhysics : MonoBehaviour {

	/* APPLY TO PLAYER OBJECT,
	   SET SPHERE VALUE IN EDITOR TO PLANET OBJECT FROM SCENE
	*/

	public GameObject sphere;
	public float gravityAmount = 9.81f;
	public bool active = true;
	
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
