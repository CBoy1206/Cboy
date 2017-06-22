using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GM : MonoBehaviour {

	public int lives = 4;
	public int score;
	public int bricks ;
	public float resetDelay = 1f;
	public Text livesText,scoreText;

	public GameObject GameCam;
	public GameObject gameOver;
	public GameObject youWon;
	public GameObject bricksPrefab;
	public GameObject paddle;
	public GameObject deathParticles;
	public static GM instance = null;

	public static bool isBlackOut=false;
	public delegate void BlackOut();
	public static event BlackOut OnBlackOut;
	public GameObject BlackOutCam;

	public delegate void UnBreakable();
	public static event UnBreakable OnUnBreakable;

	public delegate void Shrinker();
	public static event Shrinker OnShrinker;

	public GameObject clonePaddle;

	public GameObject Border;
	public GameObject Music;
	// Use this for initialization
	void Awake () 
	{
		if (instance == null)
			instance = this;
		else if (instance != this)
			Destroy (gameObject);

		//Setup();

	}
	void Update(){


		if (Input.GetKeyDown (KeyCode.S))
			EnableShrink ();
	}
	public void SetupDelay(){
		Invoke ("Setup", 1);
	}

	public void Setup()
	{
		DisableBlackOut ();
		Music.SetActive (true);
		clonePaddle = Instantiate(paddle, new Vector3(0,-3.26f,0), Quaternion.identity) as GameObject;
		Instantiate(bricksPrefab, new Vector3(0,3,0), Quaternion.identity);
		Border.SetActive (true);
	}

	void CheckGameOver()
	{
//		if (bricks < 1)
//		{
//			//youWon.SetActive(true);
//			Time.timeScale = .65f;
//			Invoke ("Reset", resetDelay);
//		}

		if(!GameObject.FindGameObjectWithTag ("Brick")){
			Time.timeScale = .5f;
			Invoke ("Reset", resetDelay);
		}

		if (lives < 1)
		{
			//gameOver.SetActive(true);
			Time.timeScale = .5f;
			Invoke ("Reset", resetDelay);
		}

	}
	bool isReset;
	public void Reset()
	{
		if (isReset)
			return;
		isReset = true;
		Time.timeScale = 1f;
		Application.LoadLevel(Application.loadedLevel);
	}

	public void LoseLife()
	{
		lives--;
		livesText.text = "Lives: " + lives;
		Instantiate(deathParticles, clonePaddle.transform.position, Quaternion.identity);
		Destroy(clonePaddle);
		Invoke ("SetupPaddle", resetDelay);
		//CheckGameOver();
	}

	public void UpdateScore(){
		score++;
		scoreText.text = "Score: " + score;
	}

	void SetupPaddle()
	{
		if (lives < 0)
			Application.LoadLevel (0);
		clonePaddle = Instantiate(paddle, new Vector3(0,-3.26f,0), Quaternion.identity) as GameObject;
		DisableBlackOut ();
	}

	public void DestroyBrick()
	{
		bricks--;
		UpdateScore ();
		CheckGameOver();
	}


	public void EnableBlackOut(){
		GameCam.SetActive (false);
		BlackOutCam.SetActive (true);
		isBlackOut = true;
		OnBlackOut ();

		Invoke ("DisableBlackOut", 7);
	}

	public void DisableBlackOut(){
		GameCam.SetActive (true);
		BlackOutCam.SetActive (false);
		isBlackOut = false;
	}

	public void EnableUnbreakable(){
		OnUnBreakable ();
	}

	public void EnableShrink(){
		clonePaddle.GetComponent <Paddle> ().PaddleTop.localScale = new Vector3 (0.5f, 0.5f, 1);
		Invoke ("DisableShrink", 5);
	}

	public void DisableShrink(){
		clonePaddle.GetComponent <Paddle> ().PaddleTop.localScale = new Vector3 (1f, 1f, 1);
	}

	public void EnableShields(){
		clonePaddle.GetComponent <Paddle> ().SetShield ();
		//clonePaddle.GetComponent <Paddle> ().PowerUpIndex = 0;
	}

	public void StartShoot(){
		clonePaddle.GetComponent <Paddle> ().EnableShoot ();
		//clonePaddle.GetComponent <Paddle> ().PowerUpIndex = 1;
	}


}