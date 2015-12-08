using UnityEngine;
using System.Collections;

public class MenuUIScript : MonoBehaviour {

	public ParticleSystem transitionWormhole;
	public Transform sonicTransform;
	public float transitionTime = 3.3f;

	public void QuitGame()
	{
		Application.Quit ();
	}

	public void NextLevel()
	{
		transitionWormhole.Play ();
		Invoke ("GoNextLevel", transitionTime);	
		InvokeRepeating ("MoveSonicDown", 0.5f, 0.01f);
	}

	public void MoveSonicDown()
	{
		sonicTransform.position = new Vector3(sonicTransform.position.x, sonicTransform.position.y - 0.01f, sonicTransform.position.z);
	}

	public void GoNextLevel()
	{
		Application.LoadLevel (Application.loadedLevel + 1);
	}

	public void RestartLevel()
	{
		Application.LoadLevel (Application.loadedLevel);
	}
}
