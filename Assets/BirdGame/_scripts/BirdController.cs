using UnityEngine;
using System.Collections;

public class BirdController : MonoBehaviour
{
	
	public float speed = 5;
	public float upBoudary=20;
	public float downBoundary=18;
	
	private static Quaternion startRotation;
	public GameObject Boom;
	
	GameController gamecontroller;
	//public text
	
	void Awake ()
	{
		startRotation=transform.rotation;
		//	GetComponent<Rigidbody>().freezeRotation = true;
	}
	
	// Use this for initialization
	void Start()
	{
		
		
		GameObject gameControlObject = GameObject.FindWithTag ("GameController");
		if (gameControlObject != null) 
		{
			gamecontroller=gameControlObject.GetComponent<GameController>();
		}
		
		if (gamecontroller == null) 
		{
			Debug.Log ("Cannot find Gamecontroller scropt");
		}
	}
	
	// Update is called once per frame
	void FixedUpdate ()
	{
		float moveVertical = Input.GetAxis ("Vertical");
		
		Vector3 movement = new Vector3 (0.0f, moveVertical, 0.0f);
		
		GetComponent<Rigidbody> ().velocity = movement * speed;
		
		GetComponent<Rigidbody> ().position = new Vector3
			(
				Mathf.Clamp (GetComponent<Rigidbody>().position.x, 11,11),
				Mathf.Clamp (GetComponent<Rigidbody> ().position.y, downBoundary, upBoudary),
				0.0f
				);
		
	}
	
	void OnTriggerEnter(Collider theCollision)
	{
		GameObject collisionGO = theCollision.gameObject;
		if (collisionGO.transform.name == "star" || collisionGO.transform.name == "star(Clone)") {
			gamecontroller.AddScore (1);
			Destroy (collisionGO);
		} else 
		{
			 Instantiate (Boom, new Vector3(9.97f,18.2f,6.01f), new Quaternion(0.0f, 0.0f, 0.0f,0.0f));
		}
	}
	
	void Update()
	{
		//Quaternion fixedQuartetion = transform.rotation;// new Quaternion (360.0f, 360.0f, 540.0f, 0.0f);
		transform.rotation = startRotation;
		
	}
	
}
