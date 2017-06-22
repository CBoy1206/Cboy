using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterSelect : MonoBehaviour {
	public Paddle Char;
	public int CharTag;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnMouseDown(){
		Time.timeScale = 1;
		Sprite temp = GetComponent <SpriteRenderer>().sprite;
		GetComponent <SpriteRenderer> ().sprite = Char.GetComponent <SpriteRenderer> ().sprite;
		Char.GetComponent <SpriteRenderer> ().sprite = temp;

		int a = CharTag;
		CharTag = Char.CharTag;
		Char.CharTag = a; 

		transform.parent.parent = Char.transform;
		transform.parent.gameObject.SetActive (false);
		Char.CheckTag ();

	}
}
