using UnityEngine;
using System.Collections;

public class DestroyByContact : MonoBehaviour 
{
	public int Heals=5;
	public GameController gameController;

	void Start ()
	{
		GameObject gameControllerObject = GameObject.FindGameObjectWithTag ("GameController");
		if (gameControllerObject != null)
		{
			gameController = gameControllerObject.GetComponent <GameController>();
		}
		if (gameController == null)
		{
			Debug.Log ("Cannot find 'GameController' script");
		}
	}

	void OnTriggerEnter (Collider other)
		{
		Destroy (other.gameObject);

		if (Heals > 1) 
		{
			Heals -= 1;
			gameController.UpdateHeals(Heals);
		}else 
		{
			gameController.GameOver();
			Heals -= 1;
			gameController.UpdateHeals(Heals);
			if (gameController.gameOver)
			{
				gameController.UpdateRestart();
				GameObject[] enemies = GameObject.FindGameObjectsWithTag("Balloon");
				foreach(GameObject enemy in enemies)
					GameObject.Destroy(enemy);;
			}

		}
	}
}
