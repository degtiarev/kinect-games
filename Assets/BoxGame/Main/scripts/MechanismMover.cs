using UnityEngine;
using System.Collections;

public class MechanismMover : MonoBehaviour
{

	public bool isMoving;

	Animation anim;


	// Use this for initialization
	void Start ()
	{
		anim = GetComponent<Animation> ();
	}
	
	// Update is called once per frame
	void Update ()
	{




		if (Input.GetKeyDown (KeyCode.LeftArrow)) {
			turnLeft ();
		}

		if (Input.GetKeyDown (KeyCode.RightArrow)) {
			turnRight ();
		}

			
	}

	public void turnRight()
	{
		anim.Play ("right");
	}


	public void turnLeft()
	{
		anim.Play ("left");
	}

}
