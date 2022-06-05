using UnityEngine;
using System.Collections;

public class PlayerData 
{	
	private static PlayerData instance = null;
	
	public static PlayerData Instance
	{
		get {
			if (instance == null)
			{
				instance = new PlayerData();
			}
			return instance;
		}
	}
	
	private PlayerData ()
	{
		highScore = PlayerPrefs.GetInt("HighScore");
	}
	
	private int score = 0;
	
	public int Score
	{
		get {
			return this.score;
		}
		set {
			score = value;
			if (score > highScore)
			{
				this.highScore = score;
				PlayerPrefs.SetInt("HighScore", highScore);
			}
		}
	}
	
	private int highScore = 0;
	
	public int HighScore
	{
		get {
			return this.highScore;
		}
	}
	
	private int health = 3;
	public int Health {
		get {
			return this.health;
		}
		
		set {
			health = value;
		}
	}

	private float timer = 5000f;
	public float Timer {
		get {
			return this.timer;
		}
		
		set {
			timer = value;
		}
	}
}
