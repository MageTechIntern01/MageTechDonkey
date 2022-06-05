using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class HUD : MonoBehaviour 
{
	public Text score = null;
	public Text highScore = null;
	public Text timer = null;
	public GameObject timerholder = null;
	private int myInt;

	public GameObject[] lives;

	public bool livesActive = true; 
	
	private static HUD instance = null;
	private GameObject playercheck; 
	
	void Awake ()
	{
		if (instance == null)
		{
			GameObject.DontDestroyOnLoad(this.gameObject);
			instance = this;
			myInt = (int)PlayerData.Instance.Timer;
		}
		else
		{
			GameObject.Destroy(this.gameObject);
		}
	}

	void Update ()
	{
		this.score.text =  PlayerData.Instance.Score.ToString("000000");
		this.highScore.text =  PlayerData.Instance.HighScore.ToString("000000");
		if (SceneManager.GetActiveScene().buildIndex == 5 ||
			SceneManager.GetActiveScene().buildIndex == 7 ||
			SceneManager.GetActiveScene().buildIndex == 9 ||
			SceneManager.GetActiveScene().buildIndex == 11)
		{
			playercheck = GameObject.Find("Mario");
			timerholder.SetActive(true);
			this.timer.text = PlayerData.Instance.Timer.ToString("0000");
			PlayerData.Instance.Timer -= Time.deltaTime * 100;

			lives = GameObject.FindGameObjectsWithTag("MarioLife");
			livesActive = false; 
		}

		if (PlayerData.Instance.Timer <= 0){
			if (PlayerData.Instance.Health <= 0){
				SceneManager.LoadScene(0);
			} else {
				PlayerData.Instance.Health--;
				SceneManager.LoadScene(4);
			}
		}


		if (PlayerData.Instance.Health == 2)
		lives[1].GetComponent<SpriteRenderer>().enabled = false;

		if (PlayerData.Instance.Health == 1)
			lives[0].GetComponent<SpriteRenderer>().enabled = false;

		if (PlayerData.Instance.Health == 0)
			lives[2].GetComponent<SpriteRenderer>().enabled = false;

		if (playercheck.GetComponent<MarioController>().endGame){
			//PlayerData.Instance.Score += myInt;
		}

	}

	void OnLevelWasLoaded ()
	{
		if (SceneManager.GetActiveScene().buildIndex == 0)
		{
			PlayerData.Instance.Score = 0;
			PlayerData.Instance.Health = 3;
			Destroy (this.gameObject);
		}
	}
}