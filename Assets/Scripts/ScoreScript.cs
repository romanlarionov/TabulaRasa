using UnityEngine;
using System.Collections;

public class ScoreScript : MonoBehaviour 
{
	public float score;
	public float lastScore;
	public float multiplierTime;
	public bool multiplierActive;
	public int multiplier;
		
	private bool firstNodeTriggered;
	private SoundController player;
	// Use this for initialization
	void Start ()
	{
		player = this.gameObject.GetComponent<SoundController>();
		score = lastScore = 0.0f;
		firstNodeTriggered = false;
		multiplierTime = 0.0f;
		multiplierActive = false;
		multiplier = 1;
	}
		
	// Update is called once per frame
	void Update () 
	{
		// If firstNodeTriggered in scoreScript is false
		if(firstNodeTriggered)
		{
			// Start the elapsed time countdown
			score -= Time.deltaTime * 10.0f;
			// Clip the score to the last score
			if(score < lastScore)
			{
				score = lastScore;
			}
		}
			// If the multiplier is active
		if(multiplierActive)
		{
			// Decrement the multiplier time by elapsed time
			multiplierTime -= Time.deltaTime;
			// Clip the multiplier time to 0.0f
			if(multiplierTime < 0.0f)
			{
				multiplierTime = 0.0f;
				// If multiplier is greater than 1
				multiplier = 1;
			}
		}
	}

		public void AddMultiplier()
		{
			multiplier++;
		}
		
		public void SubtractMultiplier()
		{
			multiplier--;
		}
		
		public void SetMultiplier(bool active)
		{
			multiplierActive = active;
		}
		
		public void AddToMultiplierTime()
		{
		player.StartSound();
			if(multiplierTime < 10.0f)
			multiplierTime = 10.0f;
			
		}
		
		public void AddScore(float scoreToAdd)
		{
			score += scoreToAdd * multiplier;
			AddMultiplier();
		}
		
		public float GetScore()
		{
			return score;
		}
		
		public bool IsFirstNodeTriggered()
		{
			return firstNodeTriggered;
		}
		
		public void SetFirstNodeTriggered(bool triggered)
		{
			firstNodeTriggered = triggered;
		}
		
		public void SetLastScore(float score)
		{
			lastScore = score;
		}
	public void StartScore()
	{
		
		// Set scoreScript last score equal to the current score;
	 	SetLastScore(GetScore());
		// Add 1000 to the score
		AddScore(100.0f);
	
		// If firstNodeTriggered in scoreScript is false
		if(!IsFirstNodeTriggered())
		{
			// Set firstNodeTriggered to true
			SetFirstNodeTriggered(true);
		}
		
		// Set the multiplier to active
		SetMultiplier(true);
		// Add 15 seconds to the multiplier time
		AddToMultiplierTime();
	}
}
