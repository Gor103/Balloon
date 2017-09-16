using UnityEngine;
using System.Collections;

public class Spawn : MonoBehaviour {

	public GameObject block; 
	public Vector3 center;
	public Vector3 size;
	private float Timer;

	void Start () {
		StartCoroutine (Inst());	
	}
	
	IEnumerator Inst()
	{
		Timer += Time.deltaTime;
		yield return new WaitForSeconds (1 / Mathf.Sqrt(Timer));
		Vector3 pos = center + new Vector3 (Random.Range (-size.x / 2, size.x / 2), Random.Range (-size.y / 2, size.y / 2), gameObject.transform.position.z);
		GameObject ob = Instantiate (block, pos, Quaternion.identity) as GameObject;
		Repeat ();
	}
	void Repeat()
	{
		StartCoroutine (Inst());
	}
	/*void Update()
	{
		Timer += Time.deltaTime;		
	}*/
}
