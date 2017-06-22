using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CircleFunction : MonoBehaviour {
	public float radius;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		transform.localScale = Vector3.MoveTowards (transform.localScale, new Vector3 (radius, radius, 1), Time.deltaTime * 20);
	}
}
