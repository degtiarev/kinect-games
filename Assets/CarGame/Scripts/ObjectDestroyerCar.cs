using UnityEngine;
using System.Collections;

public class ObjectDestroyerCar : MonoBehaviour 
{
	public GameObject world;
	// Use this for initialization
	void Start () 
	{

	}

	// Update is called once per frame
	void Update () 
	{

	}


	void OnTriggerEnter(Collider theCollision)
	{
		GameObject gameControlObject = GameObject.FindWithTag ("World");

		GameObject collisionGO = theCollision.gameObject;

		if (gameControlObject != collisionGO)
		{

			if (collisionGO.transform.parent == world.transform)
				Destroy (collisionGO);
			else
				Destroy (collisionGO.transform.parent.gameObject);
		}
	}
}
