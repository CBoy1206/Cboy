using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LineFunction : MonoBehaviour {
	public bool isX;
	public bool isY;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
		if(isX)
			transform.localScale = Vector3.MoveTowards (transform.localScale, new Vector3 (50, 1, 1), Time.deltaTime * 50);
		else if(isY)
			transform.localScale = Vector3.MoveTowards (transform.localScale, new Vector3 (1, 50, 1), Time.deltaTime * 50);
		
	}
}
