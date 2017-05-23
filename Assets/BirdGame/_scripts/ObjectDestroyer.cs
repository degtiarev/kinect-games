using UnityEngine;
using System.Collections;

public class ObjectDestroyer : MonoBehaviour 
{
	public GameObject earth;
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

		GameObject collisionGO = theCollision.gameObject;
		if (collisionGO.transform.parent== earth.transform)
			Destroy (collisionGO);
		else 
			Destroy ( collisionGO.transform.parent.gameObject );

	}
}
