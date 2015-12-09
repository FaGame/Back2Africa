using UnityEngine;
using System.Collections;

public class DestroyAfterTime : MonoBehaviour {

	public float lifetime;

	// Use this for initialization
	void Start () {
	
		Destroy (gameObject, lifetime);

	}
	

}
