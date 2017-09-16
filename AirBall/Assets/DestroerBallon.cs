using UnityEngine;
using System.Collections;

public class DestroerBallon : MonoBehaviour {

	public GameController gameController;
	private int scoreValue=10;
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetMouseButtonDown (0))
		{
			Ray ray = Camera.main.ScreenPointToRay(new Vector3(Input.mousePosition.x, Input.mousePosition.y,1));
			RaycastHit hit;
			if (Physics.Raycast (ray, out hit, Mathf.Infinity))
			{
				if (hit.transform.tag == "Balloon")
				{
					Destroy(hit.transform.gameObject);
					//gameController.AddScore(scoreValue);
					OnTriggerEnter();
				}
			}
		}
	}
	void OnTriggerEnter ()
	{
		gameController.AddScore(scoreValue);
	}
}