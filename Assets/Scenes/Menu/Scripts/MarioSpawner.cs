using UnityEngine;
using System.Collections;

public class MarioSpawner : MonoBehaviour {
	
	public GameObject spawnPrefab;
	public float spawnDelay = 0.1f;
	public float destroyDelay = 5.0f;
	
	// Use this for initialization
	void Start () {
	
		InvokeRepeating ("Spawn", 0, spawnDelay);
		Destroy (gameObject, destroyDelay);
	
	}
	
	void Spawn()
	{
		Instantiate(spawnPrefab, transform.position, Quaternion.identity); 
	}
}
