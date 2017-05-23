using UnityEngine;
using System.Collections;

public class DeleteByTime : MonoBehaviour {

	public float timer;
	// Use this for initialization
	void Update()
	{
		Destroy (gameObject, timer);
	}



}
