using UnityEngine;
using System.Collections;

public class GameController : MonoBehaviour {

	public GUIText scoreText;
	public GUIText restartText;
	public GUIText gameOverText;
	public GUIText HealsText;
	
	public bool gameOver;
	private bool restart;
	private int score;
	//private int Heals;

	public GameObject block; 
	public Vector3 center;
	public Vector3 size;
	private float Timer;

	void Start () 
	{
		gameOver = false;
		restart = false;
		restartText.text = "";
		gameOverText.text = "";
		HealsText.text = "Balloon: 5";
		score = 0;
		UpdateScore ();
		StartCoroutine (Inst());
	}
	void Update ()
		{
		if (restart)
		{
			if (Input.GetKeyDown (KeyCode.R))
			{
				Application.LoadLevel (Application.loadedLevel);
			}
		}

		}
	IEnumerator Inst()
	{
		Timer += Time.deltaTime;
		yield return new WaitForSeconds (1 / Mathf.Sqrt (Timer));
		if (gameOver==false) 
		{
			Vector3 pos = center + new Vector3 (Random.Range (-size.x / 2, size.x / 2), Random.Range (-size.y / 2, size.y / 2), gameObject.transform.position.z);
			GameObject ob = Instantiate (block, pos, Quaternion.identity) as GameObject;
			Repeat ();
		}
	}
	void Repeat()
	{
		StartCoroutine (Inst());
	}
	public void AddScore (int newScoreValue)
	{
		score += newScoreValue;
		UpdateScore ();
	}
	
	void UpdateScore ()
	{
		scoreText.text = "Score: " + score;
	}
	public void UpdateHeals (int Heals)
	{
		HealsText.text = "Balloon: " + Heals;
	}
	public void UpdateRestart ()
	{
		restartText.text = "Press 'R' for Restart";
		restart = true;
	}
	
	public void GameOver ()
	{
		gameOverText.text = "Game Over!";
		gameOver = true;
	}
}
