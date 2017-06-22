using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerSelect : MonoBehaviour {
	public Sprite[] PowerUps;
	public Paddle Char;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnMouseDown(){
		Time.timeScale = 1;

		Char.PowerUp ();

		transform.parent.parent = Char.transform;
		transform.parent.gameObject.SetActive (false);

		GetComponent <SpriteRenderer> ().sprite = null;
	}

	public void SetSprite(int index){
		if(index>-1)
			GetComponent <SpriteRenderer> ().sprite = PowerUps [index];
	}
}
