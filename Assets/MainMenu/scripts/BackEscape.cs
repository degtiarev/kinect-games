using UnityEngine;
using System.Collections;

public class BackEscape : MonoBehaviour
{

	// Use this for initialization
	void Start ()
	{
	
	}
	
	// Update is called once per frame
	void Update ()
	{
		if (Input.GetKey (KeyCode.Escape)) {


				Application.LoadLevel ("Main");

			foreach (GameObject o in Object.FindObjectsOfType<GameObject>()) {
				Destroy (o);

			}
		}
	}
}