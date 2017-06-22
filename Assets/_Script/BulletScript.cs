using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScript : MonoBehaviour {
	public float speed;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		transform.parent.Translate (Vector3.forward * Time.deltaTime * speed);
	}

	void OnTriggerEnter2D (Collider2D col){
		if (col.tag == "Brick")
			Destroy (transform.parent.gameObject);
	}
}
