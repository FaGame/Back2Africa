using UnityEngine;
using UnityEngine.UI;
using System.Collections;

[RequireComponent(typeof(Animator))]

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
		
		Moving = false;
		
		float v,h;
		v = Input.GetAxis ("Vertical");
		h = Input.GetAxis ("Horizontal");
		
		Vector3 velocity = Vector3.zero;		

		if(Input.GetButtonDown("A"))
		{
			if(!Jumping)
				Jump ();
		}	
		
		if(v > 0)
		{ 
			velocity = new Vector3(0,0,v) * moveSpeed;
			Moving = true;
		}
		else if(Input.GetKey(KeyCode.W))
		{
			velocity = new Vector3(0,0,1) * moveSpeed;
			Moving = true;
		}
		else if(Input.GetKey(KeyCode.S))
		{
			velocity = new Vector3(0,0,-1) * moveSpeed;
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
	
	
}