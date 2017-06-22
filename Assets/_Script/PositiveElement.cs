using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PositiveElement : MonoBehaviour {
	public float speed;
	public int PositiveIndex;
	public Sprite[] PositiveSprites;
	// Use this for initialization
	void Start () {
		AssignPositive ();
	}

	void AssignPositive(){
		PositiveIndex = Random.Range (0, PositiveSprites.Length);
		GetComponent <SpriteRenderer> ().sprite = PositiveSprites [PositiveIndex];
	}

	// Update is called once per frame
	void Update () {
		transform.Translate (Vector3.down * speed * Time.deltaTime);
	}

	void OnTriggerEnter2D (Collider2D col){
		if (col.tag == "PlayerCollider")
			SetPositive ();
	}

	void SetPositive(){

		Bricks.EnableSpawn = true;

		switch (PositiveIndex) {
		case 0:
			GM.instance.EnableShields ();
			break;
		case 1:
			GM.instance.StartShoot ();
			break;
		case 2:
			GM.instance.EnableUnbreakable ();
			break;

		}
		Destroy (gameObject);
	}
}
