using UnityEngine;
using System.Collections;

public class PlaneRotate : MonoBehaviour {


	public static float speedRotation = 30f;

	// Use this for initialization
	void Start ()
	{

	}

	// Update is called once per frame
	void Update ()
	{
		transform.Rotate (new Vector3 (0, 0, 10) * Time.deltaTime * speedRotation/30f);
	}


}
