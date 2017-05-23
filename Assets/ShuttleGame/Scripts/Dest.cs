using UnityEngine;
using System.Collections;

public class Dest : MonoBehaviour {

	public float timer;
	
	// Update is called once per frame
	void Update () {
		Destroy (gameObject, timer);
	}
}
