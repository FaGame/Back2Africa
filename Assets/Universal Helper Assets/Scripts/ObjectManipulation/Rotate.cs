using UnityEngine;
using System.Collections;

public class Rotate : MonoBehaviour {

	public bool active = true;

	public enum RotateAxis
	{
		Around,
		UpsideDown,
		Cartwheel
	}
	
	public RotateAxis rotateAxis;
	public float amount;
	private Vector3 rotationVector;

	// Use this for initialization
	void Start () {
		
		if(rotateAxis.Equals (RotateAxis.Around))
			rotationVector = transform.up;
		
		if(rotateAxis.Equals (RotateAxis.UpsideDown))
			rotationVector = transform.right;
		
		if(rotateAxis.Equals (RotateAxis.Cartwheel))
			rotationVector = transform.forward;

	}
	
	// Update is called once per frame
	void Update () {
	
			if(active)
				transform.Rotate (rotationVector, amount, Space.Self);	

	}
}
