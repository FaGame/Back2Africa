using UnityEngine;
using System.Collections;

public class ApplyColliders : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
		Transform[] transforms = gameObject.GetComponentsInChildren<Transform>();		

		foreach(Transform t in transforms)
		{
			GameObject go = t.gameObject;
			
			if(go.GetComponent<MeshRenderer>() != null)
			{
				MeshCollider col = go.AddComponent <MeshCollider>() as MeshCollider;
			}

		}
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
