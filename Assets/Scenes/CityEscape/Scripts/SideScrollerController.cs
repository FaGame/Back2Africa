using UnityEngine;
using System.Collections;

public class SideScrollerController : MonoBehaviour {

	public float moveSpeed = 10f, jumpHeight = 10f;

	private bool Jumping = false;
	private Rigidbody rb;
	
	void Start()
	{
		rb = GetComponent<Rigidbody>();
	}

	// Update is called once per frame
	void Update () {
	
		float h = Input.GetAxis ("Horizontal");

		transform.Translate (new Vector3(0, 0, h) * (Time.deltaTime * moveSpeed));

		if(!Jumping)
		{
			if(Input.GetButtonDown ("A"))
			{		
				Jump();
			}
		}

	}

	void Jump()
	{
		GetComponent<Rigidbody>().AddForce (transform.up * jumpHeight);
		Jumping = true;
	}

	void OnCollisionEnter(Collision collision)
	{
		Jumping = false;
	}

	void CheckGroundCollision()
	{
		
		RaycastHit hit = new RaycastHit();
		float dist;
		Vector3 dir;
		dist = 0.08f;
		dir = -Vector3.up;
		Vector3 pos1, pos2, pos3; 
		CapsuleCollider col = GetComponent<CapsuleCollider>();
		pos1 = new Vector3(transform.position.x, transform.position.y, col.bounds.extents.z); 
		pos2 = new Vector3(transform.position.x, transform.position.y, -col.bounds.extents.z); 
		pos3 = transform.position;
		
		//end edit//
		if((Physics.Raycast(pos1,dir,out hit,dist) || Physics.Raycast(pos2,dir,out hit,dist) || Physics.Raycast(pos3,dir,out hit,dist)) && rb.velocity.y <= 0){
			//the ray collided with something, you can interact
			// with the hit object now by using hit.collider.gameObject
			
			Jumping = false;
		}
		else{
			//nothing was below your gameObject within 10m.
		}
		
	}
}
