using UnityEngine;
using System.Collections;

public class DoubleBoxSizeOnCollision : MonoBehaviour {

	void OnCollisionEnter(Collision collision)
	{
		transform.localScale *= 2;
	}		

}
