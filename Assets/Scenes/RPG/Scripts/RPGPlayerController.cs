using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(Rigidbody))]

public class RPGPlayerController : MonoBehaviour {

	private Rigidbody rb;
	private Animator anim;

	public enum ActionState
	{
		Idle,                 // 0
		Walking,              // 1
		MeleeAttacking,       // 2
		Casting1Hand,         // 3
		Casting2Hand,         // 4
		VerticalCasting1Hand, // 5
		VerticalCasting2Hand, // 6
		Dead                  // 7
	}

	public ActionState actionState;

	public float moveSpeed = 1.0f;

	private float strafe, forward;

	// Use this for initialization
	void Start () {
	
		rb = GetComponent<Rigidbody>();
		anim = GetComponent<Animator>();		
	
	}
	
	// Update is called once per frame
	void Update () {
			
		SetAnimationState ();
			
		HandleActionStates();
	
	}

	void HandleActionStates()
	{	
		float v,h;
		v = Input.GetAxis ("Vertical");
		h = Input.GetAxis ("Horizontal");
		
		strafe = h;
		forward = v;

		if(actionState.Equals (ActionState.Idle))
		{
			if(v != 0 || h != 0)
			{
				actionState = ActionState.Walking;
			}

		}

		if(actionState.Equals (ActionState.Walking))
		{
	
			if(v != 0 || h != 0)
			{
				rb.AddForce ((transform.right * h) / 2, ForceMode.VelocityChange); 

				if(v != 0)
				{
					rb.AddForce (new Vector3(Camera.main.transform.forward.x, 0f, Camera.main.transform.forward.z) * v *  moveSpeed, ForceMode.VelocityChange);	
					transform.rotation = Quaternion.Lerp (transform.rotation, 
													new Quaternion(0f, Camera.main.transform.rotation.y,0f, Camera.main.transform.rotation.w), Time.deltaTime * 5);
				}				
			}
			else {
				actionState = ActionState.Idle;
			}

		}

	}

	

	void SetAnimationState()
	{
		anim.SetInteger ("State", (int) actionState);
		anim.SetFloat ("Strafe", strafe);
		anim.SetFloat("Forward", forward);
	}

	

}
