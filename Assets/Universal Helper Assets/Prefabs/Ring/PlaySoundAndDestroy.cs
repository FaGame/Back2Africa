using UnityEngine;
using System.Collections;

public class PlaySoundAndDestroy : MonoBehaviour {

	void OnTriggerEnter(Collider collider)
	{
		if(collider.gameObject.tag == "Player")
		{
			AudioSource audio = GetComponent<AudioSource>();
			audio.PlayOneShot (audio.clip);
			Destroy(GetComponentInChildren<MeshRenderer>());
			Destroy (GetComponent<BoxCollider>());
			Destroy (GetComponent<Light>());
			Destroy (gameObject, 1.0f);
		}
	}
}
