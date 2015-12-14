using UnityEngine;
using UnityEngine.UI;
using System.Collections;

[RequireComponent(typeof(Animator))]

	/* APPLY TO PLAYER OBJECT 
	   TWEAK MOVE, ROTATE AND JUMP POWER AS NECESSARY
	*/

public class PlayerController : MonoBehaviour {
	
	private Animator anim;
	private Rigidbody rb;
	private bool Moving = false;
	private bool Jumping = false;

	public bool lockedControl;

	public float moveSpeed = 10.0f, rotateSpeed = 3.0f;
	public float jumpHeight = 300f;
	
	void Start()
	{
		
		rb = GetComponent<Rigidbody>();
		anim = GetComponent<Animator>();
			
	}
	
	
	
	// Update is called once per frame
	void Update () {
		
		if(!lockedControl)
			InputMovement();
	
	}
	
	void InputMovement()
	{
		
		CheckGroundCollision ();
	
		Moving = false;
		
		float v,h;
		v = Input.GetAxis ("Vertical");
		h = Input.GetAxis ("Horizontal");
		
		Vector3 velocity = Vector3.zero;	

		if(Input.GetKey(KeyCode.A))
			h = -1;	
		else if(Input.GetKey(KeyCode.D))
			h = 1;

		if(Input.GetKey(KeyCode.S))
			v = -1;	
		else if(Input.GetKey(KeyCode.W))
			v = 1;

		if(Input.GetButtonDown("A") || Input.GetKeyDown (KeyCode.Space))
		{
			if(!Jumping)
				Jump ();
		}	
		
		if(v != 0)
		{ 
			velocity = new Vector3(0,0,v) * moveSpeed;
			Moving = true;
		}
		
		
		Vector3 rotateAngle = new Vector3(0,h,0) * rotateSpeed;
		
		if(Input.GetKey (KeyCode.D))
			rotateAngle = new Vector3(0,1,0) * rotateSpeed;
		else if(Input.GetKey (KeyCode.A))
			rotateAngle = new Vector3(0,-1,0) * rotateSpeed;

		transform.Translate (velocity * Time.deltaTime);			
		transform.Rotate (rotateAngle);
			
		anim.SetBool ("Moving", Moving);
		
	}

	void Jump()
	{
		rb.AddForce(transform.up * jumpHeight, ForceMode.Force);		
		Jumping = true;
	}
	
	void OnCollisionEnter(Collision collider)
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
		Collider col = GetComponent<Collider>();
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