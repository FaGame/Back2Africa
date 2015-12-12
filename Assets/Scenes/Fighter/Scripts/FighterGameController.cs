using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Diagnostics;

public class FighterGameController : MonoBehaviour {

	public GameObject player1, player2;
	public Slider player1HealthBar, player2HealthBar; 
	public Text timerText1, timerText2;
	public Text winnerText1, winnerText2;

	private FighterPlayerController p1Script;
	private FighterAIController p2Script;

	private int p1Wins, p2Wins;
	private GameObject roundWinner;	

	private int time = 0;

	public Stopwatch timer;
	
	public enum GameState
	{
		Countdown,
		Round1,
		Round2,
		Round3,
		RoundWin,
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
	void Update () {
	
		// handle hud
		HandleHud();

		if(gameState.Equals (GameState.Countdown))
		{

			if(timer == null)
			{
				timer = new Stopwatch();
				timer.Start();

				p1Script.lockedControl = true;
				p2Script.lockedControl = true;
				p1Script.state = FighterPlayerController.PlayerState.Idle;
				p2Script.state = FighterAIController.PlayerState.Idle;
			}
			
			time = 3 - (int) timer.Elapsed.TotalSeconds;

			if(time <= 0)
			{
				p1Script.lockedControl = false;
				p2Script.lockedControl = false;
				timer = null;
				gameState = GameState.Round1;
			}
		}	

		if(gameState.Equals (GameState.Round1))
		{
			if(timer == null)
			{
				timer = new Stopwatch();
				timer.Start();
			}
			time = 100 - (int) timer.Elapsed.TotalSeconds;
			
			if(p1Script.health <= 0 || p2Script.health <= 0 || time <= 0)
			{
				if(p1Script.health > p2Script.health)
				{
					roundWinner = player1;
				}
				else
				{
					roundWinner = player2;
				}
							
				timer=null;
				gameState = GameState.RoundWin;
			}

		}

		if(gameState.Equals (GameState.RoundWin))
		{
			if(timer == null)
			{
				timer = new Stopwatch();
				timer.Start();
				time = 0;
				winnerText1.enabled = true;
				winnerText2.enabled = true;
				winnerText1.text = "Round Winner\n" + roundWinner.name;
				winnerText2.text = "Round Winner\n" + roundWinner.name;	
				p1Script.lockedControl = true;
				p2Script.lockedControl = true;
			}
			
			if((int) timer.Elapsed.TotalSeconds > 3)
			{
				player1.transform.position = new Vector3(0f,0.1f,-2.5f);
				player2.transform.position = new Vector3(0f,0.1f,2.5f);
				p1Script.health = 100;
				p2Script.health = 100;		
				timer=null;
				winnerText1.enabled = false;
				winnerText2.enabled = false;
				gameState = GameState.Countdown;
			}	
		}

		if(gameState.Equals(GameState.GameOver))
		{
			// different outcomes depending on win or loss of game.
			// takes you to different places.
		}

	}

	

	void HandleHud()
	{
		player1HealthBar.value = p1Script.health;
		player2HealthBar.value = p2Script.health;

		timerText1.text = (time).ToString ();
		timerText2.text = (time).ToString ();
	}
}
