using UnityEngine;
using System.Collections;

public class CarController : MonoBehaviour
{

	public float speed = 5f;
	float leftBoundary = 4.6f;
	float rightBoundary = -4.6f;

	public float moveHorizontal;

	public bool kinect=true;


	//private static Quaternion startRotation;
	//public GameObject Boom;

	//GameController gamecontroller;
	//public text

	void Awake ()
	{
//		startRotation=transform.rotation;
//		//	GetComponent<Rigidbody>().freezeRotation = true;
	}

	// Use this for initialization
	void Start ()
	{


		//GameObject gameControlObject = GameObject.FindWithTag ("GameController");
		//if (gameControlObject != null) 
		//{
		//	gamecontroller=gameControlObject.GetComponent<GameController>();
		//}

		//if (gamecontroller == null) 
		//{
		//	Debug.Log ("Cannot find Gamecontroller scropt");
		//}
	}
		

	// Update is called once per frame
	void FixedUpdate ()
	{
		if (!kinect)
		 moveHorizontal = Input.GetAxis ("Horizontal");

		Vector3 movement = new Vector3 (-moveHorizontal, 0.0f, 0.0f);

		GetComponent<Rigidbody> ().velocity = movement * speed;

		GetComponent<Rigidbody> ().position = new Vector3 (
			Mathf.Clamp (GetComponent<Rigidbody> ().position.x, rightBoundary, leftBoundary),
			GetComponent<Rigidbody> ().position.y,
			//Mathf.Clamp (GetComponent<Rigidbody> ().position.y, 211.89f, 230f),
			GetComponent<Rigidbody> ().position.z
		);


		if (GetComponent<Rigidbody>().rotation.x>280.79f)
			transform.Rotate (new Vector3 (90, 0, 0) * Time.deltaTime * 3);

		if (GetComponent<Rigidbody> ().position.y > 211.89f)
			GetComponent<Rigidbody> ().velocity = new Vector3 (0, -3, 0);
		


	}

	void OnTriggerEnter (Collider theCollision)
	{
		//GameObject collisionGO = theCollision.gameObject;
		//if (collisionGO.transform.name == "star" || collisionGO.transform.name == "star(Clone)") {
		//	gamecontroller.AddScore (1);
		//	Destroy (collisionGO);
		//} else 
		//{
		//	Instantiate (Boom, new Vector3(9.97f,18.2f,6.01f), new Quaternion(0.0f, 0.0f, 0.0f,0.0f));
		//}
	}

	void Update ()
	{
		////Quaternion fixedQuartetion = transform.rotation;// new Quaternion (360.0f, 360.0f, 540.0f, 0.0f);
		//transform.rotation = startRotation;

	}

	public void turnRight()
	{
		moveHorizontal = 1;	
	}

	public void turnLeft()
	{
		moveHorizontal = -1;

	}
}
