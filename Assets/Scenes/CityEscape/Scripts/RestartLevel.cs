using UnityEngine;
using System.Collections;

public class RestartLevel : MonoBehaviour {

	void OnCollisionEnter(Collision collision)
	{
		if(collision.collider.gameObject.tag == "Player")
			Application.LoadLevel (Application.loadedLevel);
	}
}
