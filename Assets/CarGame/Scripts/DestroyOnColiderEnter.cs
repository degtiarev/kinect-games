using UnityEngine;
using System.Collections;

public class DestroyOnColiderEnter : MonoBehaviour {


	void OnTriggerEnter (Collider theCollision)
	{
		DestroyObject (gameObject);
	}
}
