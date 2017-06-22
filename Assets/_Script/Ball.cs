using UnityEngine;
using System.Collections;

public class Ball : MonoBehaviour {

	public float ballInitialVelocity = 600f;


	private Rigidbody2D rb;
	private bool ballInPlay;
	bool isDead;
	void Awake () {
		rb = GetComponent<Rigidbody2D>();
	}

	void Update ()
	{
		if (Input.GetButtonDown("Fire1") && ballInPlay == false)
		{
			transform.parent = null;
			ballInPlay = true;
			rb.isKinematic = false;
			rb.simulated = true;
			rb.AddForce(new Vector3(ballInitialVelocity, ballInitialVelocity, 0));
		}

		if (transform.position.y < -5&&!isDead) {
			GM.instance.LoseLife ();
			isDead = true;
			Destroy (gameObject);
		}

	}
}
