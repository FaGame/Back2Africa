using UnityEngine;
using System.Collections;

public class DestroyTruckOnImpact : MonoBehaviour {

	public float destroyDelay = 0.1f;
	
	void OnTriggerEnter(Collider collider)
	{
		if(collider.gameObject.name == "pp_truck")
			Destroy (collider.gameObject, destroyDelay);
	}
	
}
