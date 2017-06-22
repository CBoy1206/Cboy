using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NegativeElement : MonoBehaviour {
	public float speed;
	public int NegativeIndex;
	public Sprite[] NegativeSprites;
	// Use this for initialization
	void Start () {
		AssignNegative ();
	}

	void AssignNegative(){
		NegativeIndex = Random.Range (0, NegativeSprites.Length);
		GetComponent <SpriteRenderer> ().sprite = NegativeSprites [NegativeIndex];
	}
	
	// Update is called once per frame
	void Update () {
		transform.Translate (Vector3.down * speed * Time.deltaTime);
	}

	void OnTriggerEnter2D (Collider2D col){
		if (col.tag == "PlayerCollider")
			SetNegative ();
	}

	void SetNegative(){
		if (Paddle.isShield) {
			Destroy (gameObject);
			return;
		}

		switch (NegativeIndex) {
		case 0:
			GM.instance.EnableBlackOut ();
			break;
		case 1:
			GM.instance.EnableShrink ();
			break;
		case 2:
			GM.instance.EnableUnbreakable ();
			break;
		
		}
		Destroy (gameObject);
	}
}
