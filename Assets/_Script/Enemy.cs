using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {
	bool isBreak;
	public float speed;
	public int direction;
	public GameObject NegativeElement;
	// Use this for initialization
	void Start () {
		isBreak = true;
		Invoke ("Restart", Random.Range (5, 12));
		SpawnNegative ();
	}
	
	// Update is called once per frame
	void Update () {

		if (!isBreak)
			transform.Translate (Vector3.right * direction * Time.deltaTime);

		if (transform.position.x > 5 || transform.position.x < -5) {
			isBreak = true;
			Invoke ("Restart", Random.Range (5, 12));
		}
	}

	void Restart(){
		CancelInvoke ("Restart");
		direction *= -1;
		isBreak = false;
		transform.Translate (Vector3.right * direction * Time.deltaTime);
		Invoke ("SpawnNegative", Random.Range (4, 8));
	}

	void SpawnNegative(){
		CancelInvoke ("SpawnNegative");
		if (transform.position.x < 5 || transform.position.x > -5) {
			Instantiate(NegativeElement, transform.position, Quaternion.identity);
			//Invoke ("SpawnNegative", Random.Range (10, 20));
		}
	//	else
	//		Invoke ("SpawnNegative", Random.Range (5, 12));
	}
}
