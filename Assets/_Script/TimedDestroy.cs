using UnityEngine;
using System.Collections;

public class TimedDestroy : MonoBehaviour {

	public float destroyTime = 1f;

	// Use this for initialization
	void Start () {
		if(GM.isBlackOut)
			BlackOutLayer ();
		Destroy (gameObject, destroyTime);

	}

	void BlackOutLayer(){
		Transform[] Objects = GetComponentsInChildren <Transform> ();
		foreach (Transform Go in Objects)
			Go.gameObject.layer = 9;

	}

}