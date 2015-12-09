using UnityEngine;
using System.Collections;

public class MoveContinuously : MonoBehaviour {

	public enum Direction
	{
		Left,
		Right,
		Up,
		Down,
		Forward,
		Back
	
	}

	public float moveSpeed;
	public Direction direction;

	private Vector3 dir;

	// Use this for initialization
	void Start () {
	
		if(direction.Equals (Direction.Left))
			dir = -transform.right;

		if(direction.Equals (Direction.Right))
			dir = transform.right;

		if(direction.Equals (Direction.Up))
			dir = transform.up;

		if(direction.Equals (Direction.Down))
			dir = -transform.up;

		if(direction.Equals (Direction.Forward))
			dir = transform.forward;

		if(direction.Equals (Direction.Back))
			dir = -transform.forward;

	}
	
	// Update is called once per frame
	void Update () {
	
		transform.Translate (dir * (Time.deltaTime * moveSpeed));
		
	}
}
