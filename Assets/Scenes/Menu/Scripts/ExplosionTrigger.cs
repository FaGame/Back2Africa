using UnityEngine;
using System.Collections;

public class ExplosionTrigger : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	
	}
	
	void OnCollisionEnter(Collision collision)
	{
		if(collision.collider.gameObject.name == "pp_truck")
		{
			GetComponentInChildren<ParticleSystem>().Play ();
		}
	}
	
}
