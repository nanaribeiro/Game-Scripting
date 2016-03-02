using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GM : MonoBehaviour {

	public int lives = 3;
	public int bricks = 20;
	public float resetDelay = 1f;
	public Text livesText;
	public GameObject gameOver;
	public GameObject youWon;
	public GameObject bricksPreFab;
	public GameObject paddle;
	public GameObject deathParticles;
	public static GM instance = null;

	private GameObject clonePaddle;

	// Use this for initialization
	void Start () 
	{
		if (instance == null) 
		{
			instance = this;
		} 
		else if (instance != this) 
		{
			Destroy (gameObject);
		}
		Setup ();
	}

	public void Setup ()
	{
		clonePaddle = Instantiate (paddle, transform.position, Quaternion.identity) as GameObject;
		Instantiate (bricksPreFab, transform.position, Quaternion.identity);
	}

	void checkGameOver()
	{
		if (bricks < 1) {
			youWon.SetActive(true);
			Time.timeScale = .25f;
			Invoke("Reset", resetDelay);
		}
		if (lives < 1) {
			gameOver.SetActive(true);
			Time.timeScale = .25f;
			Invoke("Reset", resetDelay);
		}
	}

	void Reset()
	{
		Time.timeScale = 1f;
		Application.LoadLevel (Application.loadedLevel);
	}

	public void loseLifwe()
	{
		lives--;
		livesText.text = "Lives: " + lives;
		Instantiate (deathParticles, clonePaddle.transform.position, Quaternion.identity);
		Destroy (clonePaddle);
		Invoke ("setupPaddle", resetDelay);
		checkGameOver ();
	}

	void setupPaddle()
	{
		clonePaddle = Instantiate (paddle, transform.position, Quaternion.identity) as GameObject;
	}

	public void destroyBrick()
	{
		bricks --;
		checkGameOver ();
	}

}
