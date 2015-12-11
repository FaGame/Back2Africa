using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class FighterGameController : MonoBehaviour {

	public GameObject player1, player2;
	public Slider player1HealthBar, player2HealthBar; 

	private FighterPlayerController p1Script;
	private FighterAIController p2Script;
	
	public enum GameState
	{
		Round1,
		Round2,
		Round3,
		GameOver
	}
	
	public GameState gameState;

	// Use this for initialization
	void Start () {
			
		p1Script = player1.GetComponent<FighterPlayerController>();
		p2Script = player2.GetComponent<FighterAIController>();
		// hud setup
		player1HealthBar.maxValue = p1Script.health;
		player2HealthBar.maxValue = p2Script.health;

		Physics.gravity = new Vector3(0,-20,0);
				
	}
	
	// Update is called once per frame
	void LateUpdate () {
	
		// handle hud
		HandleHud();

		if(gameState.Equals (GameState.Round1))
		{
		
			// play middle text, delay 3 seconds, show seconds go down, when finished enable player movement, start top timer, count down from 100,
			// get impacct text for timer
			// if a player dies go to round 2		

		}

	}

	

	void HandleHud()
	{
		player1HealthBar.value = p1Script.health;
		player2HealthBar.value = p2Script.health;
	}
}
