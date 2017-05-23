	using UnityEngine;
using System.Collections;

public class PlaneController : MonoBehaviour {

	public float speed;
	float leftBoundary = -580f;
	float rightBoundary = -700f;
	public GameObject Boom;
	public ParticleEmitter particle;
	public ParticleSystem part;
	float moveHorizontal;

	public bool kinect=true;

	GameSettings gamesettings;
	// Use this for initialization

	void Start () {
		
		GameObject gameControlObject = GameObject.FindWithTag ("Settings");
		if (gameControlObject != null) 
		{
			gamesettings=gameControlObject.GetComponent<GameSettings>();
		}

		if (gamesettings == null) 
		{
			Debug.Log ("Cannot find Settings scropt");
		}
	}


	void FixedUpdate() {
		
		if (!kinect)
		moveHorizontal = Input.GetAxis ("Horizontal");	

		Vector3 movement = new Vector3 (moveHorizontal, 0.0f, 0.0f);

		GetComponent<Rigidbody> ().velocity = movement*speed;

		GetComponent<Rigidbody> ().position = new Vector3
			(
				Mathf.Clamp (GetComponent<Rigidbody>().position.x, rightBoundary, leftBoundary),
				GetComponent<Rigidbody> ().position.y,
				//Mathf.Clamp (GetComponent<Rigidbody> ().position.y, 211.89f, 230f),
				GetComponent<Rigidbody> ().position.z
			);

	}

	public void turnRight()
	{
		moveHorizontal = 1;	
	}

	public void turnLeft()
	{
		moveHorizontal = -1;

	}

	void OnTriggerEnter(Collider theCollision)
	{
		part.Play ();
		GameObject collisionGO = theCollision.gameObject;
		if (collisionGO.transform.name == "Star2" || collisionGO.transform.name == "Star2(Clone)") {
			gamesettings.AddScore (0.5);
			Destroy (collisionGO);
		}	
		else 
		{
			//Instantiate (Boom, new Vector3(-911.5f,95.1f,2280f), new Quaternion(0.0f, 0.0f, 0.0f,90.0f));
			Instantiate (Boom);
		}


	}
}