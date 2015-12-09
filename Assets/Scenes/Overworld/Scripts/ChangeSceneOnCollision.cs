using UnityEngine;
using System.Collections;

public class ChangeSceneOnCollision : MonoBehaviour {

	public string levelName;

	void OnCollisionEnter(Collision collision)
	{
		if(collision.collider.gameObject.tag == "Player")
		{
			Application.LoadLevel (levelName);
		}
	}

	
}
