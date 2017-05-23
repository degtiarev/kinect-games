using UnityEngine;
using System.Collections;

public class RacketController: MonoBehaviour {

	public float start ;
	public float finish ;

	public string direction;

	// Use this for initialization
	void Start () {

		start = transform.position.y;
		finish = start + 0.15f;

		direction="stop";	
	}

	// Update is called once per frame
	void Update () {

		if (Input.GetKeyDown ("space")) direction="up";


		if (transform.position.y >= finish)
			direction = "down";
		if(transform.position.y<=start && direction=="down")
			direction="stop";

		if(direction=="up")
			transform.Translate(Vector3.forward * Time.deltaTime*0.8f);
		if(direction=="down")
			transform.Translate(Vector3.back * Time.deltaTime*0.8f);



	}

	void OnCollisionEnter(Collision collision) {
		
		if (direction == "up") {

			GameObject ballspawn = GameObject.Find("BallSpawn");
			BallSpawn ballspawnScript = ballspawn.GetComponent<BallSpawn>();
			// Get current health
			ballspawnScript.score++;
		}

	}

	public void up()
	{
		direction="up";

	}
}
