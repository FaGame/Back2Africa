using UnityEngine;
using UnityEngine.UI;
using System.Collections;

[RequireComponent(typeof(Animator))]

/* APPLY TO PLAYER OBJECT 
	   TWEAK MOVE, ROTATE AND JUMP POWER AS NECESSARY
	*/

public class FighterPlayerController : MonoBehaviour {

	public GameObject enemy;
	
	public enum PlayerState
	{
		Idle,  // 0
		WalkingForward, // 1
		WalkingBackward, // 2
		Jumping, // 3
		Kicking, // 4
		Punching, // 5
		Special, //6
		Dead // 7
	}

	public PlayerState state = PlayerState.Idle;

	private Animator anim;
	private Rigidbody rb;
	
	public bool lockedControl;
	
	public float moveSpeed = 20.0f;
	public float jumpHeight = 300f;
	
	private int kickDamage = 10, punchDamage = 5, specialDamage = 25;

	public Collider PunchHitBox, KickHitBox, SpecialHitBox;

	private bool facingRight;
	
	void Start()
	{
		
		rb = GetComponent<Rigidbody>();
		anim = GetComponent<Animator>();

		// disable hit colliders
		DisableHitColliders();
		
	}

	void DisableHitColliders()
	{
		PunchHitBox.enabled = false;
		KickHitBox.enabled = false;
		SpecialHitBox.enabled = false;
	}

	// Update is called once per frame
	void Update () {
		
		FaceEnemy();

		CheckGroundCollision ();

		SetAnimationState();

		if(!lockedControl)
			InputMovement();
		
	}

	void FaceEnemy()
	{
		Quaternion r = transform.rotation;
		if(enemy.transform.position.z > transform.position.z)
		{
			r.eulerAngles = new Vector3(transform.rotation.eulerAngles.x, 0, transform.rotation.eulerAngles.z);
			facingRight = true;
		}
		else if(enemy.transform.position.z < transform.position.z)
		{
			r.eulerAngles = new Vector3(transform.rotation.eulerAngles.x, 180, transform.rotation.eulerAngles.z);
			facingRight = false;
		}

		transform.rotation = r;
	}
	
	void InputMovement()
	{
	
		if(!state.Equals (PlayerState.Jumping) && !state.Equals (PlayerState.Kicking) && !state.Equals (PlayerState.Punching) && !state.Equals (PlayerState.Special))
		{	

			// Get Input		
			float h;
	
			h = Input.GetAxis ("Horizontal");	
			Vector3 velocity = Vector3.zero;	
		
			if(Input.GetKey(KeyCode.A))
				h = -1;	
			else if(Input.GetKey(KeyCode.D))
				h = 1;
				

			// if Input, move
			if(h != 0)
			{ 
				if(!facingRight)
					h = -h;
				if(h > 0)
					state = PlayerState.WalkingForward;
				else if(h < 0)
					state = PlayerState.WalkingBackward;
				
				velocity = new Vector3(0,0,h) * moveSpeed;
				transform.Translate(velocity * Time.deltaTime);	
			}
			else
			{
				state = PlayerState.Idle;
			}

			// Handle Jumping
			if(Input.GetButtonDown("A") || Input.GetKeyDown (KeyCode.Space))
			{
				Jump ();
			}

		}
		
		if(!state.Equals(PlayerState.Kicking) && !state.Equals (PlayerState.Punching) && !state.Equals (PlayerState.Special))
		{
			if(Input.GetButtonDown("B"))
				Kick();	
			else if(Input.GetButtonDown("X"))
				Punch();
			else if(Input.GetButtonDown("Y"))
				Special();	
		}

		
				
	}
	
	void Jump()
	{
		if(state.Equals (PlayerState.WalkingForward))
			rb.AddForce((transform.up * jumpHeight) + (transform.forward * 250), ForceMode.Force);
		else if(state.Equals (PlayerState.WalkingBackward))
			rb.AddForce((transform.up * jumpHeight) + (-transform.forward * 250), ForceMode.Force);
		else
			rb.AddForce(transform.up * jumpHeight, ForceMode.Force);
		
		state = PlayerState.Jumping;
			
	}
		
	void Kick()
	{
		KickHitBox.enabled = true;
		state = PlayerState.Kicking;
	}

	void Punch()
	{
		PunchHitBox.enabled = true;
		state = PlayerState.Punching;
	}

	void Special()
	{
		SpecialHitBox.enabled = true;
		state = PlayerState.Special;
	}
	
	public void End()
	{
		DisableHitColliders ();
		state = PlayerState.Idle;
	}
	
	void CheckGroundCollision()
	{
		
		RaycastHit hit = new RaycastHit();
		float dist;
		Vector3 dir;
		dist = 0.025f;
		dir = -Vector3.up;
		Vector3 pos1, pos2, pos3;
		CapsuleCollider col = GetComponent<CapsuleCollider>();
		pos1 = new Vector3(transform.position.x, transform.position.y - 0.4f, transform.position.z); 
		pos2 = new Vector3(transform.position.x, transform.position.y - 0.4f, transform.position.z - 0.2f); 
		pos3 = new Vector3(transform.position.x, transform.position.y - 0.4f, transform.position.z + 0.2f); 
		Debug.DrawRay (pos1, dir * dist, Color.green);
		Debug.DrawRay (pos2, dir * dist, Color.green);
		Debug.DrawRay (pos3, dir * dist, Color.green);
		//end edit//
		if(Physics.Raycast(pos1,dir,out hit,dist) || Physics.Raycast(pos2,dir,out hit,dist)
			 || Physics.Raycast(pos3,dir,out hit,dist)){
				
		}
		else{
			//nothing was below your gameObject within 10m.
		}
		
	}

	void OnTriggerEnter(Collider collider)
	{
		if(collider.transform.IsChildOf(enemy.transform))
		{
			if(collider.gameObject.name == "SpecialHitBox")
			{
				rb.AddForce ((transform.position - enemy.transform.position).normalized * 200);
				if(!state.Equals (PlayerState.WalkingBackward))
					TakeDamage (specialDamage);
				else {
					TakeDamage (specialDamage / 2);
				}
			}
			else if(collider.gameObject.name == "PunchHitBox")
			{
				rb.AddForce ((transform.position - enemy.transform.position).normalized * 100);
				if(!state.Equals (PlayerState.WalkingBackward))
					TakeDamage (punchDamage);
				else {
					TakeDamage (punchDamage / 2);
				}	
		
			}
			else if(collider.gameObject.name == "KickHitBox")
			{
				rb.AddForce ((transform.position - enemy.transform.position).normalized * 125);
				if(!state.Equals (PlayerState.WalkingBackward))
					TakeDamage (kickDamage);
				else {
					TakeDamage (kickDamage / 2);
				}
			}
			
			DisableHitColliders ();
			if(collider.gameObject.name == "HurtBox")
				Debug.Log ("Hit" + gameObject);

		}
	}	
	

	void OnCollisionEnter(Collision collision)
	{	

	}

	public void TakeDamage(int Damage)
	{
		Debug.Log (Damage);
	}

	public void SetAnimationState()
	{
		anim.SetInteger ("State", (int)state);
	}	
	
	
}