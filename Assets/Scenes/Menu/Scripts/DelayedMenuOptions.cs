using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class DelayedMenuOptions : MonoBehaviour {

	public float delay = 10f;

	// Use this for initialization
	void Start () {
		Button btn = GetComponent<Button>();
		btn.interactable = false;
		Invoke("Enable", delay);
	}

	void Enable()
	{
		GetComponent<Button>().interactable = true;
	}
	
	
}
