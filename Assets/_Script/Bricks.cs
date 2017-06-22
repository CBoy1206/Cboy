using UnityEngine;
using System.Collections;

public class Bricks : MonoBehaviour {
	public Sprite[] SampleBricks;
	public Sprite[] SpecialBricks;
	public Sprite HardBrick;
	int index;

	bool isUnbreakable=false;
	public GameObject PositiveElement;
	void Awake(){
		GM.instance.bricks++;
		gameObject.tag = "Brick";
		EnableSpawn = true;
	}

	void OnEnable(){
		GM.OnUnBreakable += EnableHard;
	}

	void OnDisable(){
		GM.OnUnBreakable -= EnableHard;
	}


	void Start(){
		EnableSpawn = true;

		index = Random.Range (0, SampleBricks.Length);// + SpecialBricks.Length);
		int temp = Random.Range(0,20);
		if(temp<3)
			index+=Random.Range (0, SpecialBricks.Length+1);

		if(index<SampleBricks.Length)
			GetComponent<SpriteRenderer> ().sprite = SampleBricks [index];
		else
			GetComponent<SpriteRenderer> ().sprite = SpecialBricks [index-SampleBricks.Length];
	}

	public GameObject[] brickParticles;
	public float destroyTime=0.1f;

	void OnCollisionEnter2D (Collision2D other)
	{
		if (isUnbreakable)
			return;


		if (index < SampleBricks.Length)
			DestroyBrick ();
		else
			SpecialMove ();
	}

	void OnTriggerEnter2D (Collider2D col){
		if (index < SampleBricks.Length)
			DestroyBrick ();
		else
			SpecialMove ();
	}

	void DestroyBrick(){
		Instantiate(brickParticles[index], transform.position, Quaternion.identity);
		GM.instance.DestroyBrick();
		Destroy (gameObject, destroyTime);
		SpawnPos ();

	}
	bool isTriggered;
	void SpecialMove(){
		if (isTriggered)
			return;

		int NewIndex = index - SampleBricks.Length;
		switch (NewIndex) {
		case 0:
			Instantiate(brickParticles[2], transform.position, Quaternion.identity);
			GM.instance.DestroyBrick();
			ClearRow ();
			Destroy (gameObject, destroyTime);
			break;
		case 1:
			Instantiate(brickParticles[2], transform.position, Quaternion.identity);
			GM.instance.DestroyBrick();
			ClearColumn ();
			Destroy (gameObject, destroyTime);
			break;
		case 2:
			Instantiate(brickParticles[2], transform.position, Quaternion.identity);
			GM.instance.DestroyBrick();
			ClearRow ();
			ClearColumn ();
			Destroy (gameObject, destroyTime);
			break;
		case 3:
			Instantiate(brickParticles[2], transform.position, Quaternion.identity);
			GM.instance.DestroyBrick();
			SmallExplosion ();
			Destroy (gameObject, destroyTime);
			break;
		case 4:
			Instantiate(brickParticles[3], transform.position, Quaternion.identity);
			GM.instance.DestroyBrick();
			Explosion ();
			Destroy (gameObject, destroyTime);
			break;
		}

		SpawnPos ();
		isTriggered = true;
	}

	public GameObject LineObject,CircleObject;

	void ClearRow(){
		
		GameObject temp = Instantiate(LineObject, transform.position, Quaternion.identity);
		temp.GetComponent<LineFunction> ().isX = true;

	}

	void ClearColumn(){

		GameObject temp = Instantiate(LineObject, transform.position, Quaternion.identity);
		temp.GetComponent<LineFunction> ().isY = true;

	}

	void SmallExplosion(){
		GameObject temp = Instantiate(CircleObject, transform.position, Quaternion.identity);
		temp.GetComponent<CircleFunction> ().radius = 2.5f;
	}

	void Explosion(){

		GameObject temp = Instantiate(CircleObject, transform.position, Quaternion.identity);
		temp.GetComponent<CircleFunction> ().radius = 5;
	}

	void EnableHard(){
		isUnbreakable = true;
		GetComponent<SpriteRenderer> ().sprite = HardBrick;

		Invoke ("DisableHard", 5);
	}

	void DisableHard(){
		isUnbreakable = false;
		if(index<SampleBricks.Length)
			GetComponent<SpriteRenderer> ().sprite = SampleBricks [index];
		else
			GetComponent<SpriteRenderer> ().sprite = SpecialBricks [index-SampleBricks.Length];

	}
	public static bool EnableSpawn;
	void SpawnPos(){
		if (!EnableSpawn)
			return;


		//Invoke ("ResetSpawn",Random.Range (8,12));
		int rand = Random.Range (0, 50);
		if (rand < 10) {
			Instantiate (PositiveElement, transform.position, Quaternion.identity);
			EnableSpawn = false;
		}
	}

	void ResetSpawn(){
		EnableSpawn = true;
	}
}