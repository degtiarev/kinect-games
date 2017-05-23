using UnityEngine;
using System.Collections;

public class TruckController : MonoBehaviour
{

	public bool toMove;

	const float startPositionX = -5.15f;
	const float finishPositionX = -7.25f;

	string direction;

	// Use this for initialization
	void Start ()
	{
	
	}
	
	// Update is called once per frame
	void Update ()
	{

		if (toMove) {
			toMove = false;
			direction = "forward";
		}

		if (direction == "forward") {
			transform.Translate (new Vector3 (2, 0, 0) * Time.deltaTime);
			if (transform.position.x < finishPositionX)
				direction = "back";
		}

		if (direction == "back") {
			transform.Translate (new Vector3 (-2, 0, 0) * Time.deltaTime);
			if (transform.position.x > startPositionX)
				direction = "";
		}


		int amountBoxes = 0;
		for (int i = 0; i < transform.GetChildCount (); i++) {
			GameObject Go = transform.GetChild (i).gameObject;
			if (Go.gameObject.tag.Equals ("box"))
				amountBoxes++;
		}

		if (amountBoxes == 2)
			toMove = true;
				
			

	}

}

